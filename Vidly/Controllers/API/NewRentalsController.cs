using System;
using System.Linq;
using System.Web.Http;
using Vidly.Contexts;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class NewRentalsController : ApiController
    {
        DBContext _context;

        public NewRentalsController()
        {
            _context = new DBContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (newRental.moviesIds.Count == 0)
                return BadRequest("No Movies IDs Have Been Given");

            if (newRental.customerId == 0)
                return BadRequest("No Customer ID Has Been Given");

            var customer = _context.Customers.SingleOrDefault(c => c.id == newRental.customerId);
            var movies = _context.Movies.Where(m => newRental.moviesIds.Contains(m.id)).ToList();

            if (movies.Count != newRental.moviesIds.Count)
                return BadRequest("One Or More Movie IDs are invalid.");

            if (customer == null)
                return BadRequest("Invalid Customer ID");

            foreach (var movie in movies)
            {
                if (movie.numberAvailable == 0)
                    return BadRequest("'" + movie.name + "'" + " Movie Is Not Available");

                var rental = new Rental
                {
                    customer = customer,
                    movie = movie,
                    DateRented = DateTime.Now,
                };

                movie.numberAvailable--;
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}