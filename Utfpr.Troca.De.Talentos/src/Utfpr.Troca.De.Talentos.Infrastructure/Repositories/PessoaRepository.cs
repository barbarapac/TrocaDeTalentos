using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Utfpr.Troca.De.Talentos.Domain.Pessoas;
using Utfpr.Troca.De.Talentos.Domain.Pessoas.Interfaces;

namespace Utfpr.Troca.De.Talentos.Infrastructure.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly TrocaTalentosContext _dbContext;

        public PessoaRepository(TrocaTalentosContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Pessoa> SavePessoaAsync(Pessoa pessoa)
        {
            try
            {
                await _dbContext.Pessoa.AddAsync(pessoa);
                await _dbContext.SaveChangesAsync();
                return pessoa;
            }
            catch (Exception)
            {
                throw new Exception(MessageErrors.ErroAoSalvarPessoa);
            }
        }

        public async Task<Pessoa> ObterPessoaPorIdAsync(long idPessoa) => 
            await _dbContext.Pessoa.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Id.Equals(idPessoa));

        public async Task<bool> VerificaExistePessoaAsyc(long idPessoa) => 
            await _dbContext.Pessoa.AnyAsync(x => x.Id.Equals(idPessoa));

        public async Task<Pessoa> UpdatePessoaAsync(Pessoa pessoa)
        {
            try
            {
                _dbContext.Pessoa.Update(pessoa);
                await _dbContext.SaveChangesAsync();
                return pessoa;
            }
            catch (Exception)
            {
                throw new Exception(MessageErrors.ErroAoAtualizarPessoa);
            }
        }
    }
}