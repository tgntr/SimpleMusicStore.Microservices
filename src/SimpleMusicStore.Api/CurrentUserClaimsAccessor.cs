using Microsoft.AspNetCore.Http;
using SimpleMusicStore.Contracts.Auth;
using System.Security.Claims;

namespace SimpleMusicStore.Api
{
    public class CurrentUserClaimsAccessor : IClaimAccessor
    {
        private readonly ClaimsPrincipal _claims;

        public CurrentUserClaimsAccessor(IHttpContextAccessor http)
        {
            _claims = http.HttpContext.User;
        }

        public int Id => int.Parse(FindClaim(ClaimTypes.NameIdentifier));
        private string FindClaim(string type) => _claims.FindFirstValue(type);
    }
}
