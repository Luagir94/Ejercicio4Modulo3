using Ejercicio4Modulo3.Domain.Contracts;
using Ejercicio4Modulo3.Domain.Entities;
using Ejercicio4Modulo3.Infrastructure.Repositories;

namespace Ejercicio4Modulo3.Aplication.Services;

public class ProveedorService : IProveedorService
{
    private readonly ProveedorRepository _proveedorRepository;
    
    public ProveedorService(ProveedorRepository proveedorRepository)
    {
        _proveedorRepository = proveedorRepository;
    }
    
    
    public Task<IEnumerable<Proveedor>> Get_Proveedores()
    {
        return _proveedorRepository.Get_Proveedores();
    }

    public Task Add_Proveedor(Proveedor proveedor)
    {
        return _proveedorRepository.Add_Proveedor(proveedor);
    }
}