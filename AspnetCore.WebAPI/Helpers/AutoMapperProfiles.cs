using AutoMapper;
using AspnetCore.Domain;
using AspnetCore.WebAPI.Dtos;

namespace AspnetCore.WebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Contato, ContatoDto>()
                .ForMember(dest => dest.Canal, opt => {
                    opt.MapFrom(src => src.Canal.ToString());
                }).ReverseMap();
        }
    }
}