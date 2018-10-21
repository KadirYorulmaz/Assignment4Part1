using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Assignment4New.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public int UnitsInStock { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        //public List<OrderDetails> OrderDetails { get; set; }
    }
}
