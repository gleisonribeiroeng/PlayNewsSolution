using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlayNews.Dominio.Jogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayNews.Dominio.Noticias;

namespace PlayNews.Infraestrutura.Persistencia.Noticias
{
    public class NoticiaImagemMap : IEntityTypeConfiguration<NoticiaImagem>
    {
        public void Configure(EntityTypeBuilder<NoticiaImagem> builder)
        {
            builder.Property(p => p.Id);

            builder.Property(p => p.IdNoticia);

            builder.Property(p => p.IdImagem);
        }
    }
}