﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class BaseClass
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
