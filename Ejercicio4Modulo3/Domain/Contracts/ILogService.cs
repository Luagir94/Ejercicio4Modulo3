using Ejercicio4Modulo3.Domain.Entities;

namespace Ejercicio4Modulo3.Domain.Contracts;

public interface ILogService
{
    
    public Task<IEnumerable<Logs>> Get_Logs();
    
    public Task Add_Log(Logs logs);
}