using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class Product : BaseClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Decription { get; set; }

        public decimal Price { get; set; }

        public decimal OriginalPrice { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<ImageProduct> ImageProducts { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
