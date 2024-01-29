using PlayNews.Aplicacao.Noticia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Aplicacao.Compartilhado
{
    public class ConsultaRecentesResultado
    {
        public ConsultaRecentesResultado(int id, string titulo, string tipo, DateTime dataPublicacao, Imagem imagem = null) 
        { 
            this.Id = id;
            this.Titulo = titulo;
            this.Tipo = tipo;
            this.DataPublicacao = dataPublicacao;
            this.Imagem = imagem;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public DateTime DataPublicacao { get; set; }
        public Imagem Imagem { get; set; }
    }
}
