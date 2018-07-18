using P03_SalesDatabase.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_SalesDatabase.Data.Models
{
    public class Product:INameable
    {
        public Product()
        {

        }
        public int ProductId { get; set; }
        
        public string Name { get; set; }
        
        public double Quantity { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
        
        public int SaleId { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
