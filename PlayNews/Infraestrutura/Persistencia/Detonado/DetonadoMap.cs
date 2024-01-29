using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlayNews.Dominio.Noticias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Dominio.Detonados
{
    public class DetonadoMap : IEntityTypeConfiguration<Detonado>
    {
        public void Configure(EntityTypeBuilder<Detonado> builder)
        {
            builder.Property(p => p.Id);

            builder.Property(p => p.Titulo);

            builder.Property(p => p.SubTitulo);

            builder.Property(p => p.Ativo);

            builder.Property(p => p.Manchete);

            builder.Property(p => p.Corpo);

            builder.HasOne(p => p.Jogo)
                .WithOne()
                .HasForeignKey<Detonado>(n => n.IdJogo);

            builder.HasOne(p => p.Usuario)
                .WithOne()
                .HasForeignKey<Detonado>(n => n.IdUsuario);

        }
    }
}