using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlayNews.Aplicacao.Jogo;
using PlayNews.Aplicacao.Noticia;

namespace mrg_game_news.Controllers
{
    public class NoticiaController : Controller
    {
        private readonly IMediator mediator;

        public NoticiaController(IMediator mediator) 
        {
            this.mediator = mediator;
        }

        public List<ConsultaNoticiaResultado> BuscarNoticias(ConsultaNoticia consulta)
        {
            return this.mediator.Send(consulta).Result;
        }

        public List<ConsultaJogoResultado> BuscarJogos(ConsultaJogo consulta)
        {
            return this.mediator.Send(consulta).Result;
        }

        public ComandoCriarNoticiaResultado CriarNoticia([FromBody]ComandoCriarNoticia comando)
        {
           return this.mediator.Send(comando).Result;
        }
    }
}
