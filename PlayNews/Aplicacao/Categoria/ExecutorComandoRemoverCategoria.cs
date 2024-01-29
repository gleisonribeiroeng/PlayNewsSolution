using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Aplicacao.Categoria
{
    public class ExecutorComandoRemoverCategoria : IRequestHandler<ComandoRemoverCategoria, ComandoRemoverCategoriaResultado>
    {
        Task<ComandoRemoverCategoriaResultado> IRequestHandler<ComandoRemoverCategoria, ComandoRemoverCategoriaResultado>.Handle(ComandoRemoverCategoria request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ComandoRemoverCategoriaResultado());
        }
    }
}
