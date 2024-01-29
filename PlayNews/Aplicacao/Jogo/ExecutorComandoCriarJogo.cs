using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Aplicacao.Jogo
{
    public class ExecutorComandoCriarJogo : IRequestHandler<ComandoCriarJogo, ComandoCriarJogoResultado>
    {
        Task<ComandoCriarJogoResultado> IRequestHandler<ComandoCriarJogo, ComandoCriarJogoResultado>.Handle(ComandoCriarJogo request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ComandoCriarJogoResultado());
        }
    }
}
