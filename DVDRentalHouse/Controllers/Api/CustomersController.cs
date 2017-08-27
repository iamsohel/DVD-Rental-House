using DVDRentalHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DVDRentalHouse.Controllers.Api
{
    
   
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
    }
}
