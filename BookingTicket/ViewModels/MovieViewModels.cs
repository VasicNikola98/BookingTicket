﻿using BookingTicket.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingTicket.ViewModels
{
    public class MovieViewListingModel
    {
        public List<Movie> Movies { get; set; }
    }

    public class MovieViewModel
    {
        public Movie Movie { get; set; }
    }
}