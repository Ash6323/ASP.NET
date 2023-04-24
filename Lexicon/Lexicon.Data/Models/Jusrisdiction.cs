
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lexicon.Data.Models
{
    public class Jurisdiction
    {
        [Key][JsonIgnore]
        public int Id { get; set; }
        public string Area { get; set; } = null!;
        public ICollection<Attorney> Attorneys { get; set; }
        public ICollection<Matter> Matters { get; set; }
    }
}
