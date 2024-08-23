namespace ContaCorrenteAPI.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NumeroConta { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public decimal Saldo { get; set; } = 0;
    }
}
