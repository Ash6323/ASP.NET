
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lexicon.Data.Models
{
    public class Client
    {
        [Key][JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [Required]
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Matter> Matters { get; set; }
    }
}
