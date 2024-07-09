using Ejercicio4Modulo3.Domain.Entities;

namespace Ejercicio4Modulo3.Domain.Contracts;

public interface IProveedorService
{
    
    public Task<IEnumerable<Proveedor>> Get_Proveedores();
    
    public Task Add_Proveedor(Proveedor proveedor);
    
    
}