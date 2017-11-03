using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Musicly.Models;

namespace Musicly.Controllers
{
    public class CustomersController : Controller
    {
        //Create database context
        private ApplicationDbContext _context;

        public CustomersController()
        {
            //instatiate database context inside the contructor
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            return View();
        }

        // GET: Customers -> /customers
        public ViewResult Index()
        {
            //Deffered execution
            //eager loading -> brining over related model information (foreign key)
            var customers = _context.Customers.Include(cust => cust.MembershipType).ToList();

            return View(customers);
        }


        // /customer/details
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(cust => cust.MembershipType).SingleOrDefault(cust => cust.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        
    }
}