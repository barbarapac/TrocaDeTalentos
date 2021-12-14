using AutoMapper;
using Utfpr.Troca.De.Talentos.Domain.Pessoas.Dtos;
using Utfpr.Troca.De.Talentos.Domain.Usuario;
using Utfpr.Troca.De.Talentos.Domain.Usuario.Dtos;

namespace Utfpr.Troca.De.Talentos.CommandStack.Pessoa.Profiles
{
    public class PessoaDtoToPessoaProfile : Profile
    {
        public PessoaDtoToPessoaProfile()
        {
            CreateMap<UsuarioDto, Usuario>();
            
            CreateMap<PessoaDto, Domain.Pessoas.Pessoa>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(x => x.IdUsuario))
                .ForMember(dest => dest.Curso, opt => opt.MapFrom(x => x.Curso))
                .ForMember(dest => dest.Campus, opt => opt.MapFrom(x => x.Campus))
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(x => x.Cidade))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(x => x.Estado))
                .ForMember(dest => dest.FotoPerfil, opt => opt.MapFrom(x => x.FotoPerfil))
                .ReverseMap();
        }
    }
}