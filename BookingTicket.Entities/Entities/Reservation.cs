using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTicket.Entities.Entities
{
    public class Reservation
    {
        public string  ReservationId { get; set; }
        public string MovieId { get; set; }
        public string City { get; set; }
        public string Date { get; set; }
        public string MovieTitle { get; set; }
        public string Time { get; set; }
        public string Email { get; set; }
        public string PhoneNummber { get; set; }
        public string NummberOfTicket { get; set; }
        public string Cinema { get; set; }

    }
}
