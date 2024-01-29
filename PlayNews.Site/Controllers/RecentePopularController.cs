using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlayNews.Aplicacao.Compartilhado;
using PlayNews.Aplicacao.Noticia;

namespace PlayNews.Site.Controllers
{
    public class RecentePopularController : Controller
    {
        private readonly IMediator mediator;

        public RecentePopularController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public List<ConsultaRecentesResultado> BuscarRecentesPopular(ConsultaRecentes consulta)
        {
            return this.mediator.Send(consulta).Result;
        }
    }
}
