using Biblioteca.Entities.Pocos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Repository.EFCore.Configurations;

internal sealed class PrestamoConfiguration : IEntityTypeConfiguration<Prestamo>
{
    public void Configure(EntityTypeBuilder<Prestamo> builder)
    {
        builder.ToTable("prestamos");

        builder.HasKey(b => b.Id)
            .HasName("lista_negra_pk");

        builder.Property(b => b.IdClienteSolicitante)
            .HasColumnName("id_cliente_solicitante");

        builder.Property(b => b.IdLibro)
            .HasColumnName("id_libro");

        builder.Property(b => b.LibroCodigoBarra)
            .HasColumnName("libro_codigo_barras");

        builder.Property(b => b.IdEstadoPrestamo)
            .HasColumnName("id_estado_prestamo");

        builder.Property(b => b.FechaRegistro)
            .HasColumnName("fecha_registro");

        builder.Property(b => b.FlagEstado)
            .HasColumnName("flag_estado");

        builder.Property(b => b.FlagEliminado)
            .HasColumnName("flag_eliminado");
    }
}
