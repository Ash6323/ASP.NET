
using System.ComponentModel.DataAnnotations;

namespace Lexicon.Data.Models
{
    public class Jusrisdiction
    {
        [Key]
        public int Id { get; set; }
        public string Area { get; set; }
    }
}
