using ems.Common.model;
using ems.Common.model.Auth;
using System.Security.Claims;

namespace ems.Core.Contract.Common;

public interface ITokenGenerator
{
    Task<LoginResponse> GenerateTokenAsync(User user);
    Task<LoginResponse> RegenerateTokenAsync(LoginResponse model);
}
