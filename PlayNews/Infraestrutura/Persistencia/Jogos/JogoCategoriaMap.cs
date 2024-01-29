using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlayNews.Dominio.Jogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Infraestrutura.Persistencia.Jogos
{
    public class JogoCategoriaMap : IEntityTypeConfiguration<JogoCategoria>
    {
        public void Configure(EntityTypeBuilder<JogoCategoria> builder)
        {
            builder.HasNoKey();

            builder.Property(p => p.IdJogo);

            builder.Property(p => p.IdCategoria);
        }
    }
}