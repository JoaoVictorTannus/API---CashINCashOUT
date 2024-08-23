using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContaCorrenteAPI.Data;
using ContaCorrenteAPI.Models;

namespace ContaCorrenteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ContaCorrenteContext _context;

        public ClientesController(ContaCorrenteContext context)
        {
            _context = context;
        }
 
        // GET: api/Clientes/{id}/Saldo
        [HttpGet("{id}/Saldo")]
        public async Task<ActionResult<decimal>> GetSaldo(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return cliente.Saldo;
        }

    // Método para obter um cliente por ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetClienteById(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
        {
            return NotFound();
        }

        return Ok(cliente);
    }

    // Método para gerar um número de conta único
    private string GenerateUniqueAccountNumber()
    {
        return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
    }
        // POST: api/Clientes/{id}/Credito
        [HttpPost("{id}/Credito")]
        public async Task<IActionResult> Credito(int id, [FromBody] decimal valor)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            cliente.Saldo += valor;
            await _context.SaveChangesAsync();

            return Ok(cliente);
        }

        // POST: api/Clientes/{id}/Debito
        [HttpPost("{id}/Debito")]
        public async Task<IActionResult> Debito(int id, [FromBody] decimal valor)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            if (cliente.Saldo < valor)
            {
                return BadRequest("Saldo insuficiente.");
            }

            cliente.Saldo -= valor;
            await _context.SaveChangesAsync();

            return Ok(cliente);
        }
    }
}

