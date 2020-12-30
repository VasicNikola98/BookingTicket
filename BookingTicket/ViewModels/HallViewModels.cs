using BookingTicket.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingTicket.ViewModels
{
    public class HallViewListingModel
    {
        public List<Hall> Halls { get; set; }
    }

    public class HallViewModel
    {
        public Hall Hall { get; set; }
    }
}