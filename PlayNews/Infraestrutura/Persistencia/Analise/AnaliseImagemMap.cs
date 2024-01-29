using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlayNews.Dominio.Analises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Infraestrutura.Persistencia.Analise
{
    public class AnaliseImagemMap : IEntityTypeConfiguration<AnaliseImagem>
    {
        public void Configure(EntityTypeBuilder<AnaliseImagem> builder)
        {
            builder.Property(p => p.Id);

            builder.Property(p => p.IdAnalise);

            builder.Property(p => p.IdImagem);
        }
    }
}
