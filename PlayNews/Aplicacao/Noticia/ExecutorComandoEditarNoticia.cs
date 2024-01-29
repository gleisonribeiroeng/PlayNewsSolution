using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Aplicacao.Noticia
{
    public class ExecutorComandoEditarNoticia : IRequestHandler<ComandoEditarNoticia, ComandoEditarNoticiaResultado>
    {
        Task<ComandoEditarNoticiaResultado> IRequestHandler<ComandoEditarNoticia, ComandoEditarNoticiaResultado>.Handle(ComandoEditarNoticia request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ComandoEditarNoticiaResultado());
        }
    }
}
