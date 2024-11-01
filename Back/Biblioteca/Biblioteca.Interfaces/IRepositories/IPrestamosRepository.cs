using Biblioteca.Entities.Pocos;

namespace Biblioteca.Interfaces.IRepositories;

public interface IPrestamosRepository
{
    Task<int> GetNumberBookBorrowdByCustomer(int clienteId, CancellationToken cancellationToken);

    void Add(Prestamo entity);
}