using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.Admin.Interfaces;
using Domain.Service.Job.DTOs;
using Domain.Service.Profile.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MassTransit.ValidationResultExtensions;
using Domain.Service.Admin.DTOs;

namespace Domain.Service.Admin
{
    public class AdminServices : IAdminServices
    {
        IAdminRepository _adminRepository;
        IMapper _mapper;

        public AdminServices(IAdminRepository adminRepository, IMapper mapper)


        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }
        public async Task<List<Domain.Models.JobSeeker>> GetJobSeekers()
        {
            return await _adminRepository.GetJobSeekers();
        }

        public async Task<List<JobProviderCompany>> GetCompanies()
        {
            return await _adminRepository.GetCompanies();
        }

        public async Task<List<CompanyUser>> GetCompanyUsers()
        {
            return await _adminRepository.GetCompanyUsers();
        }

        public async Task<List<Industry>> GetIndustries()
        {
            return await _adminRepository.GetIndustries();
        }

        public async Task<List<Location>> GetLocations()
        {
            return await _adminRepository.GetLocations();
        }

        public async Task<List<JobCategory>> GetCategories()
        {
            return await _adminRepository.GetCategories();
        }

        public async Task<List<JobPost>> GetJobs()
        {
            return await _adminRepository.GetJobs();
        }
        public void DeleteById(Guid id)
        {
            _adminRepository.DeleteById(id);
        }

        public void DeleteByLocationId(Guid id)
        {
            _adminRepository.DeleteByLocationId(id);
        }

        public void DeleteByCategoryId(Guid id)
        {
            _adminRepository.DeleteByCategoryId(id);
        }
        public void DeleteCompaniesById(Guid id)
        {
            _adminRepository.DeleteCompaniesById(id);
        }
        public void DeleteByIndustryId(Guid id)
        {
            _adminRepository.DeleteByIndustryId(id);
        }

        public int GetCompanyCount()
        {
            return _adminRepository.GetCompanyCount();
        }

        public int GetJobProviderCount()
        {
            return _adminRepository.GetJobProviderCount();
        }

        public int GetJobCount()
        {
            return _adminRepository.GetJobCount();
        }
        public async Task<List<JobPost>> GetJobs(string JobLitle)
        {

            var jobs = await _adminRepository.GetJobs(JobLitle);

            return jobs;


        }


        public Task<List<JobProviderCompany>> SearchCompanies(string name)
        {
            return _adminRepository.SearchCompanies(name);
        }



        public async Task<SkillDto> AddSkillAsync(SkillDto skill)
        {
            var Skill = _mapper.Map<Skill>(skill);
            var result = await _adminRepository.AddAsync(Skill);

            return _mapper.Map<SkillDto>(result);
        }


        public async Task<SkillDto> RemoveSkillAsync(Guid skillId)
        {
            var result = await _adminRepository.RemoveAsync(skillId);

            return _mapper.Map<SkillDto>(result);
        }

        public Task<Industry> AddIndustry(Industry industry)
        {
            return _adminRepository.addIndustry(industry);
        }

        public Task<JobCategory> AddCategory(JobCategory category)
        {
            return _adminRepository.addCategory(category);
        }

        public Task<Location> AddLocation(Location location)
        {
            return _adminRepository.addLocation(location);
        }

    }
}
