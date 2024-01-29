using AutoMapper;
using MediatR;
using MrgGameNews;
using PlayNews.Aplicacao.Categoria;
using PlayNews.Aplicacao.Categorias;
using PlayNews.Aplicacao.Detonado;
using PlayNews.Dominio.Categorias;
using PlayNews.Dominio.Noticias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Infraestrutura.Persistencia.Categorias
{
    public class ExecutorConsultaCategoria : IRequestHandler<ConsultaCategoria, List<ConsultaCategoriaResultado>>
    {
        private readonly PlayNewsContext dbContext;
        private readonly IMapper mapper;
        public ExecutorConsultaCategoria(PlayNewsContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public Task<List<ConsultaCategoriaResultado>> Handle(ConsultaCategoria request, CancellationToken cancellationToken)
        {
            var noticias = this.mapper.Map<List<ConsultaCategoriaResultado>>(this.dbContext.Set<PlayNews.Dominio.Categorias.Categoria>().ToList());
            return Task.FromResult(noticias);
        }
    }
}