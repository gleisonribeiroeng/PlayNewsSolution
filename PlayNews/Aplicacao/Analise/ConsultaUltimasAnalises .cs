using MediatR;
using PlayNews.Aplicacao.Noticia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Aplicacao.Analise
{
    public class ConsultaUltimasAnalises : IRequest<List<ConsultaUltimasAnalisesResultado>>
    {
    }
}
