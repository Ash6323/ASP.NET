
namespace Lexicon.Data.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int HoursWorked { get; set; }
        public float? TotalAmount { get; set; }
    }
}
