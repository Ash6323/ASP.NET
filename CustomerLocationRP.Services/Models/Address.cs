using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLocationRP.Services.Models
{
    public class Address
    {
        public string Street { get; set; } = String.Empty;
        public string Town { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
    }
}
