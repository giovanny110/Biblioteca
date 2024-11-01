using Biblioteca.Entities.Enumerations;
using Biblioteca.Entities.Pocos;
using Biblioteca.Interfaces.IRepositories;
using Biblioteca.Repository.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repository.EFCore.Repositories;

internal sealed class PrestamosRepository : IPrestamosRepository
{
    private readonly BibliotecaDbContext _context;

    public PrestamosRepository(BibliotecaDbContext context) => _context = context;

    public void Add(Prestamo entity)
    {
        _context.Prestamos.Add(entity);
    }

    public async Task<int> GetNumberBookBorrowdByCustomer(int clienteId, CancellationToken cancellationToken)
    {
        var availableStates = new List<int>() { (int)LoanStatus.PENDIENTE, (int)LoanStatus.DEVUELTO, (int)LoanStatus.RECHAZADO };

        return await _context.Prestamos
                                    .CountAsync(x => x.IdClienteSolicitante == clienteId
                                            && !availableStates.Contains(x.IdEstadoPrestamo)
                                            && x.FlagEstado
                                            && !x.FlagEliminado,
                                            cancellationToken);
    }
}
