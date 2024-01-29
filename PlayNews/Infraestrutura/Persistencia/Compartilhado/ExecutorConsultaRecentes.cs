using MediatR;
using MrgGameNews;
using PlayNews.Aplicacao.Compartilhado;
using PlayNews.Aplicacao.Noticia;
using PlayNews.Dominio.Analises;
using PlayNews.Dominio.Detonados;
using PlayNews.Dominio.Noticias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Infraestrutura.Persistencia.Compartilhado
{
    public class ExecutorConsultaRecentes : IRequestHandler<ConsultaRecentes, List<ConsultaRecentesResultado>>
    {
        private readonly PlayNewsContext dbContext;
        public ExecutorConsultaRecentes(PlayNewsContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<List<ConsultaRecentesResultado>> Handle(ConsultaRecentes request, CancellationToken cancellationToken)
        {
            List<ConsultaRecentesResultado> resultado = new List<ConsultaRecentesResultado>();
            var noticias = this.dbContext.Set<Noticia>()
                .Where(n => n.Ativo == true)
                .OrderByDescending(n => n.DataPublicacao).Take(4).ToList().ToArray();

            var analises = this.dbContext.Set<PlayNews.Dominio.Analises.Analise>()
                .Where(n => n.Ativo == true)
                .OrderByDescending(n => n.DataPublicacao).Take(4).ToList().ToArray();

            //var detonados = this.dbContext.Set<PlayNews.Dominio.Detonados.Detonado>()
            //    .Where(n => n.Ativo == true)
            //    .OrderByDescending(n => n.DataPublicacao).Take(4).ToList().ToArray();

            for (var i = 0; i <= 6; i++)
            {
                if(i >= 0 && i < noticias.Length)
                {
                    var imagemNoticiaCapa = dbContext.Set<NoticiaImagem>().Where(ni => ni.IdNoticia == noticias[i].Id && ni.Capa == true).FirstOrDefault();
                    var imagem = dbContext.Set<PlayNews.Dominio.Imagens.Imagem>().Single(i => i.Id == imagemNoticiaCapa.IdImagem);
                    resultado.Add(new ConsultaRecentesResultado(noticias[i].Id, noticias[i].Titulo, "Noticia", noticias[i].DataPublicacao, new Imagem() { Capa = true, Data = imagem.Data, Nome = imagem.Nome }));
                }
                if (i >= 0 && i < analises.Length)
                {
                    var imagemNoticiaCapa = dbContext.Set<AnaliseImagem>().Where(ni => ni.IdAnalise == analises[i].Id && ni.Capa == true).FirstOrDefault();
                    var imagem = dbContext.Set<PlayNews.Dominio.Imagens.Imagem>().Single(i => i.Id == imagemNoticiaCapa.IdImagem);
                    resultado.Add(new ConsultaRecentesResultado(analises[i].Id, analises[i].Titulo, "Analise", analises[i].DataPublicacao, new Imagem() { Capa = true, Data = imagem.Data, Nome = imagem.Nome }));
                }
                //if (i >= 0 && i < detonados.Length)
                //{
                //    var imagemNoticiaCapa = dbContext.Set<DetonadoImagem>().Where(ni => ni.IdDetonado == detonados[i].Id && ni.Capa == true).FirstOrDefault();
                //    var imagem = dbContext.Set<PlayNews.Dominio.Imagens.Imagem>().Single(i => i.Id == imagemNoticiaCapa.IdImagem);
                //    resultado.Add(new ConsultaRecentesResultado(detonados[i].Id, detonados[i].Titulo, "Detonado", detonados[i].DataPublicacao, new Imagem() { Capa = true, Data = imagem.Data, Nome = imagem.Nome }));
                //}
            }

            return Task.FromResult(resultado.OrderByDescending(r => r.DataPublicacao).Take(4).ToList());
        }

        public string LimitarTexto(string texto)
        {
            if (texto.Length > 30)
            {
                return texto.Substring(0, 30) + "...";
            }
            else
            {
                return texto;
            }
        }
    }
}
