
using AutoMapper;
using Domain.Models;
using Domain.Service.Job.DTOs;
using Domain.Service.JobProvider.Dtos;
using Domain.Service.Login.DTOs;
using Domain.Service.Job.DTOs;
using Domain.Service.JobProvider.DTOs;
using Domain.Service.SignUp.DTOs;
using HireMeNow_WebApi.API.Job.SavedJobObjects;
using HireMeNow_WebApi.API.JobProvider.RequestObjects;
using HireMeNow_WebApi.API.JobSeeker.RequestObjects;
using Domain.Service.Profile.DTOs;
using HireMeNow_WebApi.JobSeeker;
using Domain.Service.Admin.DTOs;
using Domain.Service.JobSeeker.DTOs;
using HireMeNow_WebApi.API.Admin.RequestObjects;
using HireMeNow_WebApi.API.Chat.RequestObjects;

namespace HireMeNow_WebApi.Extensions
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
          
            CreateMap<JobSeekerSignupRequestDto, SignUpRequest>().ReverseMap();
			CreateMap<JobSeekerSignupRequest, JobSeekerSignupRequestDto>().ReverseMap();

            CreateMap<JobProviderSignupRequestDto, SignUpRequest>().ReverseMap();
            CreateMap<JobProviderSignupRequest, JobProviderSignupRequestDto>().ReverseMap();

            CreateMap<SignUpRequest, SystemUser>().ReverseMap();
            CreateMap<AuthUser, Domain.Models.JobSeeker>().ReverseMap();
            CreateMap<AuthUser, SystemUser>().ReverseMap();
            CreateMap<AuthUser, Domain.Models.CompanyUser>().ReverseMap();
            CreateMap<JobPost, JobPostsDtos>().ReverseMap();
            CreateMap<JobPost, Domain.Service.Admin.DTOs.JobProviderDto>().ReverseMap();
            CreateMap<Qualification,QualificationsRequestDto>().ReverseMap();
            CreateMap<QualificationRequest, JobseekerQualificationDTo>();
            CreateMap<Qualification,JobseekerQualificationDTo>();
            CreateMap<Skill, SkillDto>();
            CreateMap<JobseekerQualificationDTo, Qualification>();
            CreateMap<WorkExperieceRequest, JobseekerWorkExperienceDTo>();
            CreateMap<JobseekerWorkExperienceDTo, WorkExperience>();
            CreateMap<WorkExperience, ExperienceDto>();
            CreateMap<AuthUser, JobSeekerLoginDto>();


            CreateMap<Industry, IndustryRequest>().ReverseMap();
            CreateMap<JobCategory, CategoryRequest>().ReverseMap();
            CreateMap<Location, LocationRequest>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();

            CreateMap<CompanyMemberDtos, CompanyUser>().ReverseMap();
            CreateMap<companyUserRequest, CompanyMemberDtos>().ReverseMap();

            CreateMap<CompanyMemberDtos, AuthUser>().ReverseMap();
            CreateMap<JobPostRequest, JobPost>().ReverseMap();

            CreateMap<JobApplication, JobApplicationDto>().ReverseMap();
            CreateMap<JobProviderCompany, Domain.Service.Admin.DTOs.JobProviderDto>().ReverseMap();


            CreateMap<AuthUser, JobSeekerLoginDto>();
            CreateMap<JobPost, Joblist>().ReverseMap();
            CreateMap<AuthUser, AdminLoginDTO>();

            CreateMap<JobSeekerProfileDTo, Domain.Models.JobSeeker>();
            CreateMap<ApplyJobRequest, JobApplication>();
            CreateMap<JobApplication, AppliedJobsDtos>();
            CreateMap<CompanyRegistrationDtos, JobProviderCompany>().ReverseMap();
            CreateMap<AddCompanyRequestobject, JobProviderCompany>().ReverseMap();
			CreateMap<CompanyRegistrationDtos, AddCompanyRequestobject>().ReverseMap();
            CreateMap<CompanyUpdateDtos, CompanyupdateRequest>().ReverseMap();
            CreateMap<CompanyUpdateDtos,JobProviderCompany>().ReverseMap();
            CreateMap<SavedJob,SavedJobsDtos>().ReverseMap();
            CreateMap<JobProviderCompany, GetCompanyDetailsDto>();
           CreateMap<InterviewSheduleObject,InterviewsheduleDtos>();    
            CreateMap<InterviewsheduleDtos,Interview>();
			CreateMap<SheduledInterviewDto,Interview>();
			CreateMap<Interview, SheduledInterviewDto>();
            CreateMap<CompanyUser, CompanyMemberListDtos>().ReverseMap();
            CreateMap<SaveJobRequest,SavedJob>().ReverseMap();
	


            CreateMap<JobPost, JobPostsDtos>().ReverseMap();
            CreateMap<JobPost, Domain.Service.Admin.DTOs.JobProviderDto>().ReverseMap();
            CreateMap<Domain.Models.JobSeeker, JobSeekerDto>().ReverseMap();
            CreateMap<JobProviderCompany, Domain.Service.Admin.DTOs.JobProviderDto>().ReverseMap();
            CreateMap<CompanyUser, CompanyUsersDto>().ReverseMap();
			CreateMap<Resume, resumeDto>();
            CreateMap<JobSeekerProfile, ProfileDTO>();
            CreateMap<ProfileDTO,JobseekerProfileRequest>();
            CreateMap<JobseekerProfileRequest, ProfileDTO>();
            CreateMap<ProfileDTO, JobSeekerProfile>();
            CreateMap<SkillRequest, SkillDto>();
            CreateMap<SkillDto, Skill>();

            CreateMap<AuthUser, ChatUserDto>().ReverseMap();
        }
    }
}
