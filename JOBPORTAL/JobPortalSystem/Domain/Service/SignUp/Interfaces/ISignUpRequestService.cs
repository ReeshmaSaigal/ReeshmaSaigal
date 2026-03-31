using AutoMapper;
using Domain.Models;
using Domain.Service.SignUp.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.SignUp.Interfaces
{
    public interface ISignUpRequestService
    {
        Task CreateJobseeker(Guid jobSeekerSignupRequestId, string password);

        //Task<Guid> AddJobseekerSignUpRequest(JobSeekerSignupRequest jobseekerCreateRequest);
        void CreateSignupRequest(JobSeekerSignupRequestDto data);
       
        Task<bool> VerifyEmailAsync(Guid jobSeekerSignupRequestId);

        Task<Guid> addResume(string title, byte[] fileData);

        Task addResumeToProfile(Guid profileId, Guid resumeId, Guid jobSeekerId,string profileName,string profileSummary);

        public Task<Guid> getResumeId(Guid profileId);

        public Task<List<Resume>> getResumeById (Guid resumeId);


		public Task<byte[]> getResumeFile(Guid resumeId);

        Task UpdateResume(Guid resumeId, byte[] fileData);

        Task DeleteResume(Guid resumeId);
    }
}
