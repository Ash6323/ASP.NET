
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lexicon.Data.Models
{
    public class Invoice
    {
        [Key][JsonIgnore]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int HoursWorked { get; set; }
        public float? TotalAmount { get; set; }
        [Required]
        public int MatterId { get; set; }
        public Matter Matter { get; set; }
        [Required]
        public int AttorneyId { get; set; }
        public Attorney Attorney { get; set; }
    }
}
