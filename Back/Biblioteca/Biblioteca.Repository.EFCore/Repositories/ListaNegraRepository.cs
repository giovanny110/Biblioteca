using Biblioteca.Interfaces.IRepositories;
using Biblioteca.Repository.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repository.EFCore.Repositories;

internal sealed class ListaNegraRepository : IListaNegraRepository
{
    private readonly BibliotecaDbContext _context;

    public ListaNegraRepository(BibliotecaDbContext context) => _context = context;

    public async Task<bool> CheckExist(int clienteId, CancellationToken cancellationToken)
    {
        return await _context.ListaNega
                                    .AnyAsync(x => x.IdCliente == clienteId
                                    , cancellationToken);
    }
}
