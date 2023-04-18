
using System.ComponentModel.DataAnnotations;

namespace ReactCustomerLocation.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Street { get; set; }
        public string? Town { get; set; }
        public string? City { get; set; }
        public string? zipcode { get; set; }

    }
}
