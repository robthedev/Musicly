using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Musicly.Models;

namespace Musicly.ViewModels
{
    public class SongFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Song Song { get; set; }
    }
}