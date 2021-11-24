using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Contexts;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        DBContext _context;
        List<Movie> movies;
        public MoviesController()
        {
            _context = new DBContext();
            movies = _context.Movies.ToList();
        }

        // GET: Movies
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.canManageMovies))
                return View("List");

            else return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var movie = movies.SingleOrDefault(m => m.id == id);

            if (movie != null)
                return View(movie);

            return HttpNotFound();
        }

        [Authorize(Roles = RoleName.canManageMovies)]
        public ActionResult Add()
        {
            return View("movieForm", new Movie());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.canManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
                return View("movieForm", movie);

            if (movie.id == 0)
            {
                movie.numberAvailable = movie.numberInStock;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.id == movie.id);
                movieInDb.name = movie.name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.genre = movie.genre;
                movieInDb.numberInStock = movie.numberInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("index", "Movies");
        }

        [Authorize(Roles = RoleName.canManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.id == id);

            if (movie == null)
                return HttpNotFound();

            return View("movieForm", movie);
        }

        //public ActionResult Random()
        //{
        //    var movie = new Movie(){
        //        name = "Shrek !",
        //    };

        //    var movies = new List<movie>
        //    {
        //        new movie {name = "Ahmed"},
        //        new movie {name = "Youssef"},
        //        new movie {name = "Omnia"},
        //        new movie {name = "Ali"},
        //        new movie {name = "Abdelrahman"},
        //        new movie {name = "Dina"},
        //    };

        //    var viewModel = new RandomMovieViewModel()
        //    {
        //        movie = movie,
        //        movies = movies
        //    };

        //    return View(viewModel);
        //}

        //[Route("movies/release/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        //public ActionResult ByReleaseDate (int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}
    }
}