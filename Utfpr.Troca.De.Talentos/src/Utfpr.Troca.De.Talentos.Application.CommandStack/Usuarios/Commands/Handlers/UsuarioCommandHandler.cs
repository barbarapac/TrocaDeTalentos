using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Utfpr.Troca.De.Talentos.CommandStack.Utils;
using Utfpr.Troca.De.Talentos.Domain.Usuario;
using Utfpr.Troca.De.Talentos.Domain.Usuario.Dtos;
using Utfpr.Troca.De.Talentos.Domain.Usuario.Extensions;
using Utfpr.Troca.De.Talentos.Domain.Usuario.Interfaces;

namespace Utfpr.Troca.De.Talentos.CommandStack.Usuarios.Commands.Handlers
{
    public class UsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, UsuarioDto>
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        
        public UsuarioCommandHandler(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

       #region Criar usuário

        public async Task<UsuarioDto> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = _mapper.Map<UsuarioDto, Usuario>(request.Usuario);
            var usuariojaCadastrado = await _usuarioRepository.VerificaSeUsuarioEstaCadastradoAsync(usuario?.Ra);
            
            if (!usuariojaCadastrado)
            {
                var validation = usuario.Validation();
                if (!validation.IsValid) throw new Exception(validation.ValidationResult.ToString());
                try
                {
                    var result = await _usuarioRepository.SaveUsuarioAsync(usuario);
                    return _mapper.Map<Usuario, UsuarioDto>(result);
                }
                catch (Exception)
                {
                    throw new Exception(MessageErrors.UsuarioJaCadastro);
                }
            }

            throw new Exception(MessageErrors.UsuarioJaCadastro);
        }

        #endregion
       
    }
}
