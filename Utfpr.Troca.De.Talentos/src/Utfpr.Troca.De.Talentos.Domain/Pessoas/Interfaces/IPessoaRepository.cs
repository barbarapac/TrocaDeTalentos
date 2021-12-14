using System.Threading.Tasks;

namespace Utfpr.Troca.De.Talentos.Domain.Pessoas.Interfaces
{
    public interface IPessoaRepository
    {
        Task<Pessoa> SavePessoaAsync(Pessoa pessoa);
        Task<Pessoa> ObterPessoaPorIdAsync(long idPessoa);
        Task<bool> VerificaExistePessoaAsyc(long idPessoa);
        Task<Pessoa> UpdatePessoaAsync(Pessoa pessoa);
    }
}