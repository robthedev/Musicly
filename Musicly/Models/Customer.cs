﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Musicly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        //Data annotations
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        //Navigation property
        public MembershipType MembershipType { get; set; }
        //Foreign key
        public byte MembershipTypeId { get; set; }
    }
}