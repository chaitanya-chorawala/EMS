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
        Task<FilePath> GetFilePath(string type);
        Task<Event> GetEventById(int id);
        Task<RegisterResponse> AddEvent(Event eve);
        Task<RegisterResponse> UpdateEvent(Event eve);
        Task<RegisterResponse> DeleteEvent(Event eve);
    }
}
