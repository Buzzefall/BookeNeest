﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookeNeest.Web.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
    }
}