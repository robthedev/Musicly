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
        [Required(ErrorMessage = "Name field is required")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Release date field is required")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        [Range(1, 20, ErrorMessage = "Stock must be between 1 and 20")]
        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }

        //navigation property
        public Genre Genre { get; set; }

        //foreign key
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
    }
}