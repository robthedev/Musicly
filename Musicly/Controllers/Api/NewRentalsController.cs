using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Musicly.DataTransferObjects;
using Musicly.Models;

namespace Musicly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        //create a db context
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            //initialize the db context within the constructor
            _context = new ApplicationDbContext();
        }

        //api/newrentals
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            //single over singleordefualt for internal purposes, customer being picked from data list
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);
            var songs = _context.Songs.Where(s => newRental.SongIds.Contains(s.Id));

            //each rented song creates a new rental object
            foreach (var song in songs)
            {
                var rental = new Rental
                {
                    Customer = customer,
                    Song = song,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
