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

        public ActionResult BookingStepTwo()
        {
            return PartialView();
        }

        public ActionResult BookingStepReserve()
        {
            return PartialView();
        }

        public ActionResult BookingReservationFinal()
        {
            return PartialView();
        }
    }
}