namespace Biblioteca.Entities.Pocos;

public class DetalleLibro
{
    public int IdLibro { get; set; }

    public string CodigoBarra { get; set; } = string.Empty;

    public bool Estado { get; set; }

    public bool FlagEliminado { get; set; }

    public int IdEstadoLibro { get; set; }
}