using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.Provider;
using Musicly.Models;

namespace Musicly.ViewModels
{
    public class SongFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public Song Song { get; set; }

        public string Title
        {
            get
            {
                if (Song != null && Song.Id != 0)
                    return "Edit Song";

                return "New Song";
            }
        }
    }
}