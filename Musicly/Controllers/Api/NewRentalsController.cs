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
            //for public api
            //if (newRental.SongIds.Count == 0)
                //return BadRequest("No songs rented");

            //single over singleordefualt for internal purposes, customer being picked from data list
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            //for public api
            //var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
             //if (customer == null)
               // return BadRequest("CustomerId in not valid");

            var songs = _context.Songs.Where(s => newRental.SongIds.Contains(s.Id)).ToList();

            //for public api
            //if (songs.Count != newRental.SongIds.Count)
                //return BadRequest("One or More of the songs are invlaid");

            //each rented song creates a new rental object
            foreach (var song in songs)
            {
                if (song.NumberAvailable == 0)
                    return BadRequest("Song is not available");

                song.NumberAvailable--;

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
