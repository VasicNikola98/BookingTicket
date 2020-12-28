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
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            var model = new MovieViewListingModel();
            model.Movies = MovieService.GetLastMovies(8);
            return View(model);
        }

        public ActionResult Details(string Id)
        {
            var model = new MovieViewModel();
            model.Movie = MovieService.GetMovieById(Id);
            return View(model);
        }

        public ActionResult AddMovie()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddMovie(Movie movie)
        {
            MovieService.AddMovie(movie);
            return RedirectToAction("Index", "Movie");
        }

        public ActionResult EditMovie()
        {
            return PartialView();
        }

    }
}