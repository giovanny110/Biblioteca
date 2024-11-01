using Biblioteca.Entities.Pocos;

namespace Biblioteca.Interfaces.IRepositories;

public interface ILibroDetalleRepository
{
    Task<DetalleLibro?> GetBookAvailable(int libroId, CancellationToken cancellationToken);
}