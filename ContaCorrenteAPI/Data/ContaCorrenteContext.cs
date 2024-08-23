using Microsoft.EntityFrameworkCore;
using ContaCorrenteAPI.Models;

namespace ContaCorrenteAPI.Data
// Montando o banco de dados de contexto , onde serão atualizados.
{
    public class ContaCorrenteContext : DbContext
    {
        public ContaCorrenteContext(DbContextOptions<ContaCorrenteContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
