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
        //Save database context
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
            var viewModel = new CustomerFormViewModel
            {
                //intialize new customer to fix no id value error
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            //just to show the create customer form
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            //validation
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                //not secure
                //TryUpdateModel(customerInDb);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers -> /customers -- ssr
        //public ViewResult Index()
        //{
        //    //Deffered execution
        //    //eager loading -> brining over related model information (foreign key)
        //    //only need to grab data from db for server side rendering
        //    //var customers = _context.Customers.Include(cust => cust.MembershipType).ToList();

        //    //return View(customers);

        //    return View();
        //}

        public ViewResult Index()
        {
            return View();
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

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}