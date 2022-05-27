namespace Refunds.Core.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Value { get; set; }
        public string ReceiptPath { get; set; } = string.Empty;
        public int RefundId { get; set; }
        public Refund? ParendRefund { get; set; }
        public int? ParentUserId { get; set; }
    }
}
