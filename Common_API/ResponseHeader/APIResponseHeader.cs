using System;
using System.Collections.Generic;
using System.Text;

namespace Common_API.ResponseHeader
{
    public class APIResponseHeader
    {
        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// MessageId
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }
    }
}
