using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.Provider;
using System.ComponentModel.DataAnnotations;
using Musicly.Models;

namespace Musicly.ViewModels
{
    public class SongFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        //Data annotations
        [Required(ErrorMessage = "Name field is required")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Release date field is required")]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        [Range(1, 20, ErrorMessage = "Stock must be between 1 and 20")]
        [Display(Name = "Number in Stock")]
        public int? NumberInStock { get; set; }

        //foreign key
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        //contructor for exitiing song
        public SongFormViewModel()
        {
            Id = 0;
        }

        //contructor for exitiing song
        public SongFormViewModel(Song song)
        {
            Id = song.Id;
            Name = song.Name;
            ReleaseDate = song.ReleaseDate;
            NumberInStock = song.NumberInStock;
            GenreId = song.GenreId;
        }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Song" : "New Song";
            }
        }
    }
}