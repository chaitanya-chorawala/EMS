using ems.Common.Entities;
using ems.Common.Helper;
using ems.Common.model;
using ems.Common.model.Auth;
using ems.Common.model.Event;

namespace ems.Core.Contract.Repository
{
    public interface IEventRepo : IRepoBase<Event>
    {
        Task<PaginationResponse<EventResponse>> GetEvent(bool? isCompleted, string? searchingParams, SortingParams sortingParams);                        
        Task<FilePath> GetFilePath(string type);
        //Task<Event> GetEventById(int id);
        //Task<RegisterResponse> AddEvent(Event eve);
        //Task<RegisterResponse> UpdateEvent(Event eve);
        //Task<RegisterResponse> DeleteEvent(Event eve);
    }
}
