
namespace Reembolso.Models
{
    public class Refund
    {
        public double CalculateTotalValue(List<Item> items)
        {
            double totalValue = 0;
            foreach (Item item in items)
            {
                totalValue += item.Value;
            }
            return totalValue;
        }

        public int Id { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public DateTime CreationDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public int AprovingId { get; set; } = 1; // 1: Pendente, 2: Aprovado, 3: Revisão do usuário, 4: Reprovado, 5: Enviado para pagamento; 
        public double? TotalValue { get; set; }

        //Navigation
        public User? Owner { get; set; }
        public int OwnerId { get; internal set; }
    }
}
