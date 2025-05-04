using Microsoft.AspNetCore.Http;
using SmartBuy.Core.Interfaces;
using System.Security.Claims;

namespace SmartBuy.Core.Entities
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Id => _accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        public string Name => _accessor.HttpContext.User.Identity.Name;

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
