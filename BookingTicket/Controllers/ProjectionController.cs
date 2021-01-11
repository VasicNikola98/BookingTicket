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
    public class ProjectionController : Controller
    {
        // GET: Projection
        public ActionResult Index()
        {
            ProjectionViewListingModel model = new ProjectionViewListingModel();
            model.Projections = ProjectionService.GetProjections();
            return View(model);
        }
        public ActionResult AddProjection()
        {
            ProjectionViewModel model = new ProjectionViewModel();
            model.Movies = MovieService.GetMovies();
            model.Halls = HallService.GetHalls();
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult AddProjection(Projection projection)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            if(projection != null)
            {
                ProjectionService.AddProjection(projection);
                result.Data = new { Success = true };
            }
            else
            {
                result.Data = new { Success = false };
            }
            return result;
        }
    }
}