using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class OrderDetail : BaseClass
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { set; get; }

        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}
