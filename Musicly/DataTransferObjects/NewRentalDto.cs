using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musicly.DataTransferObjects
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> SongIds { get; set; }
    }
}