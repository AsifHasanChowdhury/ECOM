﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Lib.BE
{
    public class login
    {
        public string email { get; set; }
        public string password { get; set; }

        public string verificationToken { get; set; }
    }
}
