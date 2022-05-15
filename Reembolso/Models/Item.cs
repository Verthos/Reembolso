namespace Reembolso.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public string ReceiptPath { get; set; }
        public int RefundId { get; set; }
        public Refund? ParendRefund { get; set; }
    }
}
