
namespace CustomerLocationRP.Services.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; } = String.Empty;
        public string Town { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
    }
}
