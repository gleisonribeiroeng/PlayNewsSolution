using MediatR;
using MrgGameNews;
using PlayNews.Aplicacao.Noticia;
using PlayNews.Dominio.Analises;
using PlayNews.Dominio.Analises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Aplicacao.Analise
{
    public class ExecutorComandoCriarAnalise : IRequestHandler<ComandoCriarAnalise, ComandoCriarAnaliseResultado>
    {
        private readonly PlayNewsContext context;
        public ExecutorComandoCriarAnalise(PlayNewsContext context)
        {
            this.context = context; ;
        }
        Task<ComandoCriarAnaliseResultado> IRequestHandler<ComandoCriarAnalise, ComandoCriarAnaliseResultado>.Handle(ComandoCriarAnalise comando, CancellationToken cancellationToken)
        {
            int idAnalise = (context.Analises.Max(e => (int?)e.Id) ?? 0) + 1;
            int idImagem = (context.Imagens.Max(e => (int?)e.Id) ?? 0) + 1;

            foreach (var img in comando.Imagens)
            {
                this.context.Imagens.Add(new PlayNews.Dominio.Imagens.Imagem(idImagem, img.Nome, img.Data));
            }

            this.context.Analises.Add(new Dominio.Analises.Analise()
            {
                Id = idAnalise,
                Titulo = comando.Titulo,
                SubTitulo = comando.SubTitulo,
                Ativo = true,
                Corpo = comando.Corpo,
                DataPublicacao = DateTime.Now,
                IdJogo = comando.IdJogo,
                IdUsuario = 1,
                Manchete = comando.Manchete
            });
            this.context.SaveChanges();
            var noticiaImagens = comando.Imagens.Select(imagem => new AnaliseImagem()
            {
                Capa = false,
                IdImagem = idImagem,
                IdAnalise = idAnalise
            }).ToList();

            this.context.AnaliseImagens.AddRange(noticiaImagens);
            this.context.SaveChanges();

            return Task.FromResult(new ComandoCriarAnaliseResultado() { Sucesso = true });
        }
    }
}
