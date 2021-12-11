using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Utfpr.Troca.De.Talentos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExempleController : ControllerBase
    {
        private readonly ILogger<ExempleController> _logger;

        public ExempleController(ILogger<ExempleController> logger)
        {
            _logger = logger;
        }
        
        /// <summary>
        /// Inserir usuário
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> InserirUsuario(string json)
        {
            try
            {
                return "de boa";
            }
            catch (Exception e)
            {
                return "error";
            }
        }
    }
}