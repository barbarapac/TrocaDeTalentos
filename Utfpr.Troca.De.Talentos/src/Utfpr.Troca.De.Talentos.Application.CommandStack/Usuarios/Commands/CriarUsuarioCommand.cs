using MediatR;
using Utfpr.Troca.De.Talentos.Domain.Usuario.Dtos;

namespace Utfpr.Troca.De.Talentos.CommandStack.Usuarios.Commands
{
    public class CriarUsuarioCommand : IRequest<UsuarioDto>
    {
        public UsuarioDto Usuario { get; set; }

        public static CriarUsuarioCommand Create(UsuarioDto usuario)
        {
            return new CriarUsuarioCommand
            {
                Usuario = usuario
            };
        }
    }
}