using System.ComponentModel.DataAnnotations;
namespace Lexicon.Data.Models
{
    public class Attorney
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Rate { get; set; }
        public int JurisdictionId { get; set; }
        public Jurisdiction Jurisdiction { get; set; } = null!;

    }
}