using PlayNews.Dominio.Categorias;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayNews.Dominio.Jogos
{
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Ano")]
        public int Ano { get; set; }
    }
}
