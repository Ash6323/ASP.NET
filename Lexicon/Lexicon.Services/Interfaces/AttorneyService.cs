using Lexicon.Data.Models;
using Lexicon.Data.Context;
using Lexicon.Data.DTO;
using System.Web.Http.Description;

namespace Lexicon.Services.Interfaces
{
    public interface IAttorney
    {
        List<AttorneyDto> GetAttorneys();
        AttorneyDto GetAttorney(int id);
        int AddAttorney(AttorneyDto attorney);
        //int UpdateCustomer(int id, Customer updatedCustomer);
        //int DeleteCustomer(int id);
    }

    public class AttorneyService : IAttorney
    {
        private LexiconDbContext _context;
        public AttorneyService(LexiconDbContext newContext)
        {
            _context = newContext;
        }

        public List<AttorneyDto> GetAttorneys()
        {
            IQueryable<AttorneyDto> attorneys = from a in _context.Attorneys
                                select new AttorneyDto()
                                {
                                    Id = a.Id,
                                    Name = a.Name,
                                    Age = a.Age,
                                    Email = a.Email,
                                    Phone = a.Phone,
                                    Rate = a.Rate,
                                    JurisdictionId = a.JurisdictionId
                                };

            return attorneys.ToList();
        }
        public AttorneyDto GetAttorney(int id)
        {
            AttorneyDto attorney = (from a in _context.Attorneys where a.Id == id
                                    select new AttorneyDto()
                                    {
                                        Id = a.Id,
                                        Name = a.Name,
                                        Age = a.Age,
                                        Email = a.Email,
                                        Phone = a.Phone,
                                        Rate = a.Rate,
                                        JurisdictionId = a.JurisdictionId
                                    }).FirstOrDefault();
                return attorney;
        }
        public int AddAttorney(AttorneyDto attorney)
        {
            AttorneyDto result = (from a in _context.Attorneys
                                    where a.Id == attorney.Id
                                    select new AttorneyDto()
                                    {
                                        Id = a.Id,
                                        Name = a.Name,
                                        Age = a.Age,
                                        Email = a.Email,
                                        Phone = a.Phone,
                                        Rate = a.Rate,
                                        JurisdictionId = a.JurisdictionId
                                    }).FirstOrDefault();

            if (result == null)
            {
                Attorney newAttorney = new Attorney();
                {
                    newAttorney.Name = attorney.Name;
                    newAttorney.Age = attorney.Age;
                    newAttorney.Email = attorney.Email;
                    newAttorney.Phone = attorney.Phone;
                    newAttorney.Rate = attorney.Rate;
                    newAttorney.JurisdictionId = attorney.JurisdictionId;
                };
                _context.Attorneys.Add(newAttorney);
                _context.SaveChanges();
                return newAttorney.Id;
            }
            return -1;
        }
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
