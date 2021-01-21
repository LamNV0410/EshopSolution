using Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Category : BaseClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Status Status { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
