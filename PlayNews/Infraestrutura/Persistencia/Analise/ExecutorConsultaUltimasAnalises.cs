using MediatR;
using Microsoft.EntityFrameworkCore;
using MrgGameNews;
using PlayNews.Aplicacao.Analise;
using PlayNews.Aplicacao.Detonado;
using PlayNews.Aplicacao.Noticia;
using PlayNews.Dominio.Analises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Infraestrutura.Persistencia.Analise
{
    public class ExecutorConsultaUltimasAnalises : IRequestHandler<ConsultaUltimasAnalises, List<ConsultaUltimasAnalisesResultado>>
    {
        private readonly PlayNewsContext dbContext;
        public ExecutorConsultaUltimasAnalises(PlayNewsContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<List<ConsultaUltimasAnalisesResultado>> Handle(ConsultaUltimasAnalises request, CancellationToken cancellationToken)
        {
            var noticias = this.dbContext.Set<PlayNews.Dominio.Analises.Analise>().Where(n => n.Ativo == true && n.Manchete == false).OrderByDescending(n => n.DataPublicacao).Take(3).ToList().Select(s =>
            new ConsultaUltimasAnalisesResultado()
            {
                Id = s.Id,
                Titulo = LimitarTexto(s.Titulo),
                SubTitulo = LimitarTexto(s.SubTitulo),
                DataPublicacao = TempoAtras(s.DataPublicacao),
                QtdComentarios = 0,
                QtdView = 0,
                Tipo = "Analise"
            }).ToArray();


            int indice = 0;
            foreach (var item in noticias)
            {
                var imagemAnaliseCapa = dbContext.Set<AnaliseImagem>().Where(ni => ni.IdAnalise == item.Id && ni.Capa == true).FirstOrDefault();
                var imagem = dbContext.Set<PlayNews.Dominio.Imagens.Imagem>().Single(i => i.Id == imagemAnaliseCapa.IdImagem);
                noticias[indice].Imagem = new PlayNews.Aplicacao.Analise.Imagem() { Capa = true, Data = imagem.Data, Nome = imagem.Nome };
                indice++;
            }

            return Task.FromResult(noticias.ToList());
        }

        public string LimitarTexto(string texto)
        {
            if (texto.Length > 60)
            {
                return texto.Substring(0, 60) + "...";
            }
            else
            {
                return texto;
            }
        }

        public string TempoAtras(DateTime data)
        {
            TimeSpan diferenca = DateTime.Now - data;

            if (diferenca.TotalSeconds < 60)
            {
                return $"{diferenca.TotalSeconds.ToString("F0")} segundos atrás";
            }
            else if (diferenca.TotalMinutes < 60)
            {
                return $"{diferenca.TotalMinutes.ToString("F0")} minutos atrás";
            }
            else if (diferenca.TotalHours < 24)
            {
                return $"{diferenca.TotalHours.ToString("F0")} horas atrás";
            }
            else if (diferenca.TotalDays < 30)
            {
                return $"{diferenca.TotalDays.ToString("F0")} dias atrás";
            }
            else if (diferenca.TotalDays < 365)
            {
                int meses = (int)(diferenca.TotalDays / 30);
                return $"{meses} {(meses == 1 ? "mês" : "meses")} atrás";
            }
            else
            {
                int anos = (int)(diferenca.TotalDays / 365);
                return $"{anos} {(anos == 1 ? "ano" : "anos")} atrás";
            }
        }
    }
}
