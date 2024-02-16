using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication6.Banco
{
    public class BancoContexto : DbContext
    {
        public BancoContexto(DbContextOptions<BancoContexto> options) : base(options)
        {
        }

        public DbSet<Cliente> cadastro_clientes { get; set; }
    }
}

