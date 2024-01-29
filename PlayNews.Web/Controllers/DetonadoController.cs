using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlayNews.Aplicacao.Detonado;
using PlayNews.Aplicacao.Jogo;
using PlayNews.Aplicacao.Noticia;

namespace mrg_game_news.Controllers
{
    public class DetonadoController : Controller
    {
        private readonly IMediator mediator;

        public DetonadoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public List<ConsultaDetonadoResultado> BuscarDetonados(ConsultaDetonado consulta)
        {
            return this.mediator.Send(consulta).Result;
        }

        public List<ConsultaJogoResultado> BuscarJogos(ConsultaJogo consulta)
        {
            return this.mediator.Send(consulta).Result;
        }

        public ComandoCriarDetonadoResultado CriarAnalise([FromBody] ComandoCriarDetonado comando)
        {
            return this.mediator.Send(comando).Result;
        }
    }
}
