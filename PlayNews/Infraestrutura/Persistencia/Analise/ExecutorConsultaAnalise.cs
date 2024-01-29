using AutoMapper;
using MediatR;
using MrgGameNews;
using PlayNews.Aplicacao.Noticia;
using PlayNews.Dominio.Analises;
using PlayNews.Dominio.Noticias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Infraestrutura.Persistencia.Analises
{
    public class ExecutorConsultaAnalise : IRequestHandler<ConsultaAnalise, List<ConsultaAnaliseResultado>>
    {
        private readonly PlayNewsContext dbContext;
        private readonly IMapper mapper;
        public ExecutorConsultaAnalise(PlayNewsContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public Task<List<ConsultaAnaliseResultado>> Handle(ConsultaAnalise request, CancellationToken cancellationToken)
        {
            var noticias = this.mapper.Map<List<ConsultaAnaliseResultado>>(this.dbContext.Set<PlayNews.Dominio.Analises.Analise>().ToList());
            return Task.FromResult(noticias);
        }
    }
}