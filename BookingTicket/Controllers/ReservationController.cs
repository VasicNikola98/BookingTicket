using BookingTicket.Entities.Entities;
using BookingTicket.Service;
using BookingTicket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingTicket.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult BookingStepOne()
        {
            ReservationViewModel model = new ReservationViewModel();
            model.Movies = MovieService.GetMovies();
            return PartialView(model);
        }

        public ActionResult BookingStepReserve()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult BookingReservationFinal(string chooseMovie, string chooseCity, string chooseDate,string chooseCinema,string chooseTime, string userEmail,string userPhoneNummber,string userTicket,string movieId)
        {
            Reservation reservation = new Reservation();
            reservation.MovieTitle = chooseMovie;
            reservation.City = chooseCity;
            reservation.Date = chooseDate;
            reservation.Time = chooseTime;
            reservation.Email = userEmail;
            reservation.PhoneNummber = userPhoneNummber;
            reservation.NummberOfTicket = userTicket;
            reservation.MovieId = movieId;
            reservation.Cinema = chooseCinema;

            ReservationService.AddReservation(reservation);
            return PartialView();
        }
    }
}