using AutoMapper;
using rayna.Common.Entities;
using rayna.Common.model.Rayna;

namespace rayna.Persistence.MapperProfile;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<Event, AddEventDto>().ReverseMap();
        CreateMap<Event, EventResponse>().ReverseMap();
    }
}
