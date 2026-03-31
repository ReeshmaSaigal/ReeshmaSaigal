using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.Admin.DTOs;
using Domain.Service.Admin.Interfaces;
using Domain.Service.Job;
using Domain.Service.Job.DTOs;
using Domain.Service.Job.Interfaces;
using Domain.Service.Login;
using Domain.Service.Login.Interfaces;
using Domain.Service.Profile.DTOs;
using HireMeNow_WebApi.API.Admin.RequestObjects;
using HireMeNow_WebApi.API.JobSeeker.RequestObjects;
using HireMeNow_WebApi.Controllers;
using HireMeNow_WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow_WebApi.API.Admin
{
    /* [Route("api/[controller]")]*/
    [ApiController]
    public class AdminController : BaseApiController<AdminController>
    {
        private readonly IAdminServices _adminService;
        private readonly IMapper _mapper;
        IAdminRepository _adminRepository;
        private IMapper mapper;
        public ILoginRequestService _loginRequestService;
        IJobServices _jobService;

        public AdminController(IMapper mapper, IAdminServices adminService, IAdminRepository adminRepostory, ILoginRequestService loginRequestService,IJobServices jobServices)
        {
            _mapper = mapper;
            _adminService = adminService;
            _adminRepository = adminRepostory;
            _loginRequestService = loginRequestService;
			_jobService = jobServices;
        }



        [HttpPost]
        [Route("Admin/login")]
        public async Task<ActionResult> Login(AdminLoginRequests logdata)
        {
            //var user = _mapper.Map<User>(userDto);
            var user = _loginRequestService.Adminlogin(logdata.Email, logdata.Password);

            if (user == null)
            {
                return BadRequest("Login Failed");
            }
            return Ok(user);
        }

        [HttpGet]
        [Route("admin/GetJobSeekers")]
        public async Task<IActionResult> GetJobSeekers()
        {

            try
            {
                var jobSeekers = await _adminService.GetJobSeekers();
                return Ok(_mapper.Map<List<JobSeekerDto>>(jobSeekers));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }


        [HttpPost("skillAdd")]
        public async Task<IActionResult> AddSkill( SkillRequest skill)
        {
            // Map the request to DTO

            var Skill = _mapper.Map<SkillDto>(skill);
          
            // Call the service
            var result = await _adminService.AddSkillAsync(Skill);

            if (result!=null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Skill already exists");
            }
        }

        [HttpDelete("skillRemove/{skillId}")]
        public async Task<IActionResult> RemoveSkill(Guid skillId)
        {
            // Call the service
            var result = await _adminService.RemoveSkillAsync(skillId);

            if (result!=null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Skill not found or failed to delete");
            }
        }

        [HttpGet]
        [Route("admin/GetCompanies")]
        public async Task<IActionResult> GetCompanies()
        {

            try
            {
                var jobProviders = await _adminService.GetCompanies();
                return Ok(_mapper.Map<List<JobProviderDto>>(jobProviders));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        //New-Code

        [HttpGet]
        [Route("admin/SearchCompanies")]
        public async Task<IActionResult> SearchCompanies(string name)
        {

            try
            {

                var companies = await _adminService.SearchCompanies(name);
                return Ok(_mapper.Map<List<JobProviderDto>>(companies));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        //New-Code Ends

        [HttpGet]
        [Route("admin/GetCompanyUsers")]
        public async Task<IActionResult> GetCompanyUsers()
        {

            try
            {
                var companyUsers = await _adminService.GetCompanyUsers();
                return Ok(_mapper.Map<List<CompanyUsersDto>>(companyUsers));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
		[HttpGet]
		[Route("admin/jobsbyName")]
		public async Task<IActionResult> getalljobs(string Title)
		{

			try
			{
				var jobs = await _adminService.GetJobs(Title);
				return Ok(_mapper.Map<List<Joblist>>( jobs));
			}
			catch (Exception ex)
			{
				return BadRequest();
			}

		}
		[HttpGet]
		[Route("alljobs")]
        public async Task<IActionResult> alljobs()
        {

            try
            {
                var jobs = await _adminService.GetJobs();
                return Ok(_mapper.Map<List<Joblist>>(jobs));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }




        [HttpDelete]
        [Route("admin/RemoveCompanyUsers/{id}")]
        public IActionResult Remove(Guid id)
        {
            try
            {
                _adminService.DeleteById(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpDelete]
        [Route("admin/RemoveCompanies/{id}")]
        public IActionResult RemoveCompanies(Guid id)
        {
            try
            {
                _adminService.DeleteCompaniesById(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }


        [HttpGet]
        [Route("admin/GetCompanyCount")]
        public IActionResult GetCompanyCount()
        {
            try
            {
                var count = _adminService.GetCompanyCount();
                return Ok(new { Count = count });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("admin/GetJobProviderCount")]
        public IActionResult GetJobProviderCount()
        {
            try
            {
                var count = _adminService.GetJobProviderCount();
                return Ok(new { Count = count });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("admin/GetJobCount")]
        public IActionResult GetJobCount()
        {
            try
            {
                var count = _adminService.GetJobCount();
                return Ok(new { Count = count });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }


        [HttpPost("AddIndustry")]
        public async Task<IActionResult> AddIndustry(IndustryRequest Industry)
        {
            var industry = _mapper.Map<Industry>(Industry);
            var result = await _adminService.AddIndustry(industry);

            return Ok(result);
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(CategoryRequest category)
        {
            var Category = _mapper.Map<JobCategory>(category);
            var result = await _adminService.AddCategory(Category);

            return Ok(result);
        }

        [HttpPost("AddLocation")]
        public async Task<IActionResult> AddLocation(LocationRequest location)
        {
            var Location = _mapper.Map<Location>(location);
            var result = await _adminService.AddLocation(Location);

            return Ok(result);
        }

        [HttpGet("GetIndustries")]
        public async Task<IActionResult> GetIndustries()
        {

            try
            {
                var industries = await _adminService.GetIndustries();
                return Ok(_mapper.Map<List<Industry>>(industries));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpGet("GetLocations")]
        public async Task<IActionResult> GetLocations()
        {

            try
            {
                var locations = await _adminService.GetLocations();
                return Ok(_mapper.Map<List<LocationDto>>(locations));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {

            try
            {
                var categories = await _adminService.GetCategories();
                return Ok(_mapper.Map<List<JobCategory>>(categories));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpDelete]
        [Route("RemoveLocations/{id}")]
        public IActionResult RemoveLocation(Guid id)
        {
            try
            {
                _adminService.DeleteByLocationId(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpDelete]
        [Route("RemoveCategory/{id}")]
        public IActionResult RemoveCategory(Guid id)
        {
            try
            {
                _adminService.DeleteByCategoryId(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }


        [HttpDelete]
        [Route("RemoveIndustry/{id}")]
        public IActionResult RemoveIndustry(Guid id)
        {
            try
            {
                _adminService.DeleteByIndustryId(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

    }

}
