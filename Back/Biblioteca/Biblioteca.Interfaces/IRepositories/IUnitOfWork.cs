﻿namespace Biblioteca.Interfaces.IRepositories;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}