using System;
using System.Collections.Generic;
using System.Text;

namespace Common_API.Request
{
    public class APIUserLoginRequest
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsRememberMe { get; set; } = false;
    }
}
