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
    public class Response<T>
    {
        public Response(int status, string responseMessage, T data)
        {
            this.statusCode = status;
            this.message = responseMessage;
            this.data = data;
        }
        public int statusCode { get; set; }
        public string message { get; set; } = String.Empty;
        public T data { get; set; }
    }
}

