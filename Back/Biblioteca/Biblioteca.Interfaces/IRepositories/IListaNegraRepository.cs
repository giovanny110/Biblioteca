namespace Biblioteca.Interfaces.IRepositories;

public interface IListaNegraRepository
{
    Task<bool> CheckExist(int clienteId, CancellationToken cancellationToken);
}