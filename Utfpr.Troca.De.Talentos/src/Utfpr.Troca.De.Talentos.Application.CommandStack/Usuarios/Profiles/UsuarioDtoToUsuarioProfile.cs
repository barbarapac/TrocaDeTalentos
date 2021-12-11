using AutoMapper;
using Utfpr.Troca.De.Talentos.Domain.Pessoas;
using Utfpr.Troca.De.Talentos.Domain.Usuario;
using Utfpr.Troca.De.Talentos.Domain.Usuario.Dtos;

namespace Utfpr.Troca.De.Talentos.CommandStack.Usuarios.Profiles
{
    public class UsuarioDtoToUsuarioProfile : Profile
    {
        public UsuarioDtoToUsuarioProfile()
        {
            CreateMap<UsuarioDto, Usuario>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.Ra, opt => opt.MapFrom(x => x.Ra))
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(x => x.Senha))
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(x => x.Tipo))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();
        }
    }
}