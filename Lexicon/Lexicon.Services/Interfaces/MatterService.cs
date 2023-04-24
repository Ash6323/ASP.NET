using Lexicon.Data.Context;
using Lexicon.Data.DTO;
using Lexicon.Data.Models;

namespace Lexicon.Services.Interfaces
{
    public interface IMatter
    {
        List<MatterDto> GetMatters();
        MatterDto GetMatter(int id);
        IEnumerable<IGrouping<int, MatterDto>> GetMattersByClients();
        List<MatterDto> GetMattersByClient(int clientId);
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
            IQueryable<MatterDto> matters = from m in _context.Matters
                                            select new MatterDto()
                                            {
                                                Id = m.Id,
                                                Title = m.Title,
                                                IsActive = m.IsActive,
                                                JurisdictionId = m.JurisdictionId,
                                                ClientId = m.ClientId,
                                                BillingAttorneyId = m.BillingAttorneyId,
                                                ResponsibleAttorneyId = m.ResponsibleAttorneyId
                                            };

            return matters.ToList();
        }
        public MatterDto GetMatter(int id)
        {
            MatterDto matter = (from m in _context.Matters where m.Id == id
                                            select new MatterDto()
                                            {
                                                Id = m.Id,
                                                Title = m.Title,
                                                IsActive = m.IsActive,
                                                JurisdictionId = m.JurisdictionId,
                                                ClientId = m.ClientId,
                                                BillingAttorneyId = m.BillingAttorneyId,
                                                ResponsibleAttorneyId = m.ResponsibleAttorneyId
                                            }).FirstOrDefault();
            return matter;
        }
        public IEnumerable<IGrouping<int, MatterDto>> GetMattersByClients()
        {
            IEnumerable<IGrouping<int, MatterDto>> matters = (from m in _context.Matters
                                       //group m by m.ClientId into g
                                       select new MatterDto()
                                       {
                                           Id = m.Id,
                                           Title = m.Title,
                                           IsActive = m.IsActive,
                                           JurisdictionId = m.JurisdictionId,
                                           ClientId = m.ClientId,
                                           BillingAttorneyId = m.BillingAttorneyId,
                                           ResponsibleAttorneyId = m.ResponsibleAttorneyId
                                       }).GroupBy(m => m.ClientId).ToList();

            return matters;
        }
        public List<MatterDto> GetMattersByClient(int clientId)
        {
            List<MatterDto> matters = (from m in _context.Matters where m.ClientId == clientId
                                             select new MatterDto()
                                             {
                                                 Id = m.Id,
                                                 Title = m.Title,
                                                 IsActive = m.IsActive,
                                                 JurisdictionId = m.JurisdictionId,
                                                 ClientId = m.ClientId,
                                                 BillingAttorneyId = m.BillingAttorneyId,
                                                 ResponsibleAttorneyId = m.ResponsibleAttorneyId
                                             }).ToList();
            return matters;
        }
        public int AddMatter(MatterDto matter)
        {
            MatterDto result = (from m in _context.Matters
                                where m.Id == matter.Id
                                select new MatterDto()
                                {
                                    Id = m.Id,
                                    Title = m.Title,
                                    IsActive = m.IsActive,
                                    JurisdictionId = m.JurisdictionId,
                                    ClientId = m.ClientId,
                                    BillingAttorneyId = m.BillingAttorneyId,
                                    ResponsibleAttorneyId = m.ResponsibleAttorneyId
                                }).FirstOrDefault();
            if(result == null) 
            {
                Attorney attorney = _context.Attorneys.FirstOrDefault(a => a.Id == matter.BillingAttorneyId);

                if (attorney!.JurisdictionId != matter.JurisdictionId)
                {
                    return (-1);
                }

                Matter newMatter = new Matter();
                {
                    newMatter.Title = matter.Title;
                    newMatter.IsActive = matter.IsActive;
                    newMatter.JurisdictionId = matter.JurisdictionId;
                    newMatter.ClientId = matter.ClientId;
                    newMatter.BillingAttorneyId = matter.BillingAttorneyId;
                    newMatter.ResponsibleAttorneyId = matter.ResponsibleAttorneyId;
                }
                _context.Matters.Add(newMatter);
                _context.SaveChanges();
                return newMatter    .Id;
            }
            else
                return 0;
        }
        public int UpdateMatter(int id, MatterDto updatedMatter)
        {
            MatterDto matter = (from m in _context.Matters
                                where m.Id == id
                                select new MatterDto()
                                {
                                    Id = m.Id,
                                    Title = m.Title,
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