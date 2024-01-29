using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Aplicacao.Detonado
{
    public class ExecutorComandoEditarDetonado : IRequestHandler<ComandoEditarDetonado, ComandoEditarDetonadoResultado>
    {
        Task<ComandoEditarDetonadoResultado> IRequestHandler<ComandoEditarDetonado, ComandoEditarDetonadoResultado>.Handle(ComandoEditarDetonado request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ComandoEditarDetonadoResultado());
        }
    }
}
