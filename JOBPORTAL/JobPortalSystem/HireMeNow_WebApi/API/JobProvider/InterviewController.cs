using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.Authuser.Interfaces;
using Domain.Service.Job.DTOs;
using Domain.Service.JobProvider.Dtos;
using Domain.Service.JobProvider.Interfaces;
using HireMeNow_WebApi.API.JobProvider.RequestObjects;
using HireMeNow_WebApi.Extensions;
using HireMeNow_WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow_WebApi.API.JobProvider
{
	[Route("api/v1/[controller]")]
	[ApiController]
  	[Authorize(Roles = "COMPANY_USER")]
	public class InterviewController : ControllerBase

	{
		public InterviewController(IMapper _mapper,IInterviewService _interviewService,IAuthUserService _authUserService)
		{
			mapper = _mapper;
			interviewService = _interviewService;
			authUserService = _authUserService;
		}
		public IAuthUserService authUserService { get; set; }
		public IMapper mapper { get; set; }
		public IInterviewService interviewService { get; set; }
		[AllowAnonymous]
        [HttpPost]
        [Route("company/company-user/{companyuserid}/Interview")]
        public async Task<ActionResult> SheduleInterview(
    [FromBody] InterviewSheduleObject interviewSheduleObject,
    Guid companyuserid)
        {
            //var userId = authUserService.GetUserId();
            var user = authUserService.GetUser(companyuserid);
			if (user == null)
			{
				return BadRequest("No User");
			}

			var interviewDto = mapper.Map<InterviewsheduleDtos>(interviewSheduleObject);

			Interview interview=interviewService.sheduleinterview(interviewDto, user);

			return Ok();




		}
		[AllowAnonymous]
		[HttpGet]
		[Route("company/company-user/{companyid}/Interviewlist")]
		public async Task<ActionResult> SheduledInterviewList( Guid companyid, [FromQuery] InterviewParams param)
		{
			//var user = authUserService.GetUser(companyuserid);
			//if (user == null)
			//{
			//	return BadRequest("No User");
			//}
			PagedList<Interview> sheduledinterview = await interviewService.sheduledInterviewList(companyid, param);
			Response.AddPaginationHeader(sheduledinterview.CurrentPage, sheduledinterview.PageSize, sheduledinterview.TotalCount, sheduledinterview.TotalPages);
			var sheduledinerviewDto= mapper.Map<PagedList<SheduledInterviewDto>>(sheduledinterview);
			if (sheduledinerviewDto == null)
			{
				return NoContent();
			}
			else
			{
				return Ok(sheduledinerviewDto);
			}



		}
		[AllowAnonymous]
		[HttpDelete]
		[Route("company/company-user/{intererviewid}/cancel")]
		public async Task<ActionResult> cancelInterview(Guid intererviewid)
		{
			var result=interviewService.removeInterview(intererviewid);	
			if(result==true)
                return Ok(new { message = "Deleted successfully" });

            return NotFound();
        }
	}
	
}
