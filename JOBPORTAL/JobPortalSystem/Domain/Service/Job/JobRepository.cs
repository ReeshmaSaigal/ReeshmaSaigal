
using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.Job.DTOs;
using Domain.Service.Job.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Domain.Service.Job
{
    public class JobRepository : IJobRepository
    {

        DbHireMeNowWebApiContext _context;
        IMapper _mapper;
        static List<JobPost> joblist;

        public JobRepository(DbHireMeNowWebApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<PagedList<JobApplication>> GetAllAppliedJobs(Guid jobseekerId, JobListParams param)
        {
            try
            {
                var query = _context.JobApplications.AsQueryable().Where(e => e.Applicant == jobseekerId).Include(e => e.JobPost).Include(e => e.JobPost.Company);


                return await PagedList<JobApplication>.CreateAsync(query,
                    param.PageNumber, param.PageSize);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<JobPost>> GetJobs(Guid userId)
        {

            try
            {

                List<JobPost> jobs = await _context.JobPosts.Include(e => e.Location).Include(e => e.Industry).Include(e => e.Company).Include(e => e.PostedByNavigation).Include(e => e.JobCategory).ToListAsync();

                List<JobPost> applied = await _context.JobApplications.Where(e => e.Applicant == userId).Select(e => e.JobPost).ToListAsync();

                List<JobPost> notApplied = jobs.Except(applied).ToList();

                return notApplied;
                

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
		public async Task<List<JobPost>> GetJobs()
		{

            try
            {
                var jobs=await _context.JobPosts.Include(e => e.Location).Include(e => e.Industry).Include(e => e.Company).Include(e => e.PostedByNavigation).Include(e => e.JobCategory).ToListAsync();
                return jobs;
            }


			
			catch (Exception ex)
			{
				throw ex;

			}
		}


        public bool SavedJobs(Guid jobId, Guid userId)
        {
            return _context.SavedJobs
                .Any(e => e.Job == jobId && e.SavedBy == userId);
        }


        public async Task<List<JobPost>> GetJobsByCompany(Guid companyId)
        {
            /*   return await _context.JobPosts.Include(j => j.Company== companyId).ToListAsync();*/
            return await _context.JobPosts.Where(e => e.CompanyId == companyId).ToListAsync();
        }


        public async Task<List<JobPost>> GetJobsById(Guid companyId, Guid jobId)
        {
            return await _context.JobPosts.Where(e => e.CompanyId == companyId && e.Id == jobId).ToListAsync();
        }



        public async Task<PagedList<SavedJob>> GetAllSavedJobsOfSeeker(Guid jobseekerId, JobListParams param)
        {

            var query = _context.SavedJobs
              .OrderByDescending(c => c.DateSaved).Where(e => e.SavedBy == jobseekerId).Include(e => e.JobPost).AsQueryable();
            return await PagedList<SavedJob>.CreateAsync(query,
            param.PageNumber, param.PageSize);
        }



        public async Task<SavedJob> saveJob(SavedJob savedJob)
        {
            await _context.SavedJobs.AddAsync(savedJob);
            await _context.SaveChangesAsync();
            return savedJob;
        }
        public bool applyjob(JobApplication applyjob)
        {
            applyjob.status = Enums.Status.PENDING;
            _context.JobApplications.Add(applyjob);
            _context.SaveChanges();
            return true;

        }
        public bool CancelAppliedJob(Guid jobseekerId, Guid JobApplicationId)
        {
            try
            {
                var AppliedJob = _context.JobApplications.Where(e => e.Id == JobApplicationId).FirstOrDefault();
                if (AppliedJob != null)
                {
                    _context.JobApplications.Remove(AppliedJob);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }



        public SavedJob RemoveSavedJob(Guid seekerId, Guid jobid)
        {
            var savedjob = _context.SavedJobs
                .FirstOrDefault(e => e.SavedBy == seekerId && e.Job == jobid);

            if (savedjob == null)
                throw new Exception("Saved job not found");

            _context.SavedJobs.Remove(savedjob);
            _context.SaveChanges();

            return savedjob;
        }
        public SavedJob GetsavedJobById(Guid jobseekerId, Guid SavedJobId)
        {
            throw new NotImplementedException();
        }

        public Guid? GetSavedJobId(Guid jobId, Guid userId)
        {
            return _context.SavedJobs
                .Where(e => e.Job == jobId && e.SavedBy == userId)
                .Select(e => (Guid?)e.Id)
                .FirstOrDefault();
        }
    }

}

