using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace CustomerLocationRP.Services.Models
{
    public class Spouse
    {
        public int SpouseId { get; set; }
        public string Name { get; set; }
        public int CustomerId { get; set; } // Required foreign key property
        public Customer Customer { get; set; } = null!; // Required reference navigation to principal
    }
}
