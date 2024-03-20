using ems.Common.model;
using System.Security.Claims;

namespace ems.Core.Contract.Common;

public interface IClaimPrincipalAccessor
{
    ClaimsPrincipal? ClaimsPrincipal { get; }
    User User { get; }
}
