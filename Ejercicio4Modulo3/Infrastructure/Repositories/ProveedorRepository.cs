using Ejercicio4Modulo3.Data;
using Ejercicio4Modulo3.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio4Modulo3.Infrastructure.Repositories;

public class ProveedorRepository
{
    
    private readonly ApplicationDbContext _context;
    
    
    public ProveedorRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<IEnumerable<Proveedor>> Get_Proveedores()
    {
        return await _context.Proveedor.ToListAsync();
    }
    
    public async Task Add_Proveedor(Proveedor proveedor)
    {
        _context.Proveedor.Add(proveedor);
        await _context.SaveChangesAsync();
    }
}