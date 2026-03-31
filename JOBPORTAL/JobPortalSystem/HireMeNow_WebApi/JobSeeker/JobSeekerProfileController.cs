using AutoMapper;
using Domain.Models;
using Domain.Service.Admin.DTOs;
using Domain.Service.Authuser.DTOs;
using Domain.Service.JobSeeker;
using Domain.Service.Profile;
using Domain.Service.Profile.DTOs;
using Domain.Service.Profile.Interface;
using Domain.Service.SignUp.DTOs;
using HireMeNow_WebApi.API.JobProvider;
using HireMeNow_WebApi.API.JobSeeker.RequestObjects;
using HireMeNow_WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static MassTransit.ValidationResultExtensions;

namespace HireMeNow_WebApi.JobSeeker
{

    [ApiController]
    [Authorize(Roles = "JOB_SEEKER")]
    public class JobSeekerProfileController : BaseApiController<JobSeekerProfileController>

    {
        private readonly IJobSeekerProfileService _profileService;
        public IMapper mapper { get; set; }
        public JobSeekerProfileController(IJobSeekerProfileService profileService, IMapper _mapper)
        {
            mapper = _mapper;
            _profileService = profileService;
        }
        [HttpGet("{jobseekerId}/profile")]
        public async Task<IActionResult> GetJobSeekerProfile(Guid jobseekerId)
        {
            try
            {
                var profile = await _profileService.GetProfileAsync(jobseekerId);
                if (profile == null)
                {
                    return NotFound();
                }

                return Ok(profile);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("{jobseekerId}/profile/{profileId}/skills")]
        public async Task<IActionResult> AddSkillsToProfile(Guid jobseekerId, Guid profileId, [FromBody] List<Guid> skills)
        {
            try
            {
                await _profileService.AddSkillsToProfile(jobseekerId, profileId, skills);
                return Ok("Skills added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to add skills: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("{jobseekerId}/profile/{profileId}/Experience")]
        public async Task<ActionResult> AddExperienceToProfile(Guid jobseekerId, Guid profileId, WorkExperieceRequest data)
        {
            var JobseekerWorkExperienceDTo = mapper.Map<JobseekerWorkExperienceDTo>(data);
            await _profileService.AddWorkExpericeToProfileAsync(jobseekerId, profileId, JobseekerWorkExperienceDTo);
            return Ok(data);
        }

        [HttpPost]
        [Route("{jobseekerId}/profile/{profileId}/Qualification")]
        public async Task<ActionResult> AddQualificationToProfile(Guid jobseekerId, Guid profileId, QualificationRequest data)
        {
            var JobseekerQualificationDTo = mapper.Map<JobseekerQualificationDTo>(data);
            await _profileService.AddQualificationToProfileAsync(jobseekerId, profileId, JobseekerQualificationDTo);
            return Ok(data);
        }
        [HttpGet("{jobseekerId}/profiledetails")]
        public ActionResult<List<JobSeekerProfileDTo>> GetProfile(Guid jobseekerId)
        {
            var Profile = _profileService.GetProfile(jobseekerId);

            if (Profile == null || !Profile.Any())
                return NotFound();

            return Ok(Profile);


        }
        [HttpGet("{jobseekerId}/compleateprofile")]
        public async Task<IActionResult> GetcompleateProfile(Guid jobseekerId)
        {
            var Profile = _profileService.GetcompleateProfile(jobseekerId);

            if (Profile == null)
            {
                return NotFound(); // or return an appropriate response
            }
            return Ok(Profile);


        }

        [HttpGet]
        [Route("/profile/{profileId}/Qualification")]
        public ActionResult<List<JobseekerQualificationDTo>> GetQualification(Guid profileId)
        {
            var Qualification = _profileService.GetQualification(profileId);

            if (Qualification == null || !Qualification.Any())
                return NotFound();

            return Ok(Qualification);
        }

        [HttpGet]
        [Route("{jobseekerId}/profile/{profileId}/skills")]
        public ActionResult<List<SkillDto>> GetSkills(Guid jobseekerId, Guid profileId)
        {
            var skills = _profileService.GetSkillsForJobSeekerProfile(jobseekerId, profileId);

            if (skills == null || !skills.Any())
                return NotFound();

            return Ok(skills);
        }


        [HttpGet]
        [Route("{jobseekerId}/profile/{profileId}/Experince")]
        public ActionResult<List<ExperienceDto>> GetExperience(Guid jobseekerId, Guid profileId)
        {
            var Experience = _profileService.GetExperience(jobseekerId, profileId);

            if (Experience == null || !Experience.Any())
                return NotFound();

            return Ok(Experience);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("skills")]
        public ActionResult<List<SkillDto>> GetSkills()
        {
            var skills = _profileService.GetSkillsForJobSeekerProfile();

            if (skills == null || !skills.Any())
                return NotFound();

            return Ok(skills);
        }


        [HttpPut("UpdateJobSeekerProfile")]

        public async Task<IActionResult> UpdateJobSeekerProfile([FromForm] AuthUserDTO updatedProfile)
        {
            try
            {
                var result = await _profileService.UpdateJobSeekerProfile(updatedProfile);


                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("JobSeekerProfileUpdate")]

        public async Task<IActionResult> UpdateJobSeekerProfiles([FromForm] AuthUserDTO updatedProfile)
        {
            try
            {
                var result = await _profileService.UpdateJobSeekerProfile(updatedProfile);


                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //
        [HttpPost("AddProfile")]
        public async Task<IActionResult> AddProfile(JobseekerProfileRequest profileRequest)
        {
            var AddProfileDto = mapper.Map<ProfileDTO>(profileRequest);
            var addedProfile = await _profileService.AddProfileAsync(AddProfileDto);
            if (addedProfile)
                return Ok("Profile Added successfully");

            return BadRequest("Failed to Add Profile");
        }
        [HttpGet("GetJobSeekerProfile/{jobSeekerId}")]
        public async Task<IActionResult> GetProfilesByJobSeekerId(Guid jobSeekerId)
        {
            var profiles = await _profileService.GetProfilesByJobSeekerIdAsync(jobSeekerId);
            return Ok(profiles);
        }


    }
}
