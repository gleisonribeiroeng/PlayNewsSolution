using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlayNews.Dominio.Detonados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Infraestrutura.Persistencia.Detonado
{
    public class DetonadoImagemMap : IEntityTypeConfiguration<DetonadoImagem>
    {
        public void Configure(EntityTypeBuilder<DetonadoImagem> builder)
        {
            builder.Property(p => p.Id);

            builder.Property(p => p.IdDetonado);

            builder.Property(p => p.IdImagem);
        }
    }
}
