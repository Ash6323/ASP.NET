using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLocationRP.Services.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public List<Address> Locations { get; set; } = new List<Address>();
    }
}
