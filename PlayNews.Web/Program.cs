using Autofac;
using Autofac.Core;
using AutoMapper;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using mrg_game_news;
using MrgGameNews;
using PlayNews.Aplicacao.Analise;
using PlayNews.Aplicacao.Compartilhado;
using PlayNews.Aplicacao.Detonado;
using PlayNews.Aplicacao.Jogo;
using PlayNews.Aplicacao.Noticia;
using PlayNews.Infraestrutura.Persistencia.Analises;
using PlayNews.Infraestrutura.Persistencia.Compartilhado;
using PlayNews.Infraestrutura.Persistencia.Detonados;
using PlayNews.Infraestrutura.Persistencia.Jogos;
using PlayNews.Infraestrutura.Persistencia.Noticias;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true)
    .Build();

builder.Services.AddDbContext<PlayNewsContext>(options => {
    options.UseLazyLoadingProxies();
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});


var builderMediatr = new ContainerBuilder();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddAutoMapper(typeof(Program));

var mappingConfig = new MapperConfiguration(config =>
{
    config.AddProfile<MappingProfile>();
});

IMapper mapper = mappingConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IRequestHandler<ConsultaNoticia, List<ConsultaNoticiaResultado>>, ExecutorConsultaNoticia>();
builder.Services.AddScoped<IRequestHandler<ConsultaRecentes, List<ConsultaRecentesResultado>>, ExecutorConsultaRecentes>();
builder.Services.AddScoped<IRequestHandler<ConsultaAnalise, List<ConsultaAnaliseResultado>>, ExecutorConsultaAnalise>();
builder.Services.AddScoped<IRequestHandler<ConsultaDetonado, List<ConsultaDetonadoResultado>>, ExecutorConsultaDetonado>();
builder.Services.AddScoped<IRequestHandler<ConsultaJogo, List<ConsultaJogoResultado>>, ExecutorConsultaJogo>();
builder.Services.AddScoped<IRequestHandler<ComandoCriarNoticia, ComandoCriarNoticiaResultado>, ExecutorComandoCriarNoticia>();
builder.Services.AddScoped<IRequestHandler<ComandoCriarAnalise, ComandoCriarAnaliseResultado>, ExecutorComandoCriarAnalise>();
builder.Services.AddScoped<IRequestHandler<ComandoCriarDetonado, ComandoCriarDetonadoResultado>, ExecutorComandoCriarDetonado>();

builder.Services.AddControllersWithViews();

builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder.WithOrigins("https://localhost:44476")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
