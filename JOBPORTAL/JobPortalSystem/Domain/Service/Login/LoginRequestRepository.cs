using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Service.Login.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Service.Login
{
    public class LoginRequestRepository : ILoginRequestRepository
    {
        protected readonly DbHireMeNowWebApiContext _context;
        public LoginRequestRepository(DbHireMeNowWebApiContext dbContext)
        {
            _context = dbContext;
        }

        public AuthUser GetUserByEmail(string email)
        {
            var user= _context.AuthUsers.FirstOrDefault(e => e.Email == email);
            return user;
        }
	

		public AuthUser GetUserByEmailpassword(string email, string password)
		{
			var user = _context.AuthUsers.FirstOrDefault(e => e.Email == email && e.Password == password);
			return user;
		}
}
    }
