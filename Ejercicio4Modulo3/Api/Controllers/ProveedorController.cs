using Ejercicio4Modulo3.Aplication.Dto;
using Ejercicio4Modulo3.Domain.Contracts;
using Ejercicio4Modulo3.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio4Modulo3.Controllers
{
    [Route("api/proveedor")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {

        // Correr el script para tener los datos de la BD
        // Se debe crear con la arquitectura en capas( el controller y services) para poder unicamente dar de alta un proveedor y recuperar todos los proveedores
        // Todas las peticiones tienen que ser async
        // Crear un middleware personalizado, que grabe en base de datos en la tabla logs cada interaccion que exista con los endpoints expuestos:
            // Si hay un error en la peticion se debe grabar success = false  sino success = true
            // para completar los datos de path y verbo http deben usar los metodos/propiedades
            // de la variable "context" que se disponibiliza al implementar IMiddleware

            private IProveedorService _proveedorService;
            
            
            public ProveedorController(IProveedorService context)
            {
                _proveedorService = context;
            }
            
            
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            public async Task<IActionResult> AddProveedor([FromBody] ProveedorDto proveedorDto)
            {
                await _proveedorService.Add_Proveedor(new Proveedor
                {
                    cod_proveedor = proveedorDto.cod_proveedor,
                    razon_social = proveedorDto.razon_social
                });
                return NoContent();
            }

            [HttpGet]
            public async Task<IActionResult> GetProveedores()
            {
               
                return Ok(await _proveedorService.Get_Proveedores());
            }
    }
}
