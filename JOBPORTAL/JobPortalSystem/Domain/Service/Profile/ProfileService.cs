using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.Admin.DTOs;
using Domain.Service.Authuser.DTOs;
using Domain.Service.JobSeeker;
using Domain.Service.Profile.DTOs;
using Domain.Service.Profile.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Service.Profile
{
    public class ProfileService : IJobSeekerProfileService
    {
        public readonly IJobSeekerProfileRepository _profileRepository;
        IMapper mapper;
        public ProfileService(IJobSeekerProfileRepository profileRepository, IMapper _mapper)
        {
            mapper = _mapper;
            _profileRepository = profileRepository;
        }

        public async Task<bool> AddProfileAsync(ProfileDTO addProfileDto)
        {
            var profile = mapper.Map<JobSeekerProfile>(addProfileDto);
            await _profileRepository.AddProfileAsync(profile);
            return true;
        }

        public async void AddQualificationToProfile(Guid jobseekerId, Guid profileId, Qualification qualification)
        {
            var profile = await _profileRepository.GetJobSeekerProfileByIds(jobseekerId, profileId);
            if (profile != null)
            {
                var Qualification = mapper.Map<Qualification>(qualification);
                await _profileRepository.AddQualificationsToProfile(profileId, Qualification);

            }
            else
            {
                throw new Exception("Profile not found");
            }
        }


        public async Task AddQualificationToProfileAsync(Guid jobseekerId, Guid profileId, JobseekerQualificationDTo jobseekerQualificationDTo)
        {
            var profile =await  _profileRepository.GetJobSeekerProfileByIds(jobseekerId, profileId);
            if (profile != null)
            {
                var Qualification = mapper.Map<Qualification>(jobseekerQualificationDTo);
                 await _profileRepository.AddQualificationsToProfile(profileId, Qualification);

            }
            else
            {
                throw new Exception("Profile not found");
            }
        }

        public async Task AddSkillsToProfile(Guid jobseekerId, Guid profileId, List<Guid> skills)
        {
            var profile = await _profileRepository.GetJobSeekerProfileByIds(jobseekerId, profileId);

            if (profile != null)
            {
                List<JobSeekerProfileSkill> skillslist = new List<JobSeekerProfileSkill>();
                skills.ForEach(x =>
                {
                    JobSeekerProfileSkill jobSeekerProfileSkill = new JobSeekerProfileSkill();

                    jobSeekerProfileSkill.SkillId = x;
                    jobSeekerProfileSkill.JobSeekerProfileId = profile.Id;
                    skillslist.Add(jobSeekerProfileSkill);
                });
                profile.JobSeekerProfileSkills = skillslist;
                // Add the skills to the profile
                await _profileRepository.AddSkillsToProfile(profile);
            }
            else
            {
                throw new Exception("Profile not found");
            }
        }

        public async Task AddWorkExpericeToProfileAsync(Guid jobseekerId, Guid profileId, JobseekerWorkExperienceDTo data)
        {
            //var profile = _profileRepository.GetJobSeekerProfileByIds(jobseekerId, profileId);
            //if (profile != null)
            //{
            var Experience = mapper.Map<WorkExperience>(data);
            await _profileRepository.AddWorkExperienceToProfile(profileId, Experience);

     




        }

        public async Task<JobSeekerProfileDTo> GetcompleateProfile(Guid jobseekerId)
        {
            var jobSeekerProfile = await _profileRepository.GetProfiledetailAsync(jobseekerId);

            if (jobSeekerProfile == null)
            {
                // Handle case when the profile is not found
                return null; // or throw an exception or handle it according to your application logic
            }

            var jobSeekerProfileDTO = new JobSeekerProfileDTo
            {
                UserName = jobSeekerProfile.JobSeeker.UserName,
                FirstName = jobSeekerProfile.JobSeeker.FirstName,
                LastName = jobSeekerProfile.JobSeeker.LastName,
                Phone = jobSeekerProfile.JobSeeker.Phone,
                Email = jobSeekerProfile.JobSeeker.Email,
                Qualification = jobSeekerProfile.Qualifications.ToList(),
                JobSeekerProfileSkills = jobSeekerProfile.JobSeekerProfileSkills.Select(s => s.Skill).ToList(),
                Role = jobSeekerProfile.JobSeeker.Role,
 
            };

            return jobSeekerProfileDTO;
        }

        public List<ExperienceDto> GetExperience(Guid jobseekerId, Guid profileId)
        {

            var workExperiences = _profileRepository.GetExperience(jobseekerId, profileId);
            var experienceDtos = mapper.Map<List<ExperienceDto>>(workExperiences);

            return experienceDtos;

        }

        public List<JobSeekerProfileDTo> GetProfile(Guid jobseekerId)
        {
            return _profileRepository.GetProfile(jobseekerId);
        }

        public Task<JobSeekerProfile> GetProfileAsync(Guid jobSeekerId)
        {
            return _profileRepository.GetProfileAsync(jobSeekerId);


        }

        public Task GetProfileDetailsAsync(Guid jobseekerId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<JobSeekerProfile>> GetProfilesByJobSeekerIdAsync(Guid jobSeekerId)
        {
            return await _profileRepository.GetProfilesByJobSeekerIdAsync(jobSeekerId);
        }

        public List<JobseekerQualificationDTo> GetQualification(Guid profileId)
        {

            var Qualifications = _profileRepository.GetQualification(profileId);
            var QualificationDtos = mapper.Map<List<JobseekerQualificationDTo>>(Qualifications);

            return QualificationDtos;

        }

        public List<SkillDto> GetSkillsForJobSeekerProfile(Guid jobseekerId, Guid profileId)
        {
            return _profileRepository.GetSkillsForProfile(jobseekerId, profileId);
        }

        public List<SkillDto>  GetSkillsForJobSeekerProfile()
        {
            var Skills = _profileRepository.GetSkillsForProfile();
            var SkillDtos = mapper.Map<List<SkillDto>>(Skills);

            return SkillDtos;
          
        }


        public async Task<AuthUserDTO> UpdateJobSeekerProfile(AuthUserDTO updatedProfile)
        {
            // Perform validation, mapping, and update logic if needed
            // Call the repository to update the JobSeeker's profile
            var result = await _profileRepository.UpdateProfile(updatedProfile);

            return result;
        }

        
    }
}

