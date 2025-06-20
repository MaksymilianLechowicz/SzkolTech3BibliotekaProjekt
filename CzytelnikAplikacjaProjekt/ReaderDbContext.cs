using Microsoft.EntityFrameworkCore;

namespace CzytelnikAplikacjaProjekt
{
    public class ReaderDbContext : DbContext
    {
        private IConfiguration _configuration { get; }
        public DbSet<Entities.Reader> Readers { get; set; }

        public ReaderDbContext(IConfiguration configuration)
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
