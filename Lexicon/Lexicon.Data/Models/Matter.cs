﻿
using System.ComponentModel.DataAnnotations;

namespace Lexicon.Data.Models
{
    public class Matter
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int IsActive { get; set; }
        [Required]
        public int JurisdictionId { get; set; }
        public Jurisdiction Jurisdiction { get; set; } = null!;
        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        [Required]
        public int BillingAttorneyId { get; set; }
        [Required]
        public int ResponsibleAttorneyId { get; set; }
        public Attorney Attorney { get; set; }
        public ICollection<Invoice> Invoices { get; set; }

    }
}
