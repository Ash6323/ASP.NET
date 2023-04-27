using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Lexicon.Data.Models
{
    public class Invoice
    {
        [Key][JsonIgnore]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int HoursWorked { get; set; }
        public float? TotalAmount { get; set; }
        [Required]
        [ForeignKey("Matter")]
        public int MatterId { get; set; }
        public Matter Matter { get; set; }
        [Required]
        [ForeignKey("Attorney")]
        public int AttorneyId { get; set; }
        public Attorney Attorney { get; set; }
    }
}
