using System.Threading.Tasks;
using Utfpr.Troca.De.Talentos.Domain.Usuario.Dtos;

namespace Utfpr.Troca.De.Talentos.QueryStack.Usuarios
{
    public interface IUsuarioQuerie
    {
        Task<UsuarioDto> ObterUsuarioPorIdAsync(long idUsuario);
    }
}