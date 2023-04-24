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
        int UpdateAttorney(int id, AttorneyDto updatedAttorney);
        int DeleteAttorney(int id);
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
        public int UpdateAttorney(int id, AttorneyDto updatedAttorney)
        {
            AttorneyDto attorney = (from a in _context.Attorneys
                                  where a.Id == id
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
            if (attorney != null)
            {
                attorney.Name = updatedAttorney.Name;
                attorney.Age = updatedAttorney.Age;
                attorney.Email = updatedAttorney.Email;
                attorney.Phone = updatedAttorney.Phone;
                attorney.Rate = updatedAttorney.Rate;
                attorney.JurisdictionId = updatedAttorney.JurisdictionId;
                _context.SaveChanges();
                return attorney.Id;
            }
            else
                return 0;
        }
        public int DeleteAttorney(int id)
        {
            Attorney attorney = _context.Attorneys.FirstOrDefault(a => a.Id == id);
            if(attorney != null)
            {
                _context.Attorneys.Remove(attorney);
                _context.SaveChanges();
                return attorney.Id;
            }
            else
                return 0;
        }
    }
}
