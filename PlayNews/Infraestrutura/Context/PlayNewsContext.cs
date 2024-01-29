using Microsoft.EntityFrameworkCore;
using PlayNews.Dominio.Analises;
using PlayNews.Dominio.Categorias;
using PlayNews.Dominio.Detonados;
using PlayNews.Dominio.Imagens;
using PlayNews.Dominio.Jogos;
using PlayNews.Dominio.Noticias;
using PlayNews.Dominio.Usuarios;

namespace MrgGameNews
{
    public class PlayNewsContext : DbContext
    {
        public PlayNewsContext(DbContextOptions<PlayNewsContext> options)
        : base(options)
        {
        }

        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<NoticiaImagem> NoticiaImagens { get; set; }
        public DbSet<AnaliseImagem> AnaliseImagens { get; set; }
        public DbSet<DetonadoImagem> DetonadoImagens { get; set; }
        public DbSet<Detonado> Detonados { get; set; }
        public DbSet<Analise> Analises { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<JogoCategoria> JogoCategoria { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
