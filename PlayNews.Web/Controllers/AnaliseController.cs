using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlayNews.Aplicacao.Analise;
using PlayNews.Aplicacao.Jogo;
using PlayNews.Aplicacao.Noticia;

namespace mrg_game_news.Controllers
{
    public class AnaliseController : Controller
    {
        private readonly IMediator mediator;

        public AnaliseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public List<ConsultaAnaliseResultado> BuscarAnalises(ConsultaAnalise consulta)
        {
            return this.mediator.Send(consulta).Result;
        }

        public List<ConsultaJogoResultado> BuscarJogos(ConsultaJogo consulta)
        {
            return this.mediator.Send(consulta).Result;
        }

        public ComandoCriarAnaliseResultado CriarAnalise([FromBody] ComandoCriarAnalise comando)
        {
            return this.mediator.Send(comando).Result;
        }
    }
}