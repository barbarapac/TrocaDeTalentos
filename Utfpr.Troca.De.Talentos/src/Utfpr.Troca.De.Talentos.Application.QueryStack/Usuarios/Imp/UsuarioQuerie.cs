using System.Threading.Tasks;
using AutoMapper;
using Utfpr.Troca.De.Talentos.Domain.Usuario;
using Utfpr.Troca.De.Talentos.Domain.Usuario.Dtos;
using Utfpr.Troca.De.Talentos.Domain.Usuario.Interfaces;

namespace Utfpr.Troca.De.Talentos.QueryStack.Usuarios.Imp
{
    public class UsuarioQuerie : IUsuarioQuerie
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        
        public UsuarioQuerie(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        
        public async Task<UsuarioDto> ObterUsuarioPorIdAsync(long idUsuario)
        {
            var usuario = await _usuarioRepository.ObterUsuarioPorIdAsync(idUsuario);
            if (usuario != null)
                return _mapper.Map<Usuario, UsuarioDto>(usuario);

            return null;
        }
    }
}