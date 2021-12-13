using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Utfpr.Troca.De.Talentos.Domain.Areas.Dtos;

namespace Utfpr.Troca.De.Talentos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AreaController: ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;   
        
        public AreaController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Listar todas as areas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IList<AreaDto>> GetAll()
        {
            return null;
        } 
    }
}