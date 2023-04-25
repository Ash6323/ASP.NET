
namespace Lexicon.Data.DTO
{
    public class MatterForClientDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int IsActive { get; set; }
        public string Description { get; set; }
        public string JurisdictionArea { get; set; }
        public string ClientName { get; set; }
        public string BillingAttorneyName { get; set; }
        public string ResponsibleAttorneyName { get; set; }
    }
}
