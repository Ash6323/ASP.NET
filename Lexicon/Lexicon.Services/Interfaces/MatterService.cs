using Lexicon.Data.Context;
using Lexicon.Data.DTO;
using Lexicon.Data.Mapper;
using Lexicon.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Lexicon.Services.Interfaces
{
    public interface IMatter
    {
        List<MatterDto> GetMatters();
        MatterDto GetMatter(int id);
        List<IGrouping<int, MattersByClientsDTO>> GetMattersByClients();
        List<MatterForClientDTO> GetMattersForClient(int clientId);
        int AddMatter(MatterDto matter);
        int UpdateMatter(int id, MatterDto updatedmatter);
        int DeleteMatter(int id);
    }
    public class MatterService : IMatter
    {
        private LexiconDbContext _context;
        public MatterService(LexiconDbContext newContext)
        {
            _context = newContext;
        }
        public List<MatterDto> GetMatters()
        {
            List<MatterDto> matters = (from m in _context.Matters
                                        select new MatterDto()
                                        {
                                            Id = m.Id,
                                            Title = m.Title,
                                            Description = m.Description,
                                            IsActive = m.IsActive,
                                            JurisdictionId = m.JurisdictionId,
                                            ClientId = m.ClientId,
                                            BillingAttorneyId = m.BillingAttorneyId,
                                            ResponsibleAttorneyId = m.ResponsibleAttorneyId
                                        }).ToList();

            return matters;
        }
        public MatterDto GetMatter(int id)
        {
            MatterDto matter = (from m in _context.Matters
                                where m.Id == id
                                select new MatterDto()
                                {
                                    Id = m.Id,
                                    Title = m.Title,
                                    Description = m.Description,
                                    IsActive = m.IsActive,
                                    JurisdictionId = m.JurisdictionId,
                                    ClientId = m.ClientId,
                                    BillingAttorneyId = m.BillingAttorneyId,
                                    ResponsibleAttorneyId = m.ResponsibleAttorneyId
                                }).FirstOrDefault();
            return matter;
        }
        public List<IGrouping<int, MattersByClientsDTO>> GetMattersByClients()
        {
            //List<IGrouping<int, MattersByClientsDTO>> matters = (from m in _context.Matters
            //                           select new MattersByClientsDTO()
            //                           {
            //                               ClientId = m.ClientId,
            //                               Matters = new List<MatterDto>()
            //                               {
            //                                   new MatterDto()
            //                                   {
            //                                       Id = m.Id,
            //                                       Title = m.Title,
            //                                       Description = m.Description,
            //                                       IsActive = m.IsActive,
            //                                       JurisdictionId = m.JurisdictionId,
            //                                       ClientId = m.ClientId,
            //                                       BillingAttorneyId = m.BillingAttorneyId,
            //                                       ResponsibleAttorneyId = m.ResponsibleAttorneyId
            //                                   }
            //                               }
            //                           }).GroupBy(m => m.ClientId).ToList();

            //return matters;
            return null;
        }
        public List<MatterForClientDTO> GetMattersForClient(int clientId)
        {
            IQueryable<Matter> mattersByClient = _context.Matters
            .Include(m => m.BillingAttorney)
            .Include(m => m.ResponsibleAttorney)
            .Include(m => m.Jurisdiction)
            .Include(m => m.Client)
            .Where(c => c.ClientId.Equals(clientId));

            return mattersByClient.Select(c => new MattersForClientMapper().Map(c)).ToList();
        }
        public int AddMatter(MatterDto matter)
        {
            Attorney billingAttorneyCheck = _context.Attorneys.FirstOrDefault(a => a.Id == matter.BillingAttorneyId);
            Attorney responsibleAttorneyCheck = _context.Attorneys.FirstOrDefault(a => a.Id == matter.ResponsibleAttorneyId);

            if (billingAttorneyCheck!.JurisdictionId != matter.JurisdictionId)
            {
                return (-1);
            }
            //if (responsibleAttorneyCheck!.JurisdictionId != matter.JurisdictionId)
            //{
            //    return (0);
            //}

            Matter newMatter = new Matter();
            {
                newMatter.Title = matter.Title;
                newMatter.Description = matter.Description;
                newMatter.IsActive = matter.IsActive;
                newMatter.JurisdictionId = matter.JurisdictionId;
                newMatter.ClientId = matter.ClientId;
                newMatter.BillingAttorneyId = matter.BillingAttorneyId;
                newMatter.ResponsibleAttorneyId = matter.ResponsibleAttorneyId;
            }
            _context.Matters.Add(newMatter);
            _context.SaveChanges();
            return newMatter.Id;
        }
        public int UpdateMatter(int id, MatterDto updatedMatter)
        {
            MatterDto matter = (from m in _context.Matters
                                where m.Id == id
                                select new MatterDto()
                                {
                                    Id = m.Id,
                                    Title = m.Title,
                                    Description = m.Description,
                                    IsActive = m.IsActive,
                                    JurisdictionId = m.JurisdictionId,
                                    ClientId = m.ClientId,
                                    BillingAttorneyId = m.BillingAttorneyId,
                                    ResponsibleAttorneyId = m.ResponsibleAttorneyId
                                }).FirstOrDefault();
            if (matter != null)
            {
                matter.Title = updatedMatter.Title;
                matter.IsActive = updatedMatter.IsActive;
                matter.Description = updatedMatter.Description;
                matter.JurisdictionId = updatedMatter.JurisdictionId;
                matter.ClientId = updatedMatter.ClientId;
                matter.BillingAttorneyId = updatedMatter.BillingAttorneyId;
                matter.ResponsibleAttorneyId = updatedMatter.ResponsibleAttorneyId;
                _context.SaveChanges();
                return matter.Id;
            }
            else
                return 0;
        }
        public int DeleteMatter(int id)
        {
            Matter matter = _context.Matters.FirstOrDefault(m => m.Id == id);
            if (matter != null)
            {
                _context.Matters.Remove(matter);
                _context.SaveChanges();
                return matter.Id;
            }
            else
                return 0;
        }
    }
}
//public List<MatterDto> GetMattersByClientId(int clientId)
//{
//var matters = _dbContext.Matters.Where(m => m.ClientId == clientId).ToList();
//return matters.Select(m => new MatterDto(m)).ToList();
//}