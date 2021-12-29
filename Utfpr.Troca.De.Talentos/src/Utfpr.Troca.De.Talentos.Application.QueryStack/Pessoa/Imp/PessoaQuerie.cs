using System.Threading.Tasks;
using AutoMapper;
using Utfpr.Troca.De.Talentos.Domain.Pessoas.Dtos;
using Utfpr.Troca.De.Talentos.Domain.Pessoas.Interfaces;

namespace Utfpr.Troca.De.Talentos.QueryStack.Pessoa.Imp
{
    public class PessoaQuerie : IPessoaQuerie
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;
        
        public PessoaQuerie(IPessoaRepository pessoaRepository, IMapper mapper)
        {
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
        }
        public async Task<PessoaDto> ObterPessoaPorIdAsync(long idPessoa)
        {
            var usuario = await _pessoaRepository.ObterPessoaPorIdAsync(idPessoa);
            if (usuario != null)
                return _mapper.Map<Domain.Pessoas.Pessoa, PessoaDto>(usuario);

            return null;
        }
    }
}