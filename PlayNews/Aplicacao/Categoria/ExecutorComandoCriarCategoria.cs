using MediatR;
using PlayNews.Aplicacao.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Aplicacao.Categoria
{
    public class ExecutorComandoCriarCategoria : IRequestHandler<ComandoCriarCategoria, ComandoCriarCategoriaResultado>
    {
        Task<ComandoCriarCategoriaResultado> IRequestHandler<ComandoCriarCategoria, ComandoCriarCategoriaResultado>.Handle(ComandoCriarCategoria request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ComandoCriarCategoriaResultado());
        }
    }
}
