using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlayNews.Aplicacao.Jogo;
using PlayNews.Aplicacao.Noticia;

namespace PlayNews.Site.Controllers
{
    public class NoticiaController : Controller
    {
        private readonly IMediator mediator;

        public NoticiaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public List<ConsultaLabelsTopNoticiaResultado> BuscarLabelsTopNoticias(ConsultaLabelsTopNoticias consulta)
        {
            return this.mediator.Send(consulta).Result;
        }

        public List<ConsultaUltimasManchetesResultado> BuscarUltimasManchetes(ConsultaUltimasManchetes consulta)
        {
            return this.mediator.Send(consulta).Result;
        }

        public List<ConsultaUltimasNoticiasResultado> BuscarUltimasNoticias(ConsultaUltimasNoticias consulta)
        {
            return this.mediator.Send(consulta).Result;
        }
    }
}
