﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Musicly.Models;
using Musicly.ViewModels;

namespace Musicly.Controllers
{
    public class SongsController : Controller
    {
        //Save database context
        private ApplicationDbContext _context;

        public SongsController()
        {
            //instatiate database context inside the contructor
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Songs  -- for ssr
        //public ViewResult Index()
        //{
        //    //Deffered execution
        //    //eager loading -> brining over related model information (foreign key)
        //    var songs = _context.Songs.Include(s => s.Genre).ToList();



        //    return View(songs);
        //}
        //GET: songs ccr
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageSongs))
                return View("Index");

            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageSongs)]
        public ActionResult New()
        {
            //iniatialize the class and set the genre property to the genres list
            var genres = _context.Genres.ToList();
            var viewModel = new SongFormViewModel
            {
                Genres = genres
            };

            return View("SongForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Song song)
        {
            //validation
            if (!ModelState.IsValid)
            {
                var viewModel = new SongFormViewModel(song)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("SongForm", viewModel);
            }
            if (song.Id == 0)
                _context.Songs.Add(song);
            else
            {
                var songInDb = _context.Songs.Single(s => s.Id == song.Id);

                songInDb.Name = song.Name;
                songInDb.ReleaseDate = song.ReleaseDate;
                songInDb.NumberInStock = song.NumberInStock;
                songInDb.Name = song.Name;
                songInDb.GenreId = song.GenreId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Songs");
        }
        
        public ActionResult Details(int id)
        {
            var song = _context.Songs.Include(s => s.Genre).SingleOrDefault(s => s.Id == id);

            if (song == null)
                return HttpNotFound();

            return View(song);
        }

        [Authorize(Roles = RoleName.CanManageSongs)]
        public ActionResult Edit(int id)
        {
            var song = _context.Songs.SingleOrDefault(s => s.Id == id);

            if (song == null)
                return HttpNotFound();

            var viewModel = new SongFormViewModel(song)
            {
                Genres = _context.Genres.ToList()
            };

            return View("SongForm", viewModel);
        }
    }

}