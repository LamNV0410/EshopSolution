﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Common_API.Request
{
    public class APIUserUpdateRequest
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public byte Gender { get; set; }
    }
}
