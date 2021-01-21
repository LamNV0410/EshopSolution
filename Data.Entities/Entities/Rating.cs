using System;

namespace Data.Entities
{
    public class Rating : BaseClass
    {
        public int Id { get; set; }

        public int Rate { get; set; }

        public Guid UserId { get; set; }

        public int ProductId { get; set; }
    }
}
