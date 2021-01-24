using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Rating : BaseClass
    {
        public int Id { get; set; }

        public int Rate { get; set; }

        [ForeignKey("AppUser")]
        public Guid UserId { get; set; }

        public AppUser User { get; set; }


        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
