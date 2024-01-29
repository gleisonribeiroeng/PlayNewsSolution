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
    public class ExecutorConsultaUltimasNoticias : IRequestHandler<ConsultaUltimasNoticias, List<ConsultaUltimasNoticiasResultado>>
    {
        private readonly PlayNewsContext dbContext;
        public ExecutorConsultaUltimasNoticias(PlayNewsContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<List<ConsultaUltimasNoticiasResultado>> Handle(ConsultaUltimasNoticias request, CancellationToken cancellationToken)
        {
            var noticias = this.dbContext.Set<Noticia>()
                .Where(n => n.Ativo == true)
                .OrderByDescending(n => n.DataPublicacao).Take(6).ToList()
                .Select((s, indice) =>
            new ConsultaUltimasNoticiasResultado()
            {
                Id = s.Id,
                Titulo = indice == 0 ? s.Titulo : LimitarTexto(s.Titulo),
                SubTitulo = indice == 0 ? s.SubTitulo : LimitarTexto(s.SubTitulo),
                NomeUsuario = s.Usuario.Apelido,
                DataPublicacao = TempoAtras(s.DataPublicacao),
                QtdComentarios = 0,
                Tipo = "Noticia"
            }).ToArray();


            int indice = 0;
            foreach (var item in noticias)
            {
                var imagemNoticiaCapa = dbContext.Set<NoticiaImagem>().Where(ni => ni.IdNoticia == item.Id && ni.Capa == true).FirstOrDefault();
                var imagem = dbContext.Set<PlayNews.Dominio.Imagens.Imagem>().Single(i => i.Id == imagemNoticiaCapa.IdImagem);
                noticias[indice].Imagem = new Imagem() { Capa = true, Data = imagem.Data, Nome = imagem.Nome };
                indice++;
            }

            return Task.FromResult(noticias.ToList());
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
