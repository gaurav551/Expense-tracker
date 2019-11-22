using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ExpenseTracker.Models;

namespace ExpenseTracker.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string PanNumber { get; set; }
         public List<Trade> Trades { get; set; }
        public int TradesId {get; set;}
       
      
        

    }
}