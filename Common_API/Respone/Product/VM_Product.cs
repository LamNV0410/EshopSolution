using Data.Entities;
using System.Collections.Generic;

namespace Common_API.Respone.Product
{
    public class VM_Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Decription { get; set; }

        public decimal Price { get; set; }

        public decimal OriginalPrice { get; set; }

        public int Quantity { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<ImageProduct> ImageProducts { get; set; }
    }
}
