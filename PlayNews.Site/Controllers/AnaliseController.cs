using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlayNews.Aplicacao.Analise;
using PlayNews.Aplicacao.Noticia;

namespace PlayNews.Site.Controllers
{
    public class AnaliseController : Controller
    {
        private readonly IMediator mediator;

        public AnaliseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public List<ConsultaUltimasAnalisesResultado> BuscarUltimasAnalises(ConsultaUltimasAnalises consulta)
        {
            return this.mediator.Send(consulta).Result;
        }
    }
}
