using Ejercicio4Modulo3.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio4Modulo3.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Logs> Logs { get; set; }
    public DbSet<Proveedor> Proveedor { get; set; }
}