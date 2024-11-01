using Biblioteca.Entities.Pocos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Repository.EFCore.Configurations;

internal sealed class DetalleLibroConfiguration : IEntityTypeConfiguration<DetalleLibro>
{
    public void Configure(EntityTypeBuilder<DetalleLibro> builder)
    {
        builder.ToTable("detalle_libros");

        builder.HasKey(b => new { b.IdLibro, b.CodigoBarra })
            .HasName("detalle_libros_pk");

        builder.Property(b => b.IdLibro)
            .HasColumnName("id_libro");

        builder.Property(b => b.CodigoBarra)
            .HasColumnType("char(15)")
            .HasColumnName("codigo_barras");

        builder.Property(b => b.Estado)
            .HasColumnName("flag_estado");

        builder.Property(b => b.FlagEliminado)
            .HasColumnName("flag_eliminado");

        builder.Property(b => b.IdEstadoLibro)
            .HasColumnName("id_estado_libro");
    }
}
