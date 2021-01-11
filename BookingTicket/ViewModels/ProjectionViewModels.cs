using BookingTicket.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingTicket.ViewModels
{
    public class ProjectionViewModel
    {
        public List<Movie> Movies  { get; set; }
        public List<Hall> Halls { get; set; }
    }

    public class ProjectionViewListingModel
    {
        public List<Projection> Projections { get; set; }
    }
}