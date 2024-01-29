using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlayNews.Aplicacao.Jogo;

namespace mrg_game_news.Controllers
{
    public class JogoController : Controller
    {
        private readonly IMediator mediator;

        public JogoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public List<ConsultaJogoResultado> BuscarJogos(ConsultaJogo consulta)
        {
            return this.mediator.Send(consulta).Result;
        }
    }
}