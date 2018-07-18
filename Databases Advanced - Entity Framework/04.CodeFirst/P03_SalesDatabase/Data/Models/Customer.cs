using P03_SalesDatabase.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_SalesDatabase.Data.Models
{
    public class Customer : INameable
    {
        public Customer()
        {

        }
        
        public int CustomerId { get; set; }
              
        public string Name { get; set; }
        
        public string Email { get; set; }

        public string CreditCardNumber { get; set; }
        
        public int SaleId { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
