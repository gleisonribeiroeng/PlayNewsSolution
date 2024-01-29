using PlayNews.Dominio.Jogos;
using PlayNews.Dominio.Usuarios;
using PlayNews.Infraestrutura.Persistencia.Usuario;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayNews.Dominio.Noticias
{
    [Table("Noticia")]
    public class Noticia
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Titulo")]
        public string Titulo { get; set; }
        [Column("SubTitulo")]
        public string SubTitulo { get; set; }
        [Column("Manchete")]
        public bool Manchete { get; set; }
        [Column("Ativo")]
        public bool Ativo { get; set; }
        [Column("Corpo")]
        public string Corpo { get; set; }
        [Column("DataPublicacao")]
        public DateTime DataPublicacao { get; set; }
        [Column("IdJogo")]
        public int IdJogo { get; set; }
        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        [ForeignKey("IdJogo")]
        public virtual Jogo Jogo { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }


    }
}
