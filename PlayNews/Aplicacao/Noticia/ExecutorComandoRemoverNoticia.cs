using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Aplicacao.Noticia
{
    public class ExecutorComandoRemoverNoticia : IRequestHandler<ComandoRemoverNoticia, ComandoRemoverNoticiaResultado>
    {
        Task<ComandoRemoverNoticiaResultado> IRequestHandler<ComandoRemoverNoticia, ComandoRemoverNoticiaResultado>.Handle(ComandoRemoverNoticia request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ComandoRemoverNoticiaResultado());
        }
    }
}
