
namespace Lexicon.Data.DTO
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int HoursWorked { get; set; }
        public float? TotalAmount { get; set; }
        public int MatterId { get; set; }
        public int AttorneyId { get; set; }
    }
}
