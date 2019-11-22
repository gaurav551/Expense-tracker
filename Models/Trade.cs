using System.ComponentModel.DataAnnotations;
using ExpenseTracker.Models;
namespace ExpenseTracker.Models
{
    public class Trade
    {
        public int Id { get; set; }
        public float TaxableAmount {get;set;}
        public float Tax { get; set; }
        public float Total { get; set; }
        
        public string CompanyName {get;set;}
        public string CompanyName2 { get; set; }
        
         public Company Company {get; set;}
         public int CompanyId { get; set; }
         public string CompanyPanNumber {get;set;}
        
    }

    public class TradeResult {
                 public int CompanyId { get; set; }

      public float TaxableAmount {get;set;}
        public float Tax { get; set; }
        public string CompanyName   {get; set;}
        public float Total { get; set; }  
        
        public string CompanyPanNumber { get; set; }
       

        
         }
}