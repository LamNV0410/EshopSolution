using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Entities
{
    public class Shiping : BaseClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShipAddress { set; get; }

        public string ShipEmail { set; get; }

        public string ShipPhoneNumber { set; get; }

        public DateTime DueDate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
