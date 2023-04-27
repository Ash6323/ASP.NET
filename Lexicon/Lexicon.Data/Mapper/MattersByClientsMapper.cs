
using Lexicon.Data.DTO;
using Lexicon.Data.Models;
namespace Lexicon.Data.Mapper
{
    public class MattersByClientsMapper
    {
        public MattersByClientsDTO Map(Matter entity)
        {
            return new MattersByClientsDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                IsActive = entity.IsActive,
                Description = entity.Description,
                ClientId = entity.ClientId,
                ClientName = entity.Client.Name,
                JurisdictionArea = entity.Jurisdiction.Area,
                BillingAttorneyName = entity.BillingAttorney.Name,
                ResponsibleAttorneyName = entity.ResponsibleAttorney.Name
            };
        }
    }
}
