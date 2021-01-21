using Data.Entities.Entities;
using Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class Order : BaseClass
    {
        public int Id { get; set; }

        public DateTime OrderDate { set; get; }

        public Guid UserId { set; get; }

        public string ShipName { set; get; }

        public OrderStatus Status { set; get; }

        public Shiping Shiping { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public AppUser AppUser { get; set; }
    }

}
