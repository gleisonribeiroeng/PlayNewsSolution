using PlayNews.Dominio.Jogos;
using PlayNews.Dominio.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Dominio.Analises
{
    [Table("Analise")]
    public class Analise
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
