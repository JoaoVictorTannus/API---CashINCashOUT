using Microsoft.EntityFrameworkCore;
using ContaCorrenteAPI.Models;

namespace ContaCorrenteAPI.Data
{
    public class ContaCorrenteContext : DbContext
    {
        public ContaCorrenteContext(DbContextOptions<ContaCorrenteContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
