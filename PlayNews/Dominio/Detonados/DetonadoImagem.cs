using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Dominio.Detonados
{
    [Table("DetonadoImagem")]
    public class DetonadoImagem
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("IdDetonado")]
        public int IdDetonado { get; set; }
        [Column("IdImagem")]
        public int IdImagem { get; set; }
        [Column("Capa")]
        public bool Capa { get; set; }
    }
}
