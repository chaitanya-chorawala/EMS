using ems.Common.Entities;
using ems.Common.Helper;
using ems.Common.model;
using ems.Common.model.Auth;
using ems.Common.model.Event;

namespace ems.Core.Contract.Service
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
