﻿using Musicly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musicly.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}