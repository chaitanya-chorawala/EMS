using rayna.Common.Entities;
using rayna.Common.Helper;
using rayna.Common.model;
using rayna.Common.model.Auth;
using rayna.Common.model.Rayna;

namespace rayna.Core.Contract.Service
{
    public interface IEventService
    {
        Task<PaginationResponse<EventResponse>> GetEvent(string? searchingParams, SortingParams sortingParams, bool? isCompleted);
        Task<RegisterResponse> AddEventAsync(AddEventDto addEventDto);
        Task<RegisterResponse> UpdateEventAsync(int id, AddEventDto addEventDto);
        Task<RegisterResponse> DeleteEventAsync(int id);
        Task<EventResponse> GetEventByIdAsync(int id);
    }
}
