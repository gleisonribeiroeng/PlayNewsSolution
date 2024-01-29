using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Aplicacao.Noticia
{
    public class ExecutorComandoRemoverAnalise : IRequestHandler<ComandoRemoverAnalise, ComandoRemoverAnaliseResultado>
    {
        Task<ComandoRemoverAnaliseResultado> IRequestHandler<ComandoRemoverAnalise, ComandoRemoverAnaliseResultado>.Handle(ComandoRemoverAnalise request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ComandoRemoverAnaliseResultado());
        }
    }
}
