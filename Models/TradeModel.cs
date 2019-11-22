namespace ExpenseTracker.Models
{
    public class TradeModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public float Total { get; set; }
        public float TaxableAmount { get; set; }
        public float  Tax { get; set; }
        public string PanNumber { get; set; }
    }
}