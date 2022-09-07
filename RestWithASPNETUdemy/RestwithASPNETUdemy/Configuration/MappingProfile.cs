using AutoMapper;
using RestwithASPNETUdemy.Models;

namespace RestwithASPNETUdemy.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonRequest, PersonModel>();
        }
    }
}
