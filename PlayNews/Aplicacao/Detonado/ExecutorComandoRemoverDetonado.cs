using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Aplicacao.Detonado
{
    public class ExecutorComandoRemoverDetonado : IRequestHandler<ComandoRemoverDetonado, ComandoRemoverDetonadoResultado>
    {
        Task<ComandoRemoverDetonadoResultado> IRequestHandler<ComandoRemoverDetonado, ComandoRemoverDetonadoResultado>.Handle(ComandoRemoverDetonado request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ComandoRemoverDetonadoResultado());
        }
    }
}
