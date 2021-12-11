using MediatR;
using Utfpr.Troca.De.Talentos.Domain.Usuario.Dtos;

namespace Utfpr.Troca.De.Talentos.CommandStack.Usuarios.Commands
{
    public class UsuarioCriacaoAutenticacaoCommand : IRequest<UsuarioDto>
    {
        public UsuarioDto Usuario { get; set; }

        public static UsuarioCriacaoAutenticacaoCommand Create(UsuarioDto usuario)
        {
            return new UsuarioCriacaoAutenticacaoCommand
            {
                Usuario = usuario
            };
        }
    }
}