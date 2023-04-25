using Lexicon.Data.Context;
using Lexicon.Data.DTO;
using Lexicon.Data.Mapper;
using Lexicon.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Lexicon.Services.Interfaces
{
    public interface IInvoice
    {
        List<InvoiceDto> GetInvoices();
        InvoiceDto GetInvoice(int id);
        IEnumerable<IGrouping<int, InvoiceDto>> GetInvoicesByMatters();
        List<InvoiceForMatterDTO> GetInvoicesForMatter(int matterId);
        double GetBillingByAttorney(int attorneyId);
        int AddInvoice(InvoiceDto invoice);
        //int UpdateInvoice(int id, InvoiceDto updatedInvoice);
        //int DeleteInvoice(int id);
    }
    public class InvoiceService : IInvoice
    {
        private LexiconDbContext _context;
        public InvoiceService(LexiconDbContext newContext)
        {
            _context = newContext;
        }
        public List<InvoiceDto> GetInvoices()
        {
            List<InvoiceDto> invoices = (from i in _context.Invoices
                                            select new InvoiceDto()
                                            {
                                                Id = i.Id,
                                                Date = i.Date,
                                                HoursWorked = i.HoursWorked,
                                                TotalAmount = i.TotalAmount,
                                                MatterId = i.MatterId,
                                                AttorneyId = i.AttorneyId
                                            }).ToList();
            return invoices;
        }
        public InvoiceDto GetInvoice(int id)
        {
            InvoiceDto invoice = (from i in _context.Invoices
                                 where i.Id == id
                                 select new InvoiceDto()
                                 {
                                     Id = i.Id,
                                     Date = i.Date,
                                     HoursWorked = i.HoursWorked,
                                     TotalAmount = i.TotalAmount,
                                     MatterId = i.MatterId,
                                     AttorneyId = i.AttorneyId
                                 }).FirstOrDefault();
            return invoice;
        }
        public IEnumerable<IGrouping<int, InvoiceDto>> GetInvoicesByMatters()
        {
            IEnumerable<IGrouping<int, InvoiceDto>> invoices = (from i in _context.Invoices
                                       select new InvoiceDto()
                                       {
                                           Id = i.Id,
                                           Date = i.Date,
                                           HoursWorked = i.HoursWorked,
                                           TotalAmount = i.TotalAmount,
                                           MatterId = i.MatterId,
                                           AttorneyId = i.AttorneyId
                                       }).GroupBy(m => m.MatterId).ToList();

            return invoices;
        }
        public List<InvoiceForMatterDTO> GetInvoicesForMatter(int matterId)
        {
            IQueryable<Invoice> invoicesByMatter = _context.Invoices
            .Include(m => m.Matter)
            .Include(m => m.Attorney)
            .Where(c => c.MatterId.Equals(matterId));

            return invoicesByMatter.Select(c => new InvoicesForMatterMapper().Map(c)).ToList();
        }      
        public double GetBillingByAttorney(int attorneyId)
        {
            DateTime date= DateTime.Now;
            DayOfWeek sunday = DayOfWeek.Sunday;
            DateTime lastWeekStartDate = DateTime.Now;
            DateTime lastWeekEndDate = DateTime.Now;
            for (int i=7; i>=0; i--)
            {
                if(date.DayOfWeek == sunday)
                {
                    lastWeekEndDate = date;
                    break;
                }
                else
                {
                    date.AddDays(-1);
                }
            }
            lastWeekStartDate = lastWeekEndDate.AddDays(-7);

            double billing = Convert.ToDouble(_context.Invoices
                                    .Where(i => i.AttorneyId == attorneyId && 
                                            i.Date.Date >= lastWeekStartDate.Date &&
                                            i.Date.Date <= lastWeekEndDate.Date)
                                    .Sum(im => im.TotalAmount));
            return billing;
        }
        public int AddInvoice(InvoiceDto invoice)
        {
            int attorneyRate = _context.Attorneys.Where(a => a.Id == invoice.AttorneyId).Select(a => a.Rate).First();

            Invoice newInvoice = new Invoice();
            {
                newInvoice.Date = invoice.Date;
                newInvoice.HoursWorked = invoice.HoursWorked;
                newInvoice.TotalAmount = invoice.HoursWorked * attorneyRate;
                newInvoice.MatterId = invoice.MatterId;
                newInvoice.AttorneyId = invoice.AttorneyId;
            }
            _context.Invoices.Add(newInvoice);
            _context.SaveChanges();
            return newInvoice.Id;
        }
        public int UpdateMatter(int id, MatterDto updatedMatter)
        {
            MatterDto matter = (from m in _context.Matters
                                where m.Id == id
                                select new MatterDto()
                                {
                                    Id = m.Id,
                                    Title = m.Title,
                                    IsActive = m.IsActive,
                                    JurisdictionId = m.JurisdictionId,
                                    ClientId = m.ClientId,
                                    BillingAttorneyId = m.BillingAttorneyId,
                                    ResponsibleAttorneyId = m.ResponsibleAttorneyId
                                }).FirstOrDefault();
            if (matter != null)
            {
                matter.Title = updatedMatter.Title;
                matter.IsActive = updatedMatter.IsActive;
                matter.JurisdictionId = updatedMatter.JurisdictionId;
                matter.ClientId = updatedMatter.ClientId;
                matter.BillingAttorneyId = updatedMatter.BillingAttorneyId;
                matter.ResponsibleAttorneyId = updatedMatter.ResponsibleAttorneyId;
                _context.SaveChanges();
                return matter.Id;
            }
            else
                return 0;
        }
        public int DeleteMatter(int id)
        {
            Matter matter = _context.Matters.FirstOrDefault(m => m.Id == id);
            if (matter != null)
            {
                _context.Matters.Remove(matter);
                _context.SaveChanges();
                return matter.Id;
            }
            else
                return 0;
        }
    }
}
//public List<MatterDto> GetMattersByClientId(int clientId)
//{
//var matters = _dbContext.Matters.Where(m => m.ClientId == clientId).ToList();
//return matters.Select(m => new MatterDto(m)).ToList();
//}