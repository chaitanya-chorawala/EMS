using rayna.Common.Entities;
using rayna.Common.Helper;
using rayna.Common.model;
using rayna.Common.model.Auth;

namespace rayna.Core.Contract.Repository;

public interface IUserRepo
{
    Task<RegisterResponse> RegisterAsync(Registration model);
    Task<RegisterResponse> UpdateRegistration(Registration registration);
    Task<User> LoginAsync(Login model);
    Task<string> VerifyRefreshTokenAsync(int userid, string refreshToken);
    Task UpdateRefreshTokenAsync(int userid, string refreshToken);
    Task<RegistrationResponse> GetUserDetail(int userid);
    Task<int> GetUserEmail(string emailId, int? id);
    Task<Registration> GetRegistrationById(int id);
    Task<PaginationResponse<RegistrationResponse>> GetUserList(string? searchingParams,SortingParams sortingParams);
    Task<RegisterResponse> DeleteRegistration(int id);
}
