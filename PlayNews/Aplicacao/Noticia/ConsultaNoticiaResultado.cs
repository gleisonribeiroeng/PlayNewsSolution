using PlayNews.Dominio.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Aplicacao.Noticia
{
    public class ConsultaNoticiaResultado
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string NomeJogo { get; set; }
        public string NomeUsuario { get; set; }
        public bool Manchete { get; set; }
        public bool Ativo { get; set; }
        public string Corpo { get; set; }
        public DateTime DataPublicacao { get; set; }
    }
}
