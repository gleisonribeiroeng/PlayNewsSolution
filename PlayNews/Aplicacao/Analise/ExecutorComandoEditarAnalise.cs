using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Aplicacao.Noticia
{
    public class ExecutorComandoEditarAnalise : IRequestHandler<ComandoEditarAnalise, ComandoEditarAnaliseResultado>
    {
        Task<ComandoEditarAnaliseResultado> IRequestHandler<ComandoEditarAnalise, ComandoEditarAnaliseResultado>.Handle(ComandoEditarAnalise request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ComandoEditarAnaliseResultado());
        }
    }
}
