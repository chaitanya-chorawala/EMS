using ems.Common.Entities;
using ems.Common.Helper;
using ems.Common.model;
using ems.Common.model.Auth;

namespace ems.Core.Contract.Service;

public interface IAuthService
{
    Task<LoginResponse> Login(Login model);
    Task<RegisterResponse> Register(Register model);
    Task<RegisterResponse> UpdateRegistration(int id, RegisterDto model);
    Task<LoginResponse> RefreshToken(LoginResponse model);
    Task<PaginationResponse<RegistrationResponse>> UserList(string? searchingParams,SortingParams sortingParams);
    Task<RegistrationResponse> GetUser(int userid);
    Task<RegisterResponse> DeleteRegistration(int id);
}
