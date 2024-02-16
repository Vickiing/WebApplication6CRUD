using Microsoft.EntityFrameworkCore;
using WebApplication6.Banco;

var builder = WebApplication.CreateBuilder(args);

// Adicione outros serviços ao contêiner aqui, se necessário

builder.Services.AddControllersWithViews();

// Configure o contexto do banco de dados
builder.Services.AddDbContext<BancoContexto>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 26))));

var app = builder.Build();

// Configure o pipeline de solicitação HTTP

// Adicione outras configurações e middleware aqui, se necessário

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
