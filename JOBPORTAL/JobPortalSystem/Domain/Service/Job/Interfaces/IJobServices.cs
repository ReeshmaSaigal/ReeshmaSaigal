

﻿using Domain.Helpers;
using Domain.Models;
using Domain.Service.Job.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Job.Interfaces
{
    public interface IJobServices
	{

        public Task<List<JobPostsDtos>> GetJobs(Guid userId);
		public Task<List<JobPostsDtos>> GetJobs();
		public Task<List<JobPost>> GetJobsByCompany(Guid companyId);

        public Task<List<JobPost>> GetJobsById(Guid companyId, Guid jobId);

  
		Task<PagedList<SavedJob>> GetAllSavedJobsOfSeeker(Guid jobseekerId, JobListParams param);

        Task<PagedList<AppliedJobsDtos>> GetAllAppliedJobs(Guid jobseekerId, JobListParams param);
        bool ApplyJob(JobApplication applyJob);
        bool CancelAppliedJob(Guid jobseekerId, Guid JobApplicationId);
        SavedJobsDtos GetsavedJobById(Guid jobseekerId, Guid SavedJobId);


        SavedJob RemoveSavedJob(Guid seekerId, Guid jobid);
		Task<SavedJob> saveJob(SavedJob savedJob);



	}

}
