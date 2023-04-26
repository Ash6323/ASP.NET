namespace Lexicon.Data.DTO
{
    public class InvoicesByMattersDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int HoursWorked { get; set; }
        public float? TotalAmount { get; set; }
        public string MatterTitle { get; set; }
        public string AttorneyName { get; set; }
    }
}
