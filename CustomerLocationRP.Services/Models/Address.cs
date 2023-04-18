
using System.ComponentModel.DataAnnotations;

namespace CustomerLocationRP.Services.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public int CustomerId { get; set; }     // Required foreign key property
        public Customer Customer { get; set; } = null!;     // Required reference navigation to principal
    }
}
