using System.Threading.Tasks;

namespace Utfpr.Troca.De.Talentos.Domain.Usuario.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<bool> VerificaSeUsuarioEstaCadastradoAsync(string ra);
        Task<Usuario> SaveUsuarioAsync(Domain.Usuario.Usuario usuario);
        Task<Usuario> ObterUsuarioPorIdAsync(long idUsuario);
    }
}