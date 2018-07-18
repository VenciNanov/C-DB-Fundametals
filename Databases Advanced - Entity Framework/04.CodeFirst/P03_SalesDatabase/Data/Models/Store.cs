using P03_SalesDatabase.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_SalesDatabase.Data.Models
{
    public class Store : INameable
    {
        public Store()
        {
        }
       
        public int StoreId { get; set; }

        public string Name { get; set; }
             
        public int SaleId { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
