using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MrgGameNews;
using PlayNews.Aplicacao.Jogo;
using PlayNews.Aplicacao.Noticia;
using PlayNews.Dominio.Categorias;
using PlayNews.Dominio.Jogos;
using PlayNews.Dominio.Noticias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Infraestrutura.Persistencia.Jogos
{
    public class ExecutorConsultaJogo : IRequestHandler<ConsultaJogo, List<ConsultaJogoResultado>>
    {
        private readonly PlayNewsContext dbContext;
        private readonly IMapper mapper;
        public ExecutorConsultaJogo(PlayNewsContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public Task<List<ConsultaJogoResultado>> Handle(ConsultaJogo request, CancellationToken cancellationToken)
        {
            List<ConsultaJogoResultado> resultado = new List<ConsultaJogoResultado>();
            var jogos = dbContext.Set<Jogo>();
            var categorias = dbContext.Set<Categoria>();
            var jogoCategorias = dbContext.Set<JogoCategoria>();

            var consulta = (from jogo in jogos
                            join jd in jogoCategorias on jogo.Id equals jd.IdJogo
                            join categoria in categorias on jd.IdCategoria equals categoria.Id
                            select new { codigo = jogo.Id, nome = jogo.Nome, ano = jogo.Ano, categoriaNome = categoria.Nome }).ToList();

            var agrupamentos = consulta.GroupBy(c => c.codigo);

            foreach (var item in consulta)
            {
                if(resultado.Where(r => r.Id == item.codigo).Count() == 0)
                {
                    resultado.Add(new ConsultaJogoResultado()
                    {
                        Id = item.codigo,
                        Nome = item.nome,
                        Ano = item.ano,
                        Categorias = String.Join(",", agrupamentos.Where(a => a.Key == item.codigo).FirstOrDefault().Select(a => a.categoriaNome))

                    });
                }
            }

            return Task.FromResult(resultado);
        }
    }
}