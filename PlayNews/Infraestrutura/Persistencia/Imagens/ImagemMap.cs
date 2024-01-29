using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlayNews.Dominio.Noticias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayNews.Dominio.Imagens;

namespace PlayNews.Infraestrutura.Persistencia.Imagens
{
    public class ImagemMap : IEntityTypeConfiguration<Imagem>
    {
        public void Configure(EntityTypeBuilder<Imagem> builder)
        {
            builder.Property(p => p.Id);

            builder.Property(p => p.Nome);

            builder.Property(p => p.Data);
        }
    }
}