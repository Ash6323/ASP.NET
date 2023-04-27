using Lexicon.Data.DTO;
using Lexicon.Data.Models;

namespace Lexicon.Data.Mapper
{
    public class MattersForClientMapper
    {
        public MatterForClientDTO Map(Matter entity)
        {
            return new MatterForClientDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                IsActive = entity.IsActive,
                Description = entity.Description,
                ClientName = entity.Client.Name,
                JurisdictionArea = entity.Jurisdiction.Area,
                BillingAttorneyName = entity.BillingAttorney.Name,
                ResponsibleAttorneyName = entity.ResponsibleAttorney.Name
            };
        }
    }
}
