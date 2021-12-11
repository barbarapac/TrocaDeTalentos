using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Utfpr.Troca.De.Talentos.Domain.Usuario;
using Utfpr.Troca.De.Talentos.Domain.Usuario.Dtos;
using Utfpr.Troca.De.Talentos.Domain.Usuario.Extensions;
using Utfpr.Troca.De.Talentos.Domain.Usuario.Interfaces;

namespace Utfpr.Troca.De.Talentos.CommandStack.Usuarios.Commands.Handlers
{
    public class UsuarioCommandHandler : IRequestHandler<UsuarioCriacaoAutenticacaoCommand, UsuarioDto>
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        
        public UsuarioCommandHandler(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

       #region Criar usuário

        public async Task<UsuarioDto> Handle(UsuarioCriacaoAutenticacaoCommand request, CancellationToken cancellationToken)
        {
            var usuario = _mapper.Map<UsuarioDto, Usuario>(request.Usuario);
            var usuariojaCadastrado = await _usuarioRepository.VerificaSeUsuarioEstaCadastradoAsync(usuario?.Ra);
            
            if (!usuariojaCadastrado)
            {
                var validation = usuario.Validation();
                if (!validation.IsValid) throw new Exception(validation.ValidationResult.ToString());
                var result = await _usuarioRepository.SaveUsuarioAsync(usuario);
                return _mapper.Map<Usuario, UsuarioDto>(result);
            }
            
            return null;
        }

        private static void AutenticacaoUsuarioServerUtfAsync(UsuarioCriacaoAutenticacaoCommand request)
        {
            // Problemas de certificação SSL
            
            // var client = new RestClient("https://200.134.21.99/ldapauth/service/authenticate/");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);
            // var request1 = new RestRequest("resource/{id}");
            // request1.AddParameter("login", request.Email);
            // request1.AddParameter("password", request.Senha);
            // request1.AddHeader("Content-type", "application/json");
            //request.AddFile("file", path);
            // var response = client.Post(request1);
            // var content = response.Content; // Raw content as string
            // var response2 = client.Post<Person>(request);
            // var name = response2.Data.Name;
        }

        #endregion
       
    }
}
