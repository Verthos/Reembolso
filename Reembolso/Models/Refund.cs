namespace Reembolso.Models
{
    public class Refund
    {
        public int Id { get; set; }
        public List<Item> items { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public int aprovingStatus { get; set; }
        public int aprovingId { get; set; } = 1; // 1: Pendente, 2: Aprovado, 3: Revisão do usuário, 4: Reprovado; 
        public string UserName { get; set; }
        public int UserId { get; set; }
        public double TotalValue { get; set; }

    }
}
