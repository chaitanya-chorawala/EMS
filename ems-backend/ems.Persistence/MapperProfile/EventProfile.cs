using AutoMapper;
using ems.Common.Entities;
using ems.Common.model.Event;

namespace ems.Persistence.MapperProfile;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<Event, AddEventDto>().ReverseMap();
        CreateMap<Event, EventResponse>().ReverseMap();
    }
}
