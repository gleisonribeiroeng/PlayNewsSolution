using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Dominio.Noticias
{
    [Table("NoticiaImagem")]
    public class NoticiaImagem
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("IdNoticia")]
        public int IdNoticia { get; set; }
        [Column("IdImagem")]
        public int IdImagem { get; set; }
        [Column("Capa")]
        public bool Capa { get; set; }
    }
}
