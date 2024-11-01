namespace Biblioteca.Entities.Pocos;

public class Prestamo
{
    public int Id { get; set; }

    public int IdClienteSolicitante { get; set; }

    public int IdLibro { get; set; }

    public string LibroCodigoBarra { get; set; } = string.Empty;

    public int IdEstadoPrestamo { get; set; }

    public DateTime FechaRegistro { get; set; }

    public bool FlagEstado { get; set; }

    public bool FlagEliminado { get; set; }
}