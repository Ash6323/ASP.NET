
using CustomerLocationRP.Services.Models;

namespace CustomerLocationRP.Services.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomer();
        Customer GetCustomer(int id);
        int AddCustomer(Customer customer);
        int UpdateCustomer(int id, int locationID, Address address);
        int DeleteCustomer(int id);
    }

    public class CustomerService : ICustomerService
    {
        public static List<Customer> Customers = new List<Customer>();
        public static int custID = 1;
        public List<Customer> GetAllCustomer()
        {
            return Customers;
        }
        public Customer GetCustomer(int id)
        {
            return Customers.Where(w => w.CustomerId == id).FirstOrDefault();
        }
        public int AddCustomer(Customer customer)
        {
            Customer result = Customers.Where(w => w.CustomerId == customer.CustomerId).FirstOrDefault();
            if (result == null)
            {
                customer.CustomerId = custID++;
                Customers.Add(customer);
                return customer.CustomerId;
            }
            return -1;
        }
        public int UpdateCustomer(int id, int locationID, Address address)
        {
            Customer customer = Customers.FirstOrDefault(w => w.CustomerId == id);
            if (customer != null)
            {
                Address customerAddress = customer.Locations.FirstOrDefault(w => w.Id == address.Id);
                if (customerAddress != null)
                {
                    customerAddress.Street = address.Street;
                    customerAddress.Town = address.Town;
                    customerAddress.City = address.City;
                    return customer.CustomerId;
                }
                else
                    return 0;
            }
            return -1;
        }
        public int DeleteCustomer(int id)
        {
            Customer customer = Customers.FirstOrDefault(w => w.CustomerId == id);
            Address location = customer.Locations[0];
            if (location.Id > 0)
            {
                return -1;
            }
            else if (location.Id < 1)
            {
                Customers.Remove(customer);
                return customer.CustomerId;
            }
            return 0;
        }
    }
}
