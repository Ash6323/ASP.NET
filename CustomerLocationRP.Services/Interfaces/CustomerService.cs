using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerLocationRP.Services.Models;

namespace CustomerLocationRP.Services.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomer();
        IEnumerable<Customer> GetCustomer(string id);
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(string id, string streetAddress, Address inputAddress);
        Customer DeleteCustomer(string id);
    }

    public class CustomerService : ICustomerService
    {
        internal static CustomerListClass AllCustomersData = new();

        public List<Customer> GetAllCustomer()
        {
            return AllCustomersData.CustomersList;
        }
        public IEnumerable<Customer> GetCustomer(string id)
        {
            if (AllCustomersData.CustomersList.Any(w => w.CustomerId == id))
            {
                return AllCustomersData.CustomersList.Where(w => w.CustomerId == id);
            }
            return null;
        }
        public Customer AddCustomer(Customer customer)
        {
            IEnumerable<Customer> result = AllCustomersData.CustomersList.Where(w => w.CustomerId == customer.CustomerId);
            if (result.Any())
            {
                return result.First();
            }
            else
            {
                AllCustomersData.CustomersList.Add(customer);
                return customer;
            }
        }
        public Customer UpdateCustomer(string id, string streetAddress, Address inputAddress)
        {
            Customer singleCustomer = AllCustomersData.CustomersList.FirstOrDefault(w => w.CustomerId == id);
            if (singleCustomer != null)
            {
                Address customerAddress = singleCustomer.Locations.FirstOrDefault(w => w.Street == streetAddress);
                customerAddress.Street = inputAddress.Street;
                customerAddress.Town = inputAddress.Town;
                customerAddress.City = inputAddress.City;
                return singleCustomer;
            }
            else
            {
                return null;
            }
        }
        public Customer DeleteCustomer(string id)
        {
            Customer singleCustomer = AllCustomersData.CustomersList.FirstOrDefault(w => w.CustomerId == id);
            if ((singleCustomer.Locations[0].Street != String.Empty) || (singleCustomer.Locations[0].Town != String.Empty) || (singleCustomer.Locations[0].City != String.Empty))
            {
                return singleCustomer;
            }
            else if (singleCustomer.Locations[0].Street == String.Empty && singleCustomer.Locations[0].Town == String.Empty && singleCustomer.Locations[0].City == String.Empty)
            {
                AllCustomersData.CustomersList.Remove(singleCustomer);
                return null;
            }
            else
            {
                return null;
            }
        }

    }
}
