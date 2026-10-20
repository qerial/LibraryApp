using Microsoft.EntityFrameworkCore;
using Library.Core.Domain;


namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }
        public DbSet<BookDomain> Books { get; set; }
        public DbSet<LoanDomain> Loans { get; set; }
        public DbSet<ReaderDomain> Readers { get; set; }

    }
}
