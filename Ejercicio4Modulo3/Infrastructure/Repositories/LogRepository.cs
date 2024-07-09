using Ejercicio4Modulo3.Data;
using Ejercicio4Modulo3.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio4Modulo3.Infrastructure.Repositories;

public class LogRepository
{
    
    private readonly ApplicationDbContext _context;
    
    
    public LogRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<IEnumerable<Logs>> Get_Logs()
    {
        return await _context.Logs.ToListAsync();
    }
    
    public async Task Add_Log(Logs logs)
    {
        _context.Logs.Add(logs);
        await _context.SaveChangesAsync();
    }
    
    
}