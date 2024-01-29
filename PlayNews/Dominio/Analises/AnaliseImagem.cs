using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Dominio.Analises
{
    [Table("AnaliseImagem")]
    public class AnaliseImagem
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("IdAnalise")]
        public int IdAnalise { get; set; }
        [Column("IdImagem")]
        public int IdImagem { get; set; }
        [Column("Capa")]
        public bool Capa { get; set; }
    }
}
