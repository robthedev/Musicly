using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Musicly.Models;

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

        // GET: Songs
        public ViewResult Index()
        {
            //Deffered execution
            //eager loading -> brining over related model information (foreign key)
            var songs = _context.Songs.Include(s => s.Genre).ToList();

            return View(songs);
        }

        public ActionResult Details(int id)
        {
            var song = _context.Songs.Include(s => s.Genre).SingleOrDefault(s => s.Id == id);

            if (song == null)
                return HttpNotFound();

            return View(song);
        }
    }

}