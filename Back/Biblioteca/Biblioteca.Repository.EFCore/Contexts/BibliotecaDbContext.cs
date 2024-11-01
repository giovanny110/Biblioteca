using Biblioteca.Entities.Pocos;
using Biblioteca.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repository.EFCore.Contexts;

public class BibliotecaDbContext : DbContext, IUnitOfWork
{
    public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options) { }

    #region DbSets
    public virtual DbSet<ListaNegra> ListaNega { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<DetalleLibro> DetalleLibros { get; set; }
    #endregion

    #region Metodos 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BibliotecaDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    #endregion
}
