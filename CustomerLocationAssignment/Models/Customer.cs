namespace CustomerLocationAssignment.Models
{
    public class Customer
    {
        public string customerId { get; set; } = String.Empty;
        public List<Address> locations { get; set; } = new List<Address>();
    }

    public class Address
    {
        public string street { get; set; } = String.Empty;
        public string town { get; set; } = String.Empty;
        public string city { get; set; } = String.Empty;
    }
    public class CustomerListClass
    {
        public List<Customer> customersList { get; set; } = new List<Customer>();
    }
}
