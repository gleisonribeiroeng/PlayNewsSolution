using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Dominio.Imagens
{
    [Table("Imagem")]
    public class Imagem
    {
        public Imagem(int id, string nome, byte[] data) 
        { 
            this.Id = id;
            this.Nome = nome;
            this.Data = data;
        }
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Imagem")]
        public byte[] Data { get; set; }
    }
}
