
using System.ComponentModel.DataAnnotations;

namespace Lexicon.Data.Models
{
    public class Jurisdiction
    {
        [Key]
        public int Id { get; set; }
        public string Area { get; set; }
        public ICollection<Attorney> Attorneys { get; set; }
    }
}
