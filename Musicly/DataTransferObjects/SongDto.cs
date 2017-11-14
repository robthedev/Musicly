using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Musicly.Models;

namespace Musicly.DataTransferObjects
{
    public class SongDto
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

        //foreign key
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
    }
}