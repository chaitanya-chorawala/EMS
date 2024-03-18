using rayna.Common.model;
using rayna.Common.model.Auth;
using System.Security.Claims;

namespace rayna.Core.Contract.Common;

public interface ITokenGenerator
{
    Task<LoginResponse> GenerateTokenAsync(User user);
    Task<LoginResponse> RegenerateTokenAsync(LoginResponse model);
}
