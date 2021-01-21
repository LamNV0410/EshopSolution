using System;
using System.Collections.Generic;
using System.Text;

namespace Common_API.Respone
{
    public class ProductsPagingResponse<T> : PagedResultBase
    {
        public ICollection<T> Items { get; set; }
    }
}
