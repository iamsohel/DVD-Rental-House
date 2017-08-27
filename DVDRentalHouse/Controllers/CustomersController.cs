using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVDRentalHouse.Models;
using DVDRentalHouse.ViewModels;

namespace DVDRentalHouse.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
                            
            return View(customers);
        }
        // New Customer 
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("New", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if(customer.Id==0)
                _context.Customers.Add(customer);
            else
            {
                var customerIbDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerIbDb.Birthdate = customer.Birthdate;
                customerIbDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerIbDb.MembershipTypeId = customer.MembershipTypeId;
                customerIbDb.Name = customer.Name;

            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel =new NewCustomerViewModel{
                Customer=customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };
            return View("New",viewModel);
        }

        // Details
        public ActionResult Details(int id)
        {
            var customers = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customers == null)
                return HttpNotFound();
            return View(customers);
        }

        
    }
}