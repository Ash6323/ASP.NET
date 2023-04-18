using ReactCustomerLocation.Data.Models;
using ReactCustomerLocation.Data.Context;

namespace ReactCustomerLocation.Services.Interfaces
{
    public interface ICustomer
    {
        List<Customer> GetAllCustomer();
        Customer GetCustomer(int id);
        //int AddCustomer(Customer customer);
        //int UpdateCustomer(int id, Customer updatedCustomer);
        //int DeleteCustomer(int id);
    }

    public class CustomerService : ICustomer
    {
        private CustomerDbContext _context;

        public CustomerService(CustomerDbContext newContext)
        {
            _context = newContext;
        }

        //public static List<Customer> Customers = new List<Customer>();
        //public static int CustomerID = 1;
        //public static int LocationID = 1;
        public List<Customer> GetAllCustomer()
        {
            return _context.Customers.ToList();
        }
        public Customer GetCustomer(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }
        //public int AddCustomer(Customer customer)
        //{
        //    Customer result = _context.Customers.Where(w => w.CustomerId == customer.CustomerId).FirstOrDefault();
        //    if (result == null)
        //    {
        //        //customer.CustomerId = CustomerID++;
        //        //foreach (Address address in customer.Locations)
        //        //{
        //        //    address.Id = LocationID++;
        //        //}
        //        _context.Customers.Add(customer);
        //        _context.SaveChanges();
        //        return customer.CustomerId;
        //    }
        //    return -1;
        //}
        //public int UpdateCustomer(int id, Customer updatedCustomer)      //Parameter Removed - int locationID, Address address
        //{
        //    Customer customer = _context.Customers.FirstOrDefault(w => w.CustomerId == id);
        //    if (customer != null)
        //    {
        //        //Address customerAddress = customer.Locations.FirstOrDefault(w => w.Id == address.Id);
        //        //if (customerAddress != null)
        //        //{
        //        //    customerAddress.Street = address.Street;
        //        //    customerAddress.Town = address.Town;
        //        //    customerAddress.City = address.City;
        //        //    return customer.CustomerId;
        //        //}
        //        //else
        //        //    return 0;
        //        customer.Name = updatedCustomer.Name;
        //        customer.Email = updatedCustomer.Email;
        //        customer.Phone = updatedCustomer.Phone;
        //        _context.SaveChanges();
        //        return customer.CustomerId;
        //    }
        //    return -1;
        //}
        //public int DeleteCustomer(int id)
        //{
        //    Customer customer = _context.Customers.FirstOrDefault(w => w.CustomerId == id);
        //    //Address address = customer.Locations[0];
        //    //if (address.Id > 0)
        //    //{
        //    //    return -1;
        //    //}
        //    if (customer != null)
        //    {
        //        _context.Customers.Remove(customer);
        //        _context.SaveChanges();
        //        return customer.CustomerId;
        //    }
        //    else
        //        return 0;
        //}
    }
}


