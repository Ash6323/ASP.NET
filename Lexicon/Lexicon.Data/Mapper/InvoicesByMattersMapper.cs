using Lexicon.Data.DTO;
using Lexicon.Data.Models;

namespace Lexicon.Data.Mapper
{
    public class InvoicesByMattersMapper
    {
        public InvoicesByMattersDTO Map(Invoice entity)
        {
            return new InvoicesByMattersDTO
            {
                Id = entity.Id,
                Date = entity.Date,
                HoursWorked = entity.HoursWorked,
                TotalAmount = entity.TotalAmount,
                MatterId = entity.MatterId,
                MatterTitle = entity.Matter.Title,
                AttorneyName = entity.Attorney.Name
            };
        }
    }
}
