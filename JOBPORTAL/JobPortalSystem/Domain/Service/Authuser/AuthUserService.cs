
using Domain.Models;
using Domain.Service.Authuser.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Service.Authuser
{
	public class AuthUserService:IAuthUserService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IAuthUserRepository _userRepository;

		public AuthUserService(IHttpContextAccessor httpContextAccessor,IAuthUserRepository userRepository)
		{
			_httpContextAccessor = httpContextAccessor;
			_userRepository = userRepository;
		}

		public string GetUserId()
		{
			var result = string.Empty;
			if (_httpContextAccessor.HttpContext != null)
			{
				result = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Sid).Value.ToString();
			}
			return result;
		}
		public CompanyUser GetUser(Guid userid)
		{
			return _userRepository.GetUser(userid);
		}
	}
}
