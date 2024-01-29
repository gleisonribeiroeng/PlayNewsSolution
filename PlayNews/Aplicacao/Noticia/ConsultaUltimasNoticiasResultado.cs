using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Aplicacao.Noticia
{
    public class ConsultaUltimasNoticiasResultado
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string NomeUsuario { get; set; }
        public string DataPublicacao { get; set; }
        public int QtdComentarios { get; set; }
        public string Tipo { get; set; }
        public Imagem Imagem { get; set; }
    }
}
