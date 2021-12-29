using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Utfpr.Troca.De.Talentos.CommandStack.Utils;
using Utfpr.Troca.De.Talentos.Domain.Pessoas.Dtos;
using Utfpr.Troca.De.Talentos.Domain.Pessoas.Interfaces;

namespace Utfpr.Troca.De.Talentos.CommandStack.Pessoa.Commands.Handlers
{
    public class PessoaCommandHandler : IRequestHandler<CriarPessoaCommand, PessoaDto>,
        IRequestHandler<AtualizarPessoaCommand, PessoaDto>
    {
        private readonly IMapper _mapper;
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaCommandHandler(IMapper mapper, IPessoaRepository pessoaRepository)
        {
            _mapper = mapper;
            _pessoaRepository = pessoaRepository;
        }

        #region Criar pessoa
        
        public async Task<PessoaDto> Handle(CriarPessoaCommand request, CancellationToken cancellationToken)
        {
            var pessoa = _mapper.Map<PessoaDto, Domain.Pessoas.Pessoa>(request.Pessoa);

            if (pessoa.UsuarioId == default) throw new Exception(MessageErrors.UsuarioInvalido);

            // criar validator
            var result = await _pessoaRepository.SavePessoaAsync(pessoa);
            return _mapper.Map<Domain.Pessoas.Pessoa, PessoaDto>(result);
        }
        
        #endregion

        #region Atualizar pessoa

        public async Task<PessoaDto> Handle(AtualizarPessoaCommand request, CancellationToken cancellationToken)
        {
            var pessoa = _mapper.Map<PessoaDto, Domain.Pessoas.Pessoa>(request.Pessoa);
            var existePessoa = await _pessoaRepository.VerificaExistePessoaAsyc(request.Pessoa.Id);

            if (!existePessoa) throw new Exception(MessageErrors.PessoaNaoEncontrada);
            
            var result = await _pessoaRepository.UpdatePessoaAsync(pessoa);
            return _mapper.Map<Domain.Pessoas.Pessoa, PessoaDto>(result);
        }

        #endregion
    }
}