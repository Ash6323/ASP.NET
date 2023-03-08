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
    public class CustomerListResponse
    {
        public CustomerListResponse(int status, string responseMessage, List<Customer> listData)
        {
            this.statusCode = status;
            this.message = responseMessage;
            this.customerListData = listData;
        }
        public int statusCode { get; set; }
        public string message { get; set; } = String.Empty;
        public List<Customer> customerListData { get; set; } = null;
    }
    public class CustomerEnumerableResponse
    {
        public CustomerEnumerableResponse(int status, string responseMessage, IEnumerable<Customer> customerData)
        {
            this.statusCode = status;
            this.message = responseMessage;
            this.customerData = customerData;
        }
        public int statusCode { get; set; }
        public string message { get; set; } = String.Empty;
        public IEnumerable<Customer> customerData { get; set; } = Enumerable.Empty<Customer>();

    }
    public class CustomerResponse
    {
        public CustomerResponse(int status, string responseMessage, Customer customerData)
        {
            this.statusCode = status;
            this.message = responseMessage;
            this.customerObjectData = customerData;
        }
        public int statusCode { get; set; }
        public string message { get; set; } = String.Empty;
        public Customer customerObjectData { get; set; } = null;
    }
}

