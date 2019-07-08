using AutoMapper;
using Desafio.Domain;
using Desafio.WebAPI.Dtos;

namespace Desafio.WebAPI.Helpers
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