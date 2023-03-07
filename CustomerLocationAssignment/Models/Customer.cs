using System.Text.Json.Serialization;

namespace CustomerLocationAssignment.Models
{
    public class Customer
    {
        //[JsonPropertyName("CustomerID")]
        public string customerId { get; set; } = String.Empty;
        //[JsonPropertyName("Locations")]
        public List<Address> locations { get; set; } = new List<Address>();
    }

    public class Address
    {
        //[JsonPropertyName("Street")]
        public string street { get; set; } = String.Empty;
        //[JsonPropertyName("Town")]
        public string town { get; set; } = String.Empty;
        //[JsonPropertyName("City")]
        public string city { get; set; } = String.Empty;
        //[JsonPropertyName("Address")]
        //public List<string> address { get; set; } = new List<string>();
    }
    public class CustomerListClass
    {
        public List<Customer> customersList { get; set; } = new List<Customer>();
    }
}
