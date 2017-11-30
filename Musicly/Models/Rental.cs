using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Musicly.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime DateReturned { get; set; }
        public Customer Customer { get; set; }
        public Song Song { get; set; }

        public int CustomerId { get; set; }
        public int SongId { get; set; }
        public List<int> SongIds { get; set; }
    }
}