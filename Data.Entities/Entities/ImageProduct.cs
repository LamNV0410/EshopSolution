using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class ImageProduct : BaseClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string URLImage { get; set; }

        public string Decription { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
