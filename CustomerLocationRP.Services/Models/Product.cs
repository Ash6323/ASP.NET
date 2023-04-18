using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLocationRP.Services.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; } // Required foreign key property
        public List<Customer> Customers { get; } = null!; // Required reference navigation to principal
        public List<CustomerProduct> CustomerProducts { get; } = new();
    }
    public class CustomerProduct
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public Customer Customer { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
