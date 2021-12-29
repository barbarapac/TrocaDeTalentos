using System.Threading.Tasks;
using Utfpr.Troca.De.Talentos.Domain.Pessoas.Dtos;

namespace Utfpr.Troca.De.Talentos.QueryStack.Pessoa
{
    public interface IPessoaQuerie
    {
        Task<PessoaDto> ObterPessoaPorIdAsync(long idPessoa);
    }
}