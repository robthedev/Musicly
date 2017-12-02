using Musicly.DataTransferObjects;
using Musicly.Models;
using System;
using System.Data.Entity;
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
        //public IEnumerable<SongDto> GetSongs()
        //{
        //    return _context.Songs.ToList().Select(Mapper.Map<Song, SongDto>);
        //}

        //api/songs
        public IHttpActionResult GetSongs(string query = null)
        {
            var songsquery = _context.Songs.Include(s => s.Genre);

            if (!String.IsNullOrWhiteSpace(query))
                songsquery = songsquery.Where(s => s.Name.Contains(query));

            var songDtos = songsquery
                .ToList()
                .Select(Mapper.Map<Song, SongDto>);

            return Ok(songDtos);
        }

        //GET /api/songs/id
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
        [Authorize(Roles = RoleName.CanManageSongs)]
        public IHttpActionResult CreateSong(SongDto songDto)
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
        [Authorize(Roles = RoleName.CanManageSongs)]
        public void UpdateSong(int id, SongDto songDto)
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
        [Authorize(Roles = RoleName.CanManageSongs)]
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
