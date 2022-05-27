namespace Refunds.Application.InputModels
{
    public class ItemInputViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Value { get; set; }
        public string ReceiptPath { get; set; } = string.Empty;
        public int RefundId { get; set; }
        public RefundViewModel? ParendRefund { get; set; }
        public int? ParentUserId { get; set; }
    }
}
