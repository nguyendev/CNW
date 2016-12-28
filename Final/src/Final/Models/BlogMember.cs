﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Final.Models
{
    // Add profile data for application users by adding properties to the BlogMember class
    public class BlogMember : IdentityUser
    {
        public string ImageURL { get; set; }
        public string ImageURL1 { get; set; }
    }
}
