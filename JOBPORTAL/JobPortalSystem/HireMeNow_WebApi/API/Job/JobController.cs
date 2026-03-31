using AutoMapper;

using Domain.Models;
using Domain.Service.Job;
using Domain.Service.Job.DTOs;
using Domain.Service.Job.Interfaces;
using HireMeNow_WebApi.Controllers;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.Authuser.Interfaces;
using Domain.Service.Job.Interfaces;
using Domain.Service.SignUp.DTOs;
using HireMeNow_WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg;
using HireMeNow_WebApi.API.Job.SavedJobObjects;

using static System.Runtime.InteropServices.JavaScript.JSType;
using Domain.Service.SignUp.DTOs;
using HireMeNow_WebApi.Extensions;
using Domain.Service.Job.DTOs;
using Domain.Service.Job;
using Domain.Service.JobProvider.Dtos;
using Domain.Helpers;
using HireMeNow_WebApi.API.JobSeeker.RequestObjects;
using Domain.Enums;
using Domain.Service.User.Interface;

namespace HireMeNow_WebApi.API.Job
{
   /* [Route("api/[controller]")]*/
    [ApiController]
	[Authorize(Roles= "JOB_SEEKER")]
    public class JobController : BaseApiController<JobController>
    {
        private readonly IJobServices _jobService;
        private readonly IMapper _mapper;
        IJobRepository _jobRepository;
		IUserService _userService;

        private IMapper mapper;


        public JobController(IMapper mapper, IJobServices jobService, IJobRepository jobRepostory,IUserService userService)
        {
            _mapper = mapper;
            _jobService = jobService;
            _jobRepository = jobRepostory;
			_userService = userService;	

			
        }

        [HttpGet]
        [Route("jobs")]
		
        public async Task<IActionResult>  GetJobs()
        {
            try
            {
				var UserId = new Guid(_userService.GetUserId());

				List<JobPostsDtos> jobposts = await _jobService.GetJobs(UserId);
                return Ok(jobposts);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
       
        }

        [HttpGet]
        [Route("jobs/{companyId}")]
		[AllowAnonymous]
		public async Task<IActionResult> GetJobsByCompany(Guid companyId)
        {
            try
            {
                List<JobPost> jobposts = await _jobService.GetJobsByCompany(companyId);
                return Ok(_mapper.Map<List<JobPostsDtos>>(jobposts));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("company/{companyId}/jobs/{jobId}")]
		[AllowAnonymous]
		public async Task<IActionResult> GetJobsById(Guid companyId, Guid jobId)
        {
            try
            {
                List<JobPost> jobposts = await _jobService.GetJobsById(companyId,jobId);
                return Ok(_mapper.Map<List<JobPostsDtos>>(jobposts));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("job-seeker/savedjobs")]
        public async Task<IActionResult> savedjobs([FromQuery] JobListParams param)
        {
            var userId = new Guid(_userService.GetUserId());

            var savedJobs = await _jobService.GetAllSavedJobsOfSeeker(userId, param);

            Response.AddPaginationHeader(
                savedJobs.CurrentPage,
                savedJobs.PageSize,
                savedJobs.TotalCount,
                savedJobs.TotalPages
            );

            var savedjoblistdtos = _mapper.Map<PagedList<SavedJobsDtos>>(savedJobs);

            return Ok(savedjoblistdtos);
        }


        //[HttpGet]
        //[Route("job-seeker/{jobseekerId}/savedjobs/{savedJobId}")]
        //public ActionResult GetSavedJobs(Guid jobseekerId,Guid savedJobId)
        //{

        //	SavedJobsDtos savedJob =  _jobservice.GetsavedJobById(jobseekerId, savedJobId);
        //	if( savedJob!=null )
        //	{
        //	return Ok(savedJob);	
        //	}
        //	else
        //	{
        //		return NoContent();
        //	}
        //}
        [HttpDelete("job-seeker/remove-saved-job")]
        public IActionResult RemoveSavedJob(Guid seekerId, Guid jobId)
        {
            var savedJob = _jobService.RemoveSavedJob(seekerId, jobId);

            if (savedJob != null)
                return Ok("Removed");

            return NotFound();
        }



        [HttpGet]
		[Route("job-seeker/{jobseekerId}/job-application")]
		
		public async Task<ActionResult> getAllJobApplicationsOfUser(Guid jobseekerId, [FromQuery] JobListParams param)
		{
			var UserId = new Guid(_userService.GetUserId());
			var appliedJobs = await _jobService.GetAllAppliedJobs(UserId, param);
			Response.AddPaginationHeader(appliedJobs.CurrentPage, appliedJobs.PageSize, appliedJobs.TotalCount, appliedJobs.TotalPages);
			if (appliedJobs == null)
			{
				return BadRequest("No Applied Jobs");
			}
			return Ok(appliedJobs);
		}
		[HttpPost]
		[Route("job-seeker/job-application/{JobId}")]
		public async Task<IActionResult> applyJob(Guid JobId,Guid ResumeId,string CoverLetter)
		{
			ApplyJobRequest applyJobRequest = new ApplyJobRequest();
			var UserId = _userService.GetUserId();
			applyJobRequest.Applicant = new Guid(UserId);
			applyJobRequest.CoverLetter = CoverLetter;
			applyJobRequest.Resume_id=ResumeId;
			applyJobRequest.JobPost_id = JobId;
			var appliedJobs = _mapper.Map<JobApplication>(applyJobRequest);
			var status = _jobService.ApplyJob(appliedJobs);
			if (status == true)
			{
				return Ok(new { Message = "JobsApplied Succesfully" });
				
			}
			else
			{
				return BadRequest();
			}
		}
		[HttpPost]
		[Route("job-seeker/SaveJob/{JobId}")]
		public async Task<IActionResult> SaveJob(Guid JobId)
		{
			SaveJobRequest saveJobRequest = new SaveJobRequest();
			var UserId = new Guid(_userService.GetUserId());
			saveJobRequest.SavedBy=UserId;
			saveJobRequest.Job = JobId;

			var savedjob = _mapper.Map<SavedJob>(saveJobRequest);
			var savedJob = await _jobService.saveJob(savedjob);
			if (savedJob != null)
			{
				return Ok("JobsSaved Succesfully");
			}
			else
			{
				return BadRequest();
			}
		}
		[HttpDelete]
		[Route("job-seeker/{jobseekerId}/job-application/{JobApplicationId}/cancel")]
		public async Task<ActionResult> CancelAppliedJob(Guid jobseekerId, Guid JobApplicationId)
		{
			var UserId = new Guid(_userService.GetUserId());
			var status = _jobService.CancelAppliedJob(UserId, JobApplicationId);
			if (status == true)
			{
				return Ok(new { Message = "deleted" });
			
			}
			else
			{
				return NotFound();
			}
		}


	}

	}


