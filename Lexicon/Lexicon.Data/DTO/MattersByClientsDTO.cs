
namespace Lexicon.Data.DTO
{
    public class MattersByClientsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int IsActive { get; set; }
        public string JurisdictionArea { get; set; } = null!;
        public int ClientId { get; set; }
        public string ClientName { get; set; } = null!;
        public string BillingAttorneyName { get; set; }
        public string ResponsibleAttorneyName { get; set; }
    }
}
