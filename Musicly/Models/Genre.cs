using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Musicly.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        //Data annotations
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}