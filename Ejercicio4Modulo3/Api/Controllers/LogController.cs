using Ejercicio4Modulo3.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio4Modulo3.Controllers
{
    [Route("api/log")]
    [ApiController]
    public class LogController : ControllerBase
    {

        private ILogService _logService;


        public LogController(ILogService context)
        {
            _logService = context;
        }



        [HttpGet]
        public async Task<IActionResult> GetProveedores()
        {

            return Ok(await _logService.Get_Logs());
        }
    }
    
}