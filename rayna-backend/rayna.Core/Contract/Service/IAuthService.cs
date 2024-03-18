using rayna.Common.Entities;
using rayna.Common.Helper;
using rayna.Common.model;
using rayna.Common.model.Auth;

namespace rayna.Core.Contract.Service;

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
