using rayna.Common.model;
using System.Security.Claims;

namespace rayna.Core.Contract.Common;

public interface IClaimPrincipalAccessor
{
    ClaimsPrincipal? ClaimsPrincipal { get; }
    User User { get; }
}
