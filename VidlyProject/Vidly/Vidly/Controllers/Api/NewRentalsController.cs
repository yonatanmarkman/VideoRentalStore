using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Dtos;


namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // Load the customer and the movies, based on the IDs
        // that the DTO gives us, and then for each movie,
        // Create a new rental object for that movie and the customer,
        // and then add that object to the DB.
        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
            // We use Single here instead of SingleOrDefault,
            // because we want to return an exception if the Id doesn't exist.
            var customer = _context.Customers.Single(
                c => c.Id == newRental.customerId);
            /*
             If we would use SingleOrDefault, we would need to throw 
             the exception manually, like this:
            if (customer == null)
                return BadRequest("Invalid customer ID.");
             */

            // Get all the movies m so that m.Id is inside the 
            // rented movie's Id list.
            var movies = _context.Movies.Where(
                m => newRental.movieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available.");
                }

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
         }

        public IHttpActionResult GetRentals()
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult GetRental(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IHttpActionResult UpdateRental(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IHttpActionResult DeleteRental(int id)
        {
            throw new NotImplementedException();
        }
    }
}