

using Domain.Helpers;
using Domain.Models;
using Domain.Service.Job.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Job.Interfaces
{
	public interface IJobRepository
	{

        Task<List<JobPost>> GetJobs(Guid userId);
		Task<List<JobPost>> GetJobs();
		Task<List<JobPost>> GetJobsByCompany(Guid companyId);

        Task<List<JobPost>> GetJobsById(Guid companyId, Guid jobId);

		Task<PagedList<SavedJob>> GetAllSavedJobsOfSeeker(Guid jobseekerId,JobListParams param);
		Task<PagedList<JobApplication>> GetAllAppliedJobs(Guid jobseekerId,JobListParams param);

		SavedJob RemoveSavedJob(Guid seekerId, Guid jobid);
		bool applyjob(JobApplication applyjob);
		bool CancelAppliedJob(Guid jobseekerId, Guid JobApplicationId);
		 SavedJob GetsavedJobById(Guid jobseekerId, Guid SavedJobId);
		Task<SavedJob> saveJob(SavedJob savedJob);
        bool SavedJobs(Guid jobId, Guid userId);
        Guid? GetSavedJobId(Guid jobId, Guid userId);

    }

}
