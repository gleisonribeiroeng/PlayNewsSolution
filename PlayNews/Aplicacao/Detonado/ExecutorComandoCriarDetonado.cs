using MediatR;
using MrgGameNews;
using PlayNews.Aplicacao.Noticia;
using PlayNews.Dominio.Noticias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PlayNews.Aplicacao.Detonado
{
    public class ExecutorComandoCriarDetonado : IRequestHandler<ComandoCriarDetonado, ComandoCriarDetonadoResultado>
    {
        private readonly PlayNewsContext context;
        public ExecutorComandoCriarDetonado(PlayNewsContext context)
        {
            this.context = context; ;
        }
        Task<ComandoCriarDetonadoResultado> IRequestHandler<ComandoCriarDetonado, ComandoCriarDetonadoResultado>.Handle(ComandoCriarDetonado comando, CancellationToken cancellationToken)
        {
            int idNoticia = (context.Noticias.Max(e => (int?)e.Id) ?? 0) + 1;
            int idImagem = (context.Imagens.Max(e => (int?)e.Id) ?? 0) + 1;

            foreach (var img in comando.Imagens)
            {
                this.context.Imagens.Add(new PlayNews.Dominio.Imagens.Imagem(idImagem, img.Nome, img.Data));
            }

            this.context.Noticias.Add(new Dominio.Noticias.Noticia()
            {
                Id = idNoticia,
                Titulo = comando.Titulo,
                SubTitulo = comando.SubTitulo,
                Ativo = true,
                Corpo = comando.Corpo,
                DataPublicacao = DateTime.Now,
                IdJogo = comando.IdJogo,
                IdUsuario = 1,
                Manchete = comando.Manchete
            });

            var noticiaImagens = comando.Imagens.Select(imagem => new NoticiaImagem()
            {
                Capa = false,
                IdImagem = 1,
                IdNoticia = 23
            }).ToList();

            this.context.NoticiaImagens.AddRange(noticiaImagens);
            this.context.SaveChanges();

            return Task.FromResult(new ComandoCriarDetonadoResultado() { Sucesso = true });
        }
    }
}
