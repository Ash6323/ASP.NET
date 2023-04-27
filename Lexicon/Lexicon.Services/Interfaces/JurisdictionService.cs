using Lexicon.Data.Context;
using Lexicon.Data.DTO;

namespace Lexicon.Services.Interfaces
{
    public interface IJurisdiction
    {
        List<JurisdictionDto> GetJurisdictions();
        //JurisdictionDto GetJurisdiction(int id);
        //int AddJurisdiction(JurisdictionDto jurisdiction);
        //int UpdateJurisdiction(int id, Customer updatedJurisdiction);
        //int DeleteJurisdiction(int id);
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
            List<JurisdictionDto> jurisdictions = (from j in _context.Jurisdictions
                                                select new JurisdictionDto()
                                                {
                                                    Id = j.Id,
                                                    Area = j.Area
                                                }).ToList();
            return jurisdictions;
        }
    }
}
