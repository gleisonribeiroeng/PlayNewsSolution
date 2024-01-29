using AutoMapper;
using MediatR;
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
    public class ExecutorConsultaLabelsTopNoticia : IRequestHandler<ConsultaLabelsTopNoticias, List<ConsultaLabelsTopNoticiaResultado>>
    {
        private readonly PlayNewsContext dbContext;
        private readonly IMapper mapper;
        public ExecutorConsultaLabelsTopNoticia(PlayNewsContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public Task<List<ConsultaLabelsTopNoticiaResultado>> Handle(ConsultaLabelsTopNoticias request, CancellationToken cancellationToken)
        {
            var noticias = this.dbContext.Set<Noticia>().Where(n => n.Ativo == true)
                .Take(5)
                .ToList()
                .Select(s => new ConsultaLabelsTopNoticiaResultado() { 
                    Id = s.Id , 
                    Nome = LimitarTexto(s.Titulo) 
                });
            return Task.FromResult(noticias.ToList());
        }

        public string LimitarTexto(string texto)
        {
            if (texto.Length > 57)
            {
                return texto.Substring(0, 57) + "...";
            }
            else
            {
                return texto;
            }
        }
    }
}
