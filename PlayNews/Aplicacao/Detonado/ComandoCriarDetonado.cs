using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Aplicacao.Detonado
{
    public class ComandoCriarDetonado : IRequest<ComandoCriarDetonadoResultado>
    {
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public int IdJogo { get; set; }
        public bool Manchete { get; set; }
        public string Corpo { get; set; }
        public List<Imagem> Imagens { get; set; }
    }

    public class Imagem
    {
        public bool Capa { get; set; }
        public string Nome { get; set; }
        public byte[] Data { get; set; }
    }
}
