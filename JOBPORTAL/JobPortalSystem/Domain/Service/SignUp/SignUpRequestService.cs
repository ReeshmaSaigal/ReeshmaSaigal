using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.Authuser;
using Domain.Service.Authuser.Interfaces;

using Domain.Service.SignUp.DTOs;
using Domain.Service.SignUp.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.SignUp
{
    public class SignUpRequestService : ISignUpRequestService
    {
        ISignUpRequestRepository jobSeekerRepository;
        IAuthUserRepository authUserRepository;
        IMapper mapper;
        IEmailService emailService;
        public SignUpRequestService(ISignUpRequestRepository _jobSeekerRepository, IMapper _mapper, IEmailService _emailService, IAuthUserRepository _authUserRepository)
        {
            jobSeekerRepository = _jobSeekerRepository;
            mapper = _mapper;
            emailService = _emailService;
            authUserRepository = _authUserRepository;
        }

        public async Task CreateJobseeker(Guid jobSeekerSignupRequestId, string password)
        {
            try
            {
                SignUpRequest signUpRequest = await jobSeekerRepository.GetSignupRequestByIdAsync(jobSeekerSignupRequestId);
                //AuthUser authUser = mapper.Map<AuthUser>(signUpRequest);
                AuthUser authUser = new();
                if (signUpRequest.Status == Enums.Status.VERIFIED)
                {
                    //need to change this code by using Automapper 



                    authUser.UserName = signUpRequest.UserName;
                    authUser.Role = Enums.Role.JOB_SEEKER;
                    authUser.FirstName = signUpRequest.FirstName;
                    authUser.LastName = signUpRequest.LastName;
                    authUser.Email = signUpRequest.Email;
                    authUser.Password = password;
                    authUser.Phone = signUpRequest.Phone;
                    authUser = await authUserRepository.AddAuthUser(authUser);
                    signUpRequest.Status = Enums.Status.CREATED;
                    jobSeekerRepository.UpdateSignupRequest(signUpRequest);
                }

                Models.JobSeeker jobseeker = mapper.Map<Models.JobSeeker>(authUser);

                //await jobSeekerRepository.AddJobSeekerAsync(jobseeker);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async void CreateSignupRequest(JobSeekerSignupRequestDto data)
        {

            var signUpRequest = mapper.Map<SignUpRequest>(data);
            var signUpId = jobSeekerRepository.AddSignupRequest(signUpRequest);
            MailRequest mailRequest = new MailRequest();
            mailRequest.Subject = "HireMeNow SignUp Verification";
            mailRequest.Body = "http://localhost:4200/set-password?signupid=" + signUpId.ToString();
            mailRequest.ToEmail = signUpRequest.Email;
            await emailService.SendEmailAsync(mailRequest);
        }

        public async Task<bool> VerifyEmailAsync(Guid jobSeekerSignupRequestId)
        {

            SignUpRequest signUpRequest = await jobSeekerRepository.GetSignupRequestByIdAsync(jobSeekerSignupRequestId);
            if (signUpRequest != null)
            {
                signUpRequest.Status = Enums.Status.VERIFIED;
                jobSeekerRepository.UpdateSignupRequest(signUpRequest);
                return true;
            }
            return false;
        }


        public async Task<Guid> addResume(string title, byte[] fileData)
        {
            Guid resumeId = Guid.NewGuid();
            await jobSeekerRepository.addResume(resumeId, title, fileData);

            return resumeId;
        }

        public async Task addResumeToProfile(Guid profileId, Guid resumeId, Guid jobSeekerId, string profileName, string profileSummary)
        {
            await jobSeekerRepository.addResumeToProfile(profileId, resumeId, jobSeekerId, profileName, profileSummary);
        }
        public async Task<Guid> getResumeId(Guid profileId)
        {
            Guid resumeId = await jobSeekerRepository.getResumeId(profileId);
            return resumeId;
        }

        public async Task<byte[]> getResumeFile(Guid resumeId)
        {
            byte[] byteArray = await jobSeekerRepository.getResumeFile(resumeId);
            return byteArray;
        }

        public async Task UpdateResume(Guid resumeId, byte[] fileData)
        {
            await jobSeekerRepository.UpdateResume(resumeId, fileData);
        }

        public async Task<List<Resume>> getResumeById(Guid resumeId)
        {
            return await jobSeekerRepository.getResume(resumeId);
        }
        public async Task DeleteResume(Guid resumeId)
        {
            await jobSeekerRepository.DeleteResume(resumeId);
        }
    }
}
