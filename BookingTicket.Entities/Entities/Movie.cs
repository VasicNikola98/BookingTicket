using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTicket.Entities.Entities
{
    public class Movie
    { 
        public string MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string RunTime { get; set; }
        public string ImageUrl { get; set; }
        public string Starring { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }

    }
}
