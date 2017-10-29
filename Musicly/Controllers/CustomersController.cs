﻿using System;
using System.Collections.Generic;
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

        // GET: Customers
        public ViewResult Index()
        {
            //Deffered execution
            var customers = _context.Customers.ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(cust => cust.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        
    }
}