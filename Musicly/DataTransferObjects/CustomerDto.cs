using Musicly.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Musicly.DataTransferObjects
{
    public class CustomerDto
    {
        public int Id { get; set; }

        //Data annotations
        [Required(ErrorMessage = "Please enter name.")]
        [StringLength(255)]
        public string Name { get; set; }

        //nullable propperty
        //to update teh label text
        //[AdultMember]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //Foreign key
        //byte makes this implictly required
        public byte MembershipTypeId { get; set; }
    }
}