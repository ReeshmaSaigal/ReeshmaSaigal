using Domain.Helpers;
using Domain.Models;
using Domain.Service.JobProvider.Dtos;
using HireMeNow_WebApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider.Interfaces
{
	public interface IInterviewService
	{
		Interview sheduleinterview(InterviewsheduleDtos interview, CompanyUser userId);
		Task<PagedList<Interview>> sheduledInterviewList(Guid companyid, InterviewParams param);
		bool removeInterview(Guid id);
	
	}
}
