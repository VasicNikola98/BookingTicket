using BookingTicket.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingTicket.ViewModels
{
    public class ReservationViewModel
    {
        public List<Movie> Movies { get; set; }
    }

    public class ReservationFinalViewModel
    {
        public Reservation Reservation { get; set; }
    }

    public class ReservationAdminViewModel
    {
        public List<Reservation> Reservations { get; set; }
    }

}