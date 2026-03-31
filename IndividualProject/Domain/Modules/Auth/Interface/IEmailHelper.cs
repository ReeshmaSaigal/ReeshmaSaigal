using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Auth.Interface
{
    public interface IEmailHelper
    {
        Task SendAsync(string toEmail, string subject, string body);
    }

}
