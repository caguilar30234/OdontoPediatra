﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Authentication
{
    public class ApplicationUser: IdentityUser
    {
        public string Identification { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
