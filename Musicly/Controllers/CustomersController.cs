using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Musicly.Models;
using Musicly.ViewModels;

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
            //iniatialize the class and set the MembershipType property to the membershipTypes list
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
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

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("New");
        }
    }
}