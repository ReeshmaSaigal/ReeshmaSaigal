using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Service.Login.DTOs;

namespace Domain.Service.Login.Interfaces
{
    public interface ILoginRequestService
    {

        JobSeekerLoginDto login(string email, string password);

        AdminLoginDTO Adminlogin(string email, string password);
    }
}
