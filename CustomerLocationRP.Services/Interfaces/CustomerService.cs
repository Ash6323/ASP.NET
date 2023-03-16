
using CustomerLocationRP.Services.Models;

namespace CustomerLocationRP.Services.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomer();
        Customer GetCustomer(string id);
        string AddCustomer(Customer customer);
        string UpdateCustomer(string id, int locationID, string street, string town, string city);
        string DeleteCustomer(string id);
    }

    public class CustomerService : ICustomerService
    {
        public static List<Customer> Customers = new();
        public List<Customer> GetAllCustomer()
        {
            return Customers;
        }
        public Customer GetCustomer(string id)
        {
            return Customers.Where(w => w.CustomerId == id).FirstOrDefault();
        }
        public string AddCustomer(Customer customer)
        {
            if (customer.CustomerId.Equals(string.Empty))
                return "-2";
            Customer result = Customers.Where(w => w.CustomerId == customer.CustomerId).FirstOrDefault();
            if (result == null)
            {
                Customers.Add(customer);
                return customer.CustomerId;
            }
            return "-1";
        }
        public string UpdateCustomer(string id, int locationID, string street, string town, string city)
        {
            Customer customer = Customers.FirstOrDefault(w => w.CustomerId == id);
            if (customer != null)
            {
                Address customerAddress = customer.Locations.FirstOrDefault(w => w.Id == locationID);
                if (customerAddress != null)
                {
                    if (customerAddress.Id.Equals(0))
                    {
                        return "-2";
                    }
                    customerAddress.Street = street;
                    customerAddress.Town = town;
                    customerAddress.City = city;
                    return customer.CustomerId;
                }
                else
                    return "-2";
            }
            return "-1";
        }
        public string DeleteCustomer(string id)
        {
            Customer customer = Customers.FirstOrDefault(w => w.CustomerId == id);
            if ((customer.Locations[0].Street != String.Empty) || (customer.Locations[0].Town != String.Empty) || (customer.Locations[0].City != String.Empty))
            {
                return "-1";
            }
            else if (customer.Locations[0].Street == String.Empty && customer.Locations[0].Town == String.Empty && customer.Locations[0].City == String.Empty)
            {
                Customers.Remove(customer);
                return customer.CustomerId;
            }
            return "-2";
        }
    }
}
