using BibliotekaAplikacjaProjekt.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace BibliotekaAplikacjaProjekt
{
    public class BookstoreDbContext : DbContext
    {


        private IConfiguration _configuration { get; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public BookstoreDbContext(IConfiguration configuration)
           : base()
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=bibliotekproj_szk3;trusted_connection=true",
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "projektbookshop"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
