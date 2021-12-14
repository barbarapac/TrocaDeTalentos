using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Utfpr.Troca.De.Talentos.CommandStack.Usuarios.Commands;
using Utfpr.Troca.De.Talentos.Domain.Usuario.Dtos;
using Utfpr.Troca.De.Talentos.QueryStack.Usuarios;
using Utfpr.Troca.De.Talentos.Utils;

namespace Utfpr.Troca.De.Talentos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IMediator _mediator;
        private readonly IUsuarioQuerie _usuarioQuerie;

        public UsuarioController(ILogger<UsuarioController> logger, IMediator mediator, IUsuarioQuerie usuarioQuerie)
        {
            _logger = logger;
            _mediator = mediator;
            _usuarioQuerie = usuarioQuerie;
        }
        
        /// <summary>
        /// Obter usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> GetUsuario(long id)
        {
            var result = await _usuarioQuerie.ObterUsuarioPorIdAsync(id);

            if (result == null)
                return NotFound();

            return result;
        }
        
        /// <summary>
        /// Criar usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> CadastrarUsuario([FromBody] UsuarioDto usuario)
        {
            try
            {
                if (usuario != null)
                {
                    UsuarioDto result = await _mediator.Send(CriarUsuarioCommand.Create(usuario));
                    
                    return CreatedAtAction(
                        nameof(GetUsuario),
                        new { id = result.Id },
                        result);
                }
                
                return UnprocessableEntity(MessageErrors.UsuarioInvalido);
            }
            catch (Exception)
            {
                return UnprocessableEntity(MessageErrors.ErroAoCadastrarUsuario);
            }
        }
    }
}