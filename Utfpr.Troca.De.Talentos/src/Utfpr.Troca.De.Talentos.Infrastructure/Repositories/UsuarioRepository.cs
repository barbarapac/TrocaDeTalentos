using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Utfpr.Troca.De.Talentos.Domain.Pessoas;
using Utfpr.Troca.De.Talentos.Domain.Usuario;
using Utfpr.Troca.De.Talentos.Domain.Usuario.Interfaces;

namespace Utfpr.Troca.De.Talentos.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly TrocaTalentosContext _dbContext;
        
        public UsuarioRepository(TrocaTalentosContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<bool> VerificaSeUsuarioEstaCadastradoAsync(string ra)
        {
            try
            {
                return await _dbContext.Usuario.AnyAsync(x => x.Ra.Equals(ra));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Usuario> SaveUsuarioAsync(Usuario usuario)
        {
            await _dbContext.Usuario.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> ObterUsuarioPorIdAsync(long IdUsuario) => 
            await _dbContext.Usuario.FirstOrDefaultAsync(x => x.Id.Equals(IdUsuario));
    }
}