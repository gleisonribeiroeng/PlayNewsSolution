using AutoMapper;
using MediatR;
using MrgGameNews;
using PlayNews.Aplicacao.Detonado;
using PlayNews.Aplicacao.Noticia;
using PlayNews.Dominio.Detonados;
using PlayNews.Dominio.Noticias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Infraestrutura.Persistencia.Detonados
{
    public class ExecutorConsultaDetonado : IRequestHandler<ConsultaDetonado, List<ConsultaDetonadoResultado>>
    {
        private readonly PlayNewsContext dbContext;
        private readonly IMapper mapper;
        public ExecutorConsultaDetonado(PlayNewsContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public Task<List<ConsultaDetonadoResultado>> Handle(ConsultaDetonado request, CancellationToken cancellationToken)
        {
            var noticias = this.mapper.Map<List<ConsultaDetonadoResultado>>(this.dbContext.Set<PlayNews.Dominio.Detonados.Detonado>().ToList());
            return Task.FromResult(noticias);
        }
    }
}