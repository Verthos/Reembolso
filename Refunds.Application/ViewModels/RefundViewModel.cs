using Refunds.Core.Entities;

namespace Refunds.Application.ViewModels
{
    public class RefundViewModel
    {
        public int Id { get; }
        public List<Item> Items { get; } = new List<Item>();
        public DateTime CreationDate { get; }
        public DateTime? ClosingDate { get; }
        public int AprovingId { get; } = 1; // 1: Pendente, 2: Aprovado, 3: Revisão do usuário, 4: Reprovado, 5: Enviado para pagamento; 
        public double? TotalValue { get; }

        //Navigation
        public UserViewModel? Owner { get; }
        public int OwnerId { get; }
    }
}
