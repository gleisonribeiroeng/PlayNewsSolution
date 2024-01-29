using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MrgGameNews;
using PlayNews.Aplicacao.Noticia;
using PlayNews.Dominio.Noticias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Infraestrutura.Persistencia.Noticias
{
    public class ExecutorConsultaNoticia : IRequestHandler<ConsultaNoticia, List<ConsultaNoticiaResultado>>
    {
        private readonly PlayNewsContext dbContext;
        private readonly IMapper mapper;
        public ExecutorConsultaNoticia(PlayNewsContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public Task<List<ConsultaNoticiaResultado>> Handle(ConsultaNoticia request, CancellationToken cancellationToken)
        {
            var noticias = this.mapper.Map<List<ConsultaNoticiaResultado>>(this.dbContext.Set<Noticia>().ToList());
            return Task.FromResult(noticias);
        }
    }
}
