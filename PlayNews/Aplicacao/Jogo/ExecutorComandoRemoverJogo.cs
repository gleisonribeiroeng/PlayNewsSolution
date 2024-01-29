using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Aplicacao.Jogo
{
    public class ExecutorComandoRemoverJogo : IRequestHandler<ComandoRemoverJogo, ComandoRemoverJogoResultado>
    {
        Task<ComandoRemoverJogoResultado> IRequestHandler<ComandoRemoverJogo, ComandoRemoverJogoResultado>.Handle(ComandoRemoverJogo request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ComandoRemoverJogoResultado());
        }
    }
}
