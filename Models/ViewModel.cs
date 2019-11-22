namespace ExpenseTracker.Models
{
    public class ViewModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public long PanNumber { get; set; }
        public float TaxableAmount { get; set; }
        public float Tax { get; set; }
        public float Total { get; set; }
    }
}