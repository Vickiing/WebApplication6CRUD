using Microsoft.EntityFrameworkCore;
using WebApplication6.Banco;

var builder = WebApplication.CreateBuilder(args);

// Adicione outros servi�os ao cont�iner aqui, se necess�rio

builder.Services.AddControllersWithViews();

// Configure o contexto do banco de dados
builder.Services.AddDbContext<BancoContexto>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 26))));

var app = builder.Build();

// Configure o pipeline de solicita��o HTTP

// Adicione outras configura��es e middleware aqui, se necess�rio

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
