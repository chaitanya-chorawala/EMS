using AutoMapper;
using rayna.Common.Entities;
using rayna.Common.model.Auth;

namespace rayna.Persistence.MapperProfile
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
