using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDRentalHouse.Models;

namespace DVDRentalHouse.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}