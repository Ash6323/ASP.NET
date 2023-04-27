using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Lexicon.Data.Models
{
    public class Attorney
    {
        [Key][JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public int Age { get; set; }
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Phone { get; set; } = null!;
        [Required]
        public int Rate { get; set; }
        [Required]
        [ForeignKey("Jurisdiction")]
        public int JurisdictionId { get; set; }
        public Jurisdiction Jurisdiction { get; set; } = null!;
        public ICollection<Matter> BillingAttorneyMatters { get; set; }
        public ICollection<Matter> ResponsibleAttorneyMatters { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}