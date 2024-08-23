using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContaCorrenteAPI.Data;
using ContaCorrenteAPI.Models;

namespace ContaCorrenteAPI.Controllers
// Chamando as APIS , e ASPNET.
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase // Criação de classe de Controle
    {
        private readonly ContaCorrenteContext _context;

        public ClientesController(ContaCorrenteContext context) 
        {
            _context = context;
        }
 
        // Consulta de saldo
        [HttpGet("Consulta de saldo")]
        public async Task<ActionResult<decimal>> GetSaldo(int id) // // Preenchimento e busca de ID do cliente desejado
        {
            var cliente = await _context.Clientes.FindAsync(id); // Procura pelo id preenchido do cliente a se Consultar
            if (cliente == null)
            {
                return NotFound();
            }
            return cliente.Saldo;
        }

    // Consulta de clientes por id
    [HttpGet("Consulta de Clientes por ID")]
    public async Task<IActionResult> GetClienteById(int id) // // Preenchimento e busca de ID do cliente desejado
    {
        var cliente = await _context.Clientes.FindAsync(id); // Procura pelo id preenchido do cliente a se Consultar

        if (cliente == null)
        {
            return NotFound();
        }

        return Ok(cliente);
    }

        // Creditação de clientes.
        [HttpPost("Creditação")] // Cartão de visualização
        public async Task<IActionResult> Credito(int id, [FromBody] decimal valor) // Preenchimento e busca de ID
        {
            var cliente = await _context.Clientes.FindAsync(id); // Procura pelo id preenchido do cliente a se Creditar
            if (cliente == null)
            {
                return NotFound();
            }
        // Processo de Creditação
            cliente.Saldo += valor;
            await _context.SaveChangesAsync();

            return Ok(cliente);
        }

        // Debitação de clientes.
        [HttpPost("Debitação")] // Cartão de visualização.
        public async Task<IActionResult> Debito(int id, [FromBody] decimal valor) // Preenchimento e busca de ID
        {
            var cliente = await _context.Clientes.FindAsync(id); // Procura pelo id preenchido do cliente a se Debitar
            if (cliente == null)
            {
                return NotFound();
            }
        // Processo de debitação
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

