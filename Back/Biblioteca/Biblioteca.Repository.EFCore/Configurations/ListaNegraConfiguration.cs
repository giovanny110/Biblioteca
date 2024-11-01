using Biblioteca.Entities.Pocos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Repository.EFCore.Configurations;

internal sealed class ListaNegraConfiguration : IEntityTypeConfiguration<ListaNegra>
{
    public void Configure(EntityTypeBuilder<ListaNegra> builder)
    {
        builder.ToTable("lista_negra");

        builder.HasKey(b => b.IdCliente)
            .HasName("prestamos_pk");

        builder.Property(b => b.IdCliente)
            .HasColumnName("id_cliente");
    }
}
