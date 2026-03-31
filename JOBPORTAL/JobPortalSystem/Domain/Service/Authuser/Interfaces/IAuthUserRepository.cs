using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Authuser.Interfaces
{
    public interface IAuthUserRepository
    {
        Task<AuthUser> AddAuthUser(AuthUser authUser);

        Task<AuthUser> AddAuthUserJP(AuthUser authUser);
        string? CreateToken(AuthUser user);
        CompanyUser GetUser(Guid userid);
        Task AddUserConnectionIdAsync(string email, string ConnectionId);
        AuthUser GetUserByConnectionId(string connectionId);
        Task<AuthUser> GetAuthUserByUserEmail(string user);
        void DisconnectUserByConnectionId(string connectionId);
        Task<AuthUser> GetAuthUserByUserId(Guid value);
        //Task<AuthUser> getUserByEmail(string? from);
    }
}
