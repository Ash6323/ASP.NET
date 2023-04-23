
using Microsoft.EntityFrameworkCore;

namespace Lexicon.Data.Context
{
    public class LexiconDbContext : DbContext
    {
        public LexiconDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlServer("Server=SUNDAR-PICHAI\\MSSQLSERVER06;Database=LexiconDB;Trusted_Connection=True;Encrypt=False;");
        }
    }
}
