using System;
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

        //nullable propperty
        //to update teh label text
        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //Navigation property
        public MembershipType MembershipType { get; set; }

        //Foreign key
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}