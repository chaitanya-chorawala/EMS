using AutoMapper;
using rayna.Common.Entities;
using rayna.Common.model.Rayna;

namespace rayna.Persistence.MapperProfile;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<AddEventDto, Event>();
        CreateMap<Event, EventResponse>();
    }
}
