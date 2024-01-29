using MediatR;
using Microsoft.EntityFrameworkCore;
using MrgGameNews;
using PlayNews.Aplicacao.Analise;
using PlayNews.Aplicacao.Compartilhado;
using PlayNews.Aplicacao.Noticia;
using PlayNews.Infraestrutura.Persistencia.Analise;
using PlayNews.Infraestrutura.Persistencia.Compartilhado;
using PlayNews.Infraestrutura.Persistencia.Noticias;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IRequestHandler<ConsultaLabelsTopNoticias, List<ConsultaLabelsTopNoticiaResultado>>, ExecutorConsultaLabelsTopNoticia>();
builder.Services.AddScoped<IRequestHandler<ConsultaRecentes, List<ConsultaRecentesResultado>>, ExecutorConsultaRecentes>();
builder.Services.AddScoped<IRequestHandler<ConsultaUltimasManchetes, List<ConsultaUltimasManchetesResultado>>, ExecutorConsultaUltimasManchetes>();
builder.Services.AddScoped<IRequestHandler<ConsultaUltimasAnalises, List<ConsultaUltimasAnalisesResultado>>, ExecutorConsultaUltimasAnalises>();
builder.Services.AddScoped<IRequestHandler<ConsultaUltimasNoticias, List<ConsultaUltimasNoticiasResultado>>, ExecutorConsultaUltimasNoticias>();

var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true)
    .Build();

builder.Services.AddDbContext<PlayNewsContext>(options => {
    options.UseLazyLoadingProxies();
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:44422")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddControllersWithViews();

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
