using AutoMapper;
using PlayNews.Aplicacao.Detonado;
using PlayNews.Aplicacao.Jogo;
using PlayNews.Aplicacao.Noticia;
using PlayNews.Dominio.Analises;
using PlayNews.Dominio.Detonados;
using PlayNews.Dominio.Jogos;
using PlayNews.Dominio.Noticias;

namespace mrg_game_news
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Noticia, ConsultaNoticiaResultado>();
            CreateMap<ConsultaNoticiaResultado, Noticia>()
                .ForMember(dest => dest.DataPublicacao, opt => opt.MapFrom(src => src.DataPublicacao.ToLocalTime()))
                .ForPath(dest => dest.Jogo.Nome, opt => opt.MapFrom(src => src.NomeJogo))
                .ForPath(dest => dest.Usuario.Nome, opt => opt.MapFrom(src => src.NomeUsuario))
            .ReverseMap();

            CreateMap<Analise, ConsultaAnaliseResultado>();
            CreateMap<ConsultaAnaliseResultado, Analise>()
                .ForMember(dest => dest.DataPublicacao, opt => opt.MapFrom(src => src.DataPublicacao.ToLocalTime()))
                .ForPath(dest => dest.Jogo.Nome, opt => opt.MapFrom(src => src.NomeJogo))
                .ForPath(dest => dest.Usuario.Nome, opt => opt.MapFrom(src => src.NomeUsuario))
            .ReverseMap();

            CreateMap<Detonado, ConsultaDetonadoResultado>();
            CreateMap<ConsultaDetonadoResultado, Detonado>()
                .ForMember(dest => dest.DataPublicacao, opt => opt.MapFrom(src => src.DataPublicacao.ToLocalTime()))
                .ForPath(dest => dest.Jogo.Nome, opt => opt.MapFrom(src => src.NomeJogo))
                .ForPath(dest => dest.Usuario.Nome, opt => opt.MapFrom(src => src.NomeUsuario))
            .ReverseMap();

            CreateMap<Jogo, ConsultaJogoResultado>();
            CreateMap<ConsultaJogoResultado, Jogo>()
             //.ForPath(dest => dest.Categorias, opt => opt.MapFrom(src => src.Categorias))
            .ReverseMap();
        }
    }
}
