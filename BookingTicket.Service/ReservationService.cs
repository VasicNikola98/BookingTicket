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

        public static List<Reservation> GetReservations()
        {
            ISession session = SessionManager.GetSession();
            List<Reservation> reservations = new List<Reservation>();


            if (session == null)
                return null;

            var reservationsData = session.Execute("select * from \"Reservation\"");


            foreach (var reservationData in reservationsData)
            {
                Reservation reservation = new Reservation();
                reservation.ReservationId = reservationData["ReservationId"] != null ? reservationData["ReservationId"].ToString() : string.Empty;
                reservation.MovieId = reservationData["MovieId"] != null ? reservationData["MovieId"].ToString() : string.Empty;
                reservation.City = reservationData["City"] != null ? reservationData["City"].ToString() : string.Empty;
                reservation.Date = reservationData["Date"] != null ? reservationData["Date"].ToString() : string.Empty;
                reservation.MovieTitle = reservationData["MovieTitle"] != null ? reservationData["MovieTitle"].ToString() : string.Empty;
                reservation.Time = reservationData["Time"] != null ? reservationData["Time"].ToString() : string.Empty;
                reservation.Email = reservationData["Email"] != null ? reservationData["Email"].ToString() : string.Empty;
                reservation.PhoneNummber = reservationData["PhoneNummber"] != null ? reservationData["PhoneNummber"].ToString() : string.Empty;
                reservation.NummberOfTicket = reservationData["NummberOfTicket"] != null ? reservationData["NummberOfTicket"].ToString() : string.Empty;
                reservation.Cinema = reservationData["Cinema"] != null ? reservationData["Cinema"].ToString() : string.Empty;
                reservations.Add(reservation);
            }
            return reservations;
        }
    }
}
