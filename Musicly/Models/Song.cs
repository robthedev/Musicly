using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musicly.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //navigation property
        public Genre Genre { get; set; }
        //foreign key
        public byte GenreId { get; set; }
    }
}