using ems.Common.model;
using ems.Core.Contract.Common;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ems.Persistence.Common;

class ClaimPrincipalAccessor : IClaimPrincipalAccessor
{
    private readonly HttpContext? _httpContext;

    public ClaimPrincipalAccessor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContext = httpContextAccessor.HttpContext;
    }
    public ClaimsPrincipal? ClaimsPrincipal => _httpContext?.User;

    public User User => new User()
    {
        FullName = ClaimsPrincipal?.Claims?.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault()?.Value,
        Email = ClaimsPrincipal?.Claims?.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault()?.Value,
        Role = ClaimsPrincipal?.Claims?.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault()?.Value,
        Id = Int16.Parse(ClaimsPrincipal?.Claims?.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault()?.Value),
    };
}
