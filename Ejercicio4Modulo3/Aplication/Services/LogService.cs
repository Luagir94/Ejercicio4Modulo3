using Ejercicio4Modulo3.Domain.Contracts;
using Ejercicio4Modulo3.Domain.Entities;
using Ejercicio4Modulo3.Infrastructure.Repositories;

namespace Ejercicio4Modulo3.Aplication.Services;

public class LogService : ILogService
{
    private readonly LogRepository _logRepository;
    
    public LogService(LogRepository logRepository)
    {
        _logRepository = logRepository;
    }
    
    public Task<IEnumerable<Logs>> Get_Logs()
    {
        return _logRepository.Get_Logs();
    }

    public Task Add_Log(Logs logs)
    {
        return _logRepository.Add_Log(logs);
    }
}