using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Dominio.Jogos
{
    [Keyless]
    [Table("JogoCategoria")]
    public class JogoCategoria
    {
        [Column("IdJogo")]
        public int IdJogo { get; set; }
        [Column("IdCategoria")]
        public int IdCategoria { get; set; }
    }
}
