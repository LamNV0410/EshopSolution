using System;
using System.Collections.Generic;
using System.Text;

namespace Common_API.Request
{
    public class GetAllProductAPI
    {
        public int pageIndex { get; set; } = 1;

        public int pageSize { get; set; }

        public int? CategoryId { get; set; } = null;
    }
}
