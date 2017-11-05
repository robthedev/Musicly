using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Musicly.Models
{
    public class Song
    {
        public int Id { get; set; }

        //Data annotations
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }

        //navigation property
        public Genre Genre { get; set; }

        //foreign key
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
    }
}