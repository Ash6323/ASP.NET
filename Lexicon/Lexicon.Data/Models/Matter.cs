using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Lexicon.Data.Models
{
    public class Matter
    {
        [Key][JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public int IsActive { get; set; }
        [Required]
        [ForeignKey("Jurisdiction")]
        public int JurisdictionId { get; set; }
        public Jurisdiction Jurisdiction { get; set; } = null!;
        [Required]
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        [Required]
        [ForeignKey("Attorney")]
        public int BillingAttorneyId { get; set; }
        public Attorney BillingAttorney { get; set; }
        [Required]
        [ForeignKey("Attorney")]
        public int ResponsibleAttorneyId { get; set; }
        public Attorney ResponsibleAttorney { get; set; }
        public ICollection<Invoice> Invoices { get; set; }

    }
}
