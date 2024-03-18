using rayna.Common.Entities;
using rayna.Common.Helper;
using rayna.Common.model;
using rayna.Common.model.Auth;
using rayna.Common.model.Rayna;

namespace rayna.Core.Contract.Repository
{
    public interface IEventRepo
    {
        Task<PaginationResponse<EventResponse>> GetEvent(bool? isCompleted, string? searchingParams, SortingParams sortingParams);
        Task<string> GetComplainNo();
        Task<ServiceConfiguration> GetMailConfiguration();
        Task<FormatConfiguration> GetMailFormate(string? type, string? status);
        Task<FilePath> GetFilePath(string type);
        Task<RegisterResponse> AddEvent(Event rayna);
    }
}
