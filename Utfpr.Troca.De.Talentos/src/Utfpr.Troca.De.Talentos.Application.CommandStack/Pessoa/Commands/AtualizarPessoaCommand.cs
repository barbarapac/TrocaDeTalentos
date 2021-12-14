using MediatR;
using Utfpr.Troca.De.Talentos.Domain.Pessoas.Dtos;

namespace Utfpr.Troca.De.Talentos.CommandStack.Pessoa.Commands
{
    public class AtualizarPessoaCommand : IRequest<PessoaDto>
    {
        public PessoaDto Pessoa { get; set; }
        
        public static AtualizarPessoaCommand Create(PessoaDto pessoa)
        {
            return new AtualizarPessoaCommand
            {
                Pessoa = pessoa
            };
        }
    }
}