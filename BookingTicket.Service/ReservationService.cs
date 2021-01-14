using BookingTicket.Entities;
using BookingTicket.Entities.Entities;
using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTicket.Service
{
    public class ReservationService
    {
        public static void AddReservation(Reservation reservation)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            reservation.ReservationId = Guid.NewGuid().ToString();

            RowSet reservationData = session.Execute("insert into \"Reservation\" (\"ReservationId\",\"MovieId\", \"City\", \"Date\", \"MovieTitle\", \"Time\", \"Email\",\"PhoneNummber\",\"NummberOfTicket\",\"Cinema\")  values ('" + reservation.ReservationId + "', '" + reservation.MovieId + "', '" + reservation.City + "', '" + reservation.Date + "', '" + reservation.MovieTitle + "', '" + reservation.Time + "','" + reservation.Email + "','" + reservation.PhoneNummber + "','" + reservation.NummberOfTicket + "', '" + reservation.Cinema + "')");


        }
    }
}
