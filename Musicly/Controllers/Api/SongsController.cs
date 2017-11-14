using Musicly.DataTransferObjects;
using Musicly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;



namespace Musicly.Controllers.Api
{
    public class SongsController : ApiController
    {
        //create a db context
        private ApplicationDbContext _context;

        public SongsController()
        {
            //initialize the db context within the constructor
            _context = new ApplicationDbContext();
        }

        //GET /api/songs
        public IEnumerable<SongDto> GetSongs()
        {
            return _context.Songs.ToList().Select(Mapper.Map<Song, SongDto>);
        }

        //GET /api/songss/id
        public IHttpActionResult GetSong(int id)
        {
            var song = _context.Songs.SingleOrDefault(s => s.Id == id);

            if (song == null)
                return NotFound();

            return Ok(Mapper.Map<Song, SongDto>(song));
        }

        //POST /api/songs
        [HttpPost]
        //changes status code from 200 to 201
        public IHttpActionResult CreateCustomer(SongDto songDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            // could be userd if returning the dto  throw new HttpResponseException(HttpStatusCode.BadRequest);

            var song = Mapper.Map<SongDto, Song>(songDto);

            _context.Songs.Add(song);
            _context.SaveChanges();

            songDto.Id = song.Id;

            return Created(new Uri(Request.RequestUri + "/" + song.Id), songDto);
        }

        //PUT /api/customers/id
        [HttpPut]
        public void UpdateCustomer(int id, SongDto songDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var songInDb = _context.Songs.SingleOrDefault(s => s.Id == id);

            if (songInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(songDto, songInDb);

            //customerInDb.Name = customerDto.Name;
            //customerInDb.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;
            //customerInDb.MembershipTypeId = customerDto.MembershipTypeId;
            //customerInDb.BirthDate = customerDto.BirthDate;

            _context.SaveChanges();
        }

        //DELETE /api/customers/id
        [HttpDelete]
        public void DeleteSong(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var songInDb = _context.Songs.SingleOrDefault(s => s.Id == id);

            if (songInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Songs.Remove(songInDb);
            _context.SaveChanges();
        }
    }
}
