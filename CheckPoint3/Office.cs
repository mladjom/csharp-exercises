using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint3
{
    class Office
    {
       public Office()
        {
        }
        public Office(int id, string city, string country, string currency)
        {
            Id = id;
            City = city;
            Country = country;
            Currency = currency;
        }
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
    }
}
