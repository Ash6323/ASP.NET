using Lexicon.Data.Models;
using Lexicon.Data.Context;
using Lexicon.Data.DTO;

namespace Lexicon.Services.Interfaces
{
    public interface IJurisdiction
    {
        List<JurisdictionDto> GetJurisdictions();
        //List<Customer> GetAllCustomer();
        //Customer GetCustomer(int id);
        //int AddCustomer(Customer customer);
        //int UpdateCustomer(int id, Customer updatedCustomer);
        //int DeleteCustomer(int id);
    }

    public class JurisdictionService : IJurisdiction
    {
        private LexiconDbContext _context;
        public JurisdictionService(LexiconDbContext newContext)
        {
            _context = newContext;
        }

        public List<JurisdictionDto> GetJurisdictions()
        {
            IQueryable<JurisdictionDto> jurisdictions = from j in _context.Jurisdictions
                                select new JurisdictionDto()
                                {
                                    Id = j.Id,
                                    Area = j.Area
                                };

            return jurisdictions.ToList();
        }

        //public List<Customer> GetAllCustomer()
        //{
        //    return _context.Customers.ToList();
        //}
        //public Customer GetCustomer(int id)
        //{
        //    return _context.Customers.FirstOrDefault(c => c.Id == id);
        //}
        //public int AddCustomer(Customer customer)
        //{
        //    Customer result = _context.Customers.FirstOrDefault(c => c.Id == customer.Id);
        //    if (result == null)
        //    {
        //        _context.Customers.Add(customer);
        //        _context.SaveChanges();
        //        return customer.Id;
        //    }
        //    return -1;
        //}
        //public int UpdateCustomer(int id, Customer updatedCustomer)
        //{
        //    Customer customer = _context.Customers.FirstOrDefault(c => c.Id == id);
        //    if (customer != null)
        //    {
        //        customer.Name = updatedCustomer.Name;
        //        customer.Email = updatedCustomer.Email;
        //        customer.Phone = updatedCustomer.Phone;
        //        customer.Street = updatedCustomer.Street;
        //        customer.Town = updatedCustomer.Town;
        //        customer.City = updatedCustomer.City;
        //        customer.zipcode = updatedCustomer.zipcode;
        //        _context.SaveChanges();
        //        return customer.Id;
        //    }
        //    return -1;
        //}
        //public int DeleteCustomer(int id)
        //{
        //    Customer customer = _context.Customers.FirstOrDefault(c => c.Id == id);
        //    if ( string.IsNullOrEmpty(customer.Street) && string.IsNullOrEmpty(customer.Town)  && 
        //         string.IsNullOrEmpty(customer.City) && string.IsNullOrEmpty(customer.zipcode))
        //    {
        //        _context.Customers.Remove(customer);
        //        _context.SaveChanges();
        //        return customer.Id;
        //    }
        //    else
        //        return 0;
        //}
    }
}
