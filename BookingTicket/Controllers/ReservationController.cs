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
            return PartialView();
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