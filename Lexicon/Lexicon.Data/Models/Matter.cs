
using System.ComponentModel.DataAnnotations;

namespace Lexicon.Data.Models
{
    public class Matter
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int IsActive { get; set; }
    }
}
