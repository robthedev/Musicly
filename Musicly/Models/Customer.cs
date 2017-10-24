﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musicly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        //Navigation property
        public MembershipType MembershipType { get; set; }
        //Foreign key
        public byte MembershipTypeId { get; set; }
    }
}