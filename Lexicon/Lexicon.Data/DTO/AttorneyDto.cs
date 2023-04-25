
using System.Text.Json.Serialization;

namespace Lexicon.Data.DTO
{
    public class AttorneyDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int Rate { get; set; }
        public int JurisdictionId { get; set; }
    }
}
