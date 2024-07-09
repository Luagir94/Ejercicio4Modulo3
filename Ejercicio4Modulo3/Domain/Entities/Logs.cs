namespace Ejercicio4Modulo3.Domain.Entities;

public class Logs
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string Path { get; set; }
    public string Method { get; set; }
    public bool Success { get; set; }
}