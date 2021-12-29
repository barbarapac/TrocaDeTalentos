using MediatR;
using Utfpr.Troca.De.Talentos.Domain.Pessoas.Dtos;

namespace Utfpr.Troca.De.Talentos.CommandStack.Pessoa.Commands
{
    public class CriarPessoaCommand : IRequest<PessoaDto>
    {
        public PessoaDto Pessoa { get; set; }
        
        public static CriarPessoaCommand Create(PessoaDto pessoa)
        {
            return new CriarPessoaCommand
            {
                Pessoa = pessoa
            };
        }
    }
}