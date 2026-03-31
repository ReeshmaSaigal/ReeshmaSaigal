using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Modules.Auth.Interface
{
    public interface IJwtHelper
    {
        string GenerateJwtToken(AppUser user);
    }
}
