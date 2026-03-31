using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.Admin.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Domain.Service.Admin
{
    public class AdminRepository : IAdminRepository
    {
        private readonly List<Domain.Models.JobSeeker> _jobSeeker;
        DbHireMeNowWebApiContext _context;
        IMapper _mapper;

        public AdminRepository(DbHireMeNowWebApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Domain.Models.JobSeeker>> GetJobSeekers()
        {
            return await _context.JobSeekers.ToListAsync();
        }

        public async Task<List<JobProviderCompany>> GetCompanies()
        {
            return await _context.JobProviderCompanies.ToListAsync();
        }

        public async Task<List<CompanyUser>> GetCompanyUsers()
        {
            return await _context.CompanyUsers.ToListAsync();
        }

        public void DeleteById(Guid id)
        {
            var item = _context.CompanyUsers.Where(e => e.Id == id).FirstOrDefault();
            if (item != null)
            {
                _context.CompanyUsers.Remove(item);
                _context.SaveChanges();
            }
        }

        public void DeleteByLocationId(Guid id)
        {
            var item = _context.Locations.Where(e => e.Id == id).FirstOrDefault();
            if (item != null)
            {
                _context.Locations.Remove(item);
                _context.SaveChanges();
            }
        }

        public void DeleteCompaniesById(Guid id)
        {
            var item = _context.JobProviderCompanies.Where(e => e.Id == id).FirstOrDefault();
            if (item != null)
            {
                _context.JobProviderCompanies.Remove(item);
                _context.SaveChanges();
            }
        }
        public void DeleteByCategoryId(Guid id)
        {
            var item = _context.JobCategories.Where(e => e.Id == id).FirstOrDefault();
            if (item != null)
            {
                _context.JobCategories.Remove(item);
                _context.SaveChanges();
            }
        }

        public void DeleteByIndustryId(Guid id)
        {
            var item = _context.Industries.Where(e => e.Id == id).FirstOrDefault();
            if (item != null)
            {
                _context.Industries.Remove(item);
                _context.SaveChanges();
            }
        }
        public int GetCompanyCount()
        {
            int count = _context.JobProviderCompanies.Count();
            return count;
        }

        public int GetJobProviderCount()
        {
            int count = _context.CompanyUsers.Count();
            return count;
        }

        public int GetJobCount()
        {
            int count = _context.JobPosts.Count();
            return count;
        }
        public async Task<List<JobPost>> GetJobs(string JobLitle)
        {


            return _context.JobPosts.Where(e => e.JobTitle.Contains(JobLitle)).ToList();

        }
        public async Task<List<JobPost>> GetJobs()
        {

            /*            return _context.JobPosts.ToList();*/
            return await _context.JobPosts
                    .Include(j => j.Location) 
                    .Include(j => j.Industry) 
                    .Include(j => j.JobCategory)
                    .Include(j => j.PostedByNavigation)
                    .ToListAsync();
        }


        public async Task<List<JobProviderCompany>> SearchCompanies(string name)

        {
            var filteredCompanies = await _context.JobProviderCompanies
           .Where(company => company.LegalName.Contains(name))
           .ToListAsync();

            return filteredCompanies;
        }

        public async Task<Skill> AddAsync(Skill skill)
        {
            if (skill == null)
                throw new ArgumentNullException(nameof(skill));
            if (_context.Skills.Any(s => s.Name == skill.Name))
            {
                throw new Exception("Skill already exists"); // Skill with the same name already exists
            }
            skill.Id = Guid.NewGuid();
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return skill; // Skill added successfully
        }

        public async Task<Skill> RemoveAsync(Guid skillId)
        {
            var skillToRemove = await _context.Skills.FindAsync(skillId);

            if (skillToRemove == null)
            {
                throw new ArgumentNullException(nameof(skillToRemove));
            }

            _context.Skills.Remove(skillToRemove);
            await _context.SaveChangesAsync();

            return skillToRemove; // Skill removed successfully
        }

        public async Task<Industry> addIndustry(Industry industry)
        {
            await _context.Industries.AddAsync(industry);
            await _context.SaveChangesAsync();
            return industry;
        }

        public async Task<JobCategory> addCategory(JobCategory category)
        {
            await _context.JobCategories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }


        public async Task<Location> addLocation(Location location)
        {
            location.Id = Guid.NewGuid();
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<List<Industry>> GetIndustries()
        {
            return await _context.Industries.ToListAsync();
        }


        public async Task<List<Location>> GetLocations()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<List<JobCategory>> GetCategories()
        {
            return await _context.JobCategories.ToListAsync();
        }
    }
}
