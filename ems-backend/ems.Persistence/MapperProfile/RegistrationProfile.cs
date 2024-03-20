using AutoMapper;
using ems.Common.Entities;
using ems.Common.model.Auth;

namespace ems.Persistence.MapperProfile
{
    public class RegistrationProfile : Profile
    {
        public RegistrationProfile()
        {
            CreateMap<Register, Registration>();
            CreateMap<RegisterDto, Registration>();
        }
    }
}
