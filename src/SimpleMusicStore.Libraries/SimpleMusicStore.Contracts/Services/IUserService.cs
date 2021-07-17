using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMusicStore.Contracts.Services
{
    public interface IUserService
    {
        Task Add(ClaimsPrincipal user);
    }
}
