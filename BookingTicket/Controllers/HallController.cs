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
    public class HallController : Controller
    {
        public ActionResult Index()
        {
            HallViewListingModel model = new HallViewListingModel();
            model.Halls = HallService.GetHalls();
            return View(model);
        }

        #region Create
        public ActionResult AddHall()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddHall(Hall hall)
        {
            HallService.AddHall(hall);
            return RedirectToAction("Index", "Hall");
        }
        #endregion

        #region Edit
        public ActionResult EditHall(string Id)
        {
            var model = new HallViewModel();
            model.Hall = HallService.GetHallById(Id);

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditHall(Hall hall)
        {
            HallService.EditHall(hall);
            return RedirectToAction("Index", "Hall");
        }
        #endregion

        #region Delete
        public ActionResult DeleteHall(string Id)
        {
            HallService.DeleteHall(Id);
            return RedirectToAction("Index", "Hall");
        }
        #endregion
    }
}