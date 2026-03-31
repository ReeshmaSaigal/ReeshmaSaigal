using Domain.Helpers;
using Domain.Models;
using Domain.Service.JobProvider.Dtos;
using Domain.Service.JobProvider.Interfaces;
using HireMeNow_WebApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider
{
	public class InterviewService:IInterviewService
	{
		public InterviewService(IInterviewRepository _interviewRepository)
		{
			interviewRepository = _interviewRepository;
		}

		public IInterviewRepository interviewRepository { get; set; }
		public Interview sheduleinterview(InterviewsheduleDtos interview, CompanyUser userId)
		{
			return interviewRepository.shduleInterview(interview,userId);
		}
		public async Task<PagedList<Interview>> sheduledInterviewList(Guid companyid,InterviewParams param)
		{
			return await interviewRepository.sheduledInterviewList(companyid,param);
		}
		public bool removeInterview(Guid id)
		{
			return interviewRepository.removeInterview(id);
		}

	}
}
