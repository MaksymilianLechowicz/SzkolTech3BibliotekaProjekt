using BibliotekaAplikacjaProjekt.Entities;
using Microsoft.EntityFrameworkCore;
using PromocjeAplikacjaProjekt.Entities;

namespace PromocjeAplikacjaProjekt
{
    public class CouponDbContext : DbContext
    {


        private IConfiguration _configuration { get; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Point> Points { get; set; }
        public CouponDbContext(IConfiguration configuration)
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
