using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;
using Domain.Service.Admin.DTOs;
using Domain.Service.Authuser.DTOs;
using Domain.Service.Profile.DTOs;
using Domain.Service.Profile.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Service.Profile
{
    public class ProfileRepository : IJobSeekerProfileRepository
    {
        protected readonly DbHireMeNowWebApiContext _context;
        public ProfileRepository(DbHireMeNowWebApiContext context)
        {
            _context = context;
        }

        public async Task AddProfileAsync(JobSeekerProfile profile)
        {
            profile.Id = Guid.NewGuid();
            _context.JobSeekerProfiles.Add(profile);
            await _context.SaveChangesAsync();
        }

        public async Task AddQualificationsToProfile(Guid profileId, Qualification qualification)
        {

            qualification.JobseekerProfileId = profileId;
            _context.Qualifications.Add(qualification);
            await _context.SaveChangesAsync();

        }

        //public void AddQualificationToProfile(Guid profileId, Qualification qualification)
        //{

        //    qualification.JobseekerProfileId = profileId;
        //     _context.Qualifications.AddAsync(qualification);
        //    _context.SaveChangesAsync();
        //}


        public async Task AddSkillsToProfile(JobSeekerProfile profile)
        {
            if (profile != null)
            {
                //foreach (var skillName in skills)
                //{
                //    var skill = new Skill {Name = skillName }; // Adjust property name according to your Skill model
                //    profile.JobSeekerProfileSkills.Add(new JobSeekerProfileSkill { Skill = skill });
                //}

                _context.JobSeekerProfiles.Update(profile);
                _context.SaveChanges();
            }
        }

        public async Task AddWorkExperienceToProfile(Guid profileId, WorkExperience experience)
        {
            experience.JobSeekerProfileId = profileId;
            experience.Id = Guid.NewGuid();
            await _context.WorkExperiences.AddAsync(experience);
            await _context.SaveChangesAsync();

        }

        public List<WorkExperience> GetExperience(Guid jobseekerId, Guid profileId)
        {
            return _context.WorkExperiences
               .Where(experience => experience.JobSeekerProfileId == profileId)
               .ToList();


        }

        //public async Task AddWorkExperienceToProfile(Guid profileId, WorkExperience experience)
        //{
        //}
        public async Task<JobSeekerProfile?> GetJobSeekerProfileByIds(Guid jobseekerId, Guid profileId)
        {
            return await _context.JobSeekerProfiles
             .FirstOrDefaultAsync(profile => profile.JobSeekerId == jobseekerId && profile.Id == profileId);
        }

        public List<JobSeekerProfileDTo> GetProfile(Guid jobseekerId)
        {
            var jobSeekerProfile = _context.JobSeekerProfiles
           .Include(profile => profile.Qualifications)
           .Include(profile => profile.JobSeekerProfileSkills)
           .Include(profile => profile.JobSeeker)
           .FirstOrDefault(profile => profile.JobSeekerId == jobseekerId);

            if (jobSeekerProfile == null)
            {
                // Handle case when the profile is not found
                return new List<JobSeekerProfileDTo>(); // or return null, depending on your handling
            }

            var jobSeekerProfileDTO = new JobSeekerProfileDTo
            {
                UserName = jobSeekerProfile.JobSeeker.UserName,
                FirstName = jobSeekerProfile.JobSeeker.FirstName,
                LastName = jobSeekerProfile.JobSeeker.LastName,
                Phone = jobSeekerProfile.JobSeeker.Phone,
                Email = jobSeekerProfile.JobSeeker.Email,
                image = jobSeekerProfile.JobSeeker.Image,
                Qualification = jobSeekerProfile.Qualifications.ToList(),
                JobSeekerProfileSkills = jobSeekerProfile.JobSeekerProfileSkills.Select(s => s.Skill).ToList(),
                Role = jobSeekerProfile.JobSeeker.Role
            };

            // Return a list with a single item (your DTO)
            return new List<JobSeekerProfileDTo> { jobSeekerProfileDTO };
        }
    

        public async Task<JobSeekerProfile> GetProfileAsync(Guid jobSeekerId)
        {
            return await _context.JobSeekerProfiles
                        .Where(profile => profile.JobSeekerId == jobSeekerId)
                        .Include(profile => profile.Resume) // Include related entities if needed
                        .Include(profile => profile.JobSeekerProfileSkills) // Include related entities if needed

                        .Include(profile => profile.Qualifications) // Include related entities if needed
                        .Include(profile => profile.WorkExperiences) // Include related entities if needed
                        .FirstOrDefaultAsync();
        }

        public  Task<JobSeekerProfile> GetProfiledetailAsync(Guid jobseekerId)
        {
            return _context.JobSeekerProfiles
          .Where(profile => profile.JobSeekerId == jobseekerId)
          .Include(profile => profile.Resume)
          .Include(profile => profile.JobSeekerProfileSkills)
          .Include(profile => profile.Qualifications)
          .Include(profile => profile.WorkExperiences)
          .FirstOrDefaultAsync();
        }

        public async Task<List<JobSeekerProfile>> GetProfilesByJobSeekerIdAsync(Guid jobSeekerId)
        {
            return await _context.JobSeekerProfiles
                .Where(profile => profile.JobSeekerId == jobSeekerId)
                .Include(p => p.Resume)   // 🔥 ADD THIS
                .ToListAsync();
        }

        public List<Qualification> GetQualification(Guid jobseekerId, Guid profileId)
        {
            return _context.Qualifications
                .Where(qualification => qualification.JobseekerProfileId == profileId)
                .ToList();
        }

        public List<Qualification> GetQualification(Guid profileId)
        {
            return _context.Qualifications
                .Where(qualification => qualification.JobseekerProfileId == profileId)
                .ToList();
        }

        public List<SkillDto> GetSkillsForProfile(Guid jobseekerId, Guid profileId)
        {
            return _context.JobSeekerProfiles
                   .Where(profile => profile.JobSeekerId == jobseekerId && profile.Id == profileId)
                   .SelectMany(profile => profile.JobSeekerProfileSkills.Select(skill => new SkillDto
                   {
                       Name = skill.Skill.Name,
                       Description = skill.Skill.Description
                   }))
                   .ToList();
        }

        public List<Skill> GetSkillsForProfile()
        {
            return _context.Skills.ToList();
        }

        /*        public async Task<AuthUserDTO> UpdateProfile(AuthUserDTO updatedProfile)
                {
                    var existingProfile2 = _context.JobSeekers.FirstOrDefault(e => e.Id == updatedProfile.JobseekerId);

                    var existingProfile = _context.AuthUsers.FirstOrDefault(e => e.Id == updatedProfile.JobseekerId);

                    byte[] byteArray =ConvertImageToByteArray(updatedProfile.Image);
                    existingProfile2.Image = byteArray;

                    if (existingProfile == null)
                    {
                        // Handle case when the profile is not found
                        return null;
                    }
                    existingProfile.FirstName = updatedProfile.FirstName;
                    existingProfile.LastName = updatedProfile.LastName;
                    existingProfile.Phone = updatedProfile.Phone;
                    existingProfile.Password = updatedProfile.Password;
                    existingProfile.Phone =updatedProfile.Phone;
                    existingProfile.UserName = updatedProfile.UserName;

                    existingProfile2.FirstName = updatedProfile.FirstName;
                    existingProfile2.LastName = updatedProfile.LastName;
                    existingProfile2.Phone = updatedProfile.Phone;
                    existingProfile2.Phone = updatedProfile.Phone;
                    existingProfile2.UserName = updatedProfile.UserName;

                    // Save changes to the database
                    await _context.SaveChangesAsync();

                    return updatedProfile;
                }*/

        public async Task<AuthUserDTO> UpdateProfile(AuthUserDTO updatedProfile)
        {
            // Retrieve the existing profiles
            var existingProfile = _context.AuthUsers.FirstOrDefault(e => e.Id == updatedProfile.JobseekerId);
            var existingProfile2 = _context.JobSeekers.FirstOrDefault(e => e.Id == updatedProfile.JobseekerId);

            if (existingProfile == null || existingProfile2 == null)
            {
                // Handle case when the profile is not found
                return null;
            }

            // Update image only if it's provided in the updatedProfile
            if (updatedProfile.Image != null)
            {
                byte[] byteArray = ConvertImageToByteArray(updatedProfile.Image);
                existingProfile2.Image = byteArray;
            }

            // Update fields only if they are provided in the updatedProfile and different from the current values
            if (!string.IsNullOrEmpty(updatedProfile.FirstName))
            {
                existingProfile.FirstName = updatedProfile.FirstName;
                existingProfile2.FirstName = updatedProfile.FirstName;
            }

            if (!string.IsNullOrEmpty(updatedProfile.LastName))
            {
                existingProfile.LastName = updatedProfile.LastName;
                existingProfile2.LastName = updatedProfile.LastName;
            }

            if (!string.IsNullOrEmpty(updatedProfile.Phone))
            {
                existingProfile.Phone = updatedProfile.Phone;
                existingProfile2.Phone = updatedProfile.Phone;
            }

            if (!string.IsNullOrEmpty(updatedProfile.Password))
            {
                existingProfile.Password = updatedProfile.Password;
            }

            if (!string.IsNullOrEmpty(updatedProfile.UserName))
            {
                existingProfile.UserName = updatedProfile.UserName;
                existingProfile2.UserName = updatedProfile.UserName;
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            return updatedProfile;
        }

        public byte[] ConvertImageToByteArray(IFormFile imageFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                imageFile.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

    }
}
