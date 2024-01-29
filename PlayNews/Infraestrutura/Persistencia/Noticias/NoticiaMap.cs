using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Dominio.Noticias
{
    public class NoticiaMap : IEntityTypeConfiguration<Noticia>
    {
        public void Configure(EntityTypeBuilder<Noticia> builder)
        {
            builder.Property(p => p.Id);

            builder.Property(p => p.Titulo);

            builder.Property(p => p.SubTitulo);

            builder.Property(p => p.Ativo);

            builder.Property(p => p.Manchete);

            builder.Property(p => p.Corpo);

            builder.HasOne(p => p.Jogo)
                .WithOne()
                .HasForeignKey<Noticia>(n => n.IdJogo);

            builder.HasOne(p => p.Usuario)
                .WithOne()
                .HasForeignKey<Noticia>(n => n.IdUsuario);

        }
    }
}