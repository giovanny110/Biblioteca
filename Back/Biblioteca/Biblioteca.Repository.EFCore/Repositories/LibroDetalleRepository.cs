using Biblioteca.Entities.Enumerations;
using Biblioteca.Entities.Pocos;
using Biblioteca.Interfaces.IRepositories;
using Biblioteca.Repository.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repository.EFCore.Repositories;

internal sealed class LibroDetalleRepository : ILibroDetalleRepository
{
    private readonly BibliotecaDbContext _context;

    public LibroDetalleRepository(BibliotecaDbContext context) => _context = context;

    public async Task<DetalleLibro?> GetBookAvailable(int libroId, CancellationToken cancellationToken)
    {
        return await _context.DetalleLibros
                                        .FirstOrDefaultAsync(x => x.IdLibro == libroId
                                                        && x.IdEstadoLibro == (int)StateBook.Disponible
                                                        && x.Estado
                                                        && !x.FlagEliminado,
                                                        cancellationToken);
    }
}
