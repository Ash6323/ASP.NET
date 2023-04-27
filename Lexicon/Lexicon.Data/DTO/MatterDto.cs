
namespace Lexicon.Data.DTO
{
    public class MatterDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int IsActive { get; set; }
        public int JurisdictionId { get; set; }
        public int ClientId { get; set; }
        public int BillingAttorneyId { get; set; }
        public int ResponsibleAttorneyId { get; set; }

    }
}
