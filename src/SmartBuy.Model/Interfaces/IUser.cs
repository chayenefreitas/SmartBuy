using System.Collections.Generic;
using System.Security.Claims;

namespace SmartBuy.Core.Interfaces
{
    public interface IUser
    {
        string Id { get; }
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
