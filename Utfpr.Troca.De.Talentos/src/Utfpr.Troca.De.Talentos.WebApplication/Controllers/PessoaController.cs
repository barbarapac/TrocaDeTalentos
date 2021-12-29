using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Utfpr.Troca.De.Talentos.CommandStack.Pessoa.Commands;
using Utfpr.Troca.De.Talentos.Domain.Pessoas.Dtos;
using Utfpr.Troca.De.Talentos.QueryStack.Pessoa;
using Utfpr.Troca.De.Talentos.Utils;

namespace Utfpr.Troca.De.Talentos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly ILogger<PessoaController> _logger;
        private readonly IMediator _mediator;
        private readonly IPessoaQuerie _pessoaQuerie;
        
        public PessoaController(ILogger<PessoaController> logger, IMediator mediator, IPessoaQuerie pessoaQuerie)
        {
            _logger = logger;
            _mediator = mediator;
            _pessoaQuerie = pessoaQuerie;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaDto>> GetPessoa(long id)
        {
            var result = await _pessoaQuerie.ObterPessoaPorIdAsync(id);

            if (result == null)
                return NotFound();

            return result;
        }

        /// <summary>
        /// Complementar cadastro
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PessoaDto>> ComplementarCadastro([FromBody] PessoaDto pessoa)
        {
            try
            {
                if (pessoa != null)
                {
                    PessoaDto result = await _mediator.Send(CriarPessoaCommand.Create(pessoa));
                    
                    return CreatedAtAction(
                        nameof(GetPessoa),
                        new { id = result.Id },
                        result);
                }
                
                return UnprocessableEntity(MessageErrors.PessoaInvalida);
            }
            catch (Exception)
            {
                return UnprocessableEntity(MessageErrors.ErroAoComplemenarCadastro);
            }
        }
        
        /// <summary>
        /// Atualizar cadastro
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<PessoaDto>> AtualizarCadastro([FromBody] PessoaDto pessoa)
        {
            try
            {
                if (pessoa != null)
                {
                    PessoaDto result = await _mediator.Send(AtualizarPessoaCommand.Create(pessoa));
                    
                    return CreatedAtAction(
                        nameof(GetPessoa),
                        new { id = result.Id },
                        result);
                }
                
                return UnprocessableEntity(MessageErrors.PessoaInvalida);
            }
            catch (Exception)
            {
                return UnprocessableEntity(MessageErrors.ErroAoAtualizaCadastro);
            }
        }
    }
}