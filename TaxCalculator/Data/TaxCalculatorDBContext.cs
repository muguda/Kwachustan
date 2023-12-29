using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace TaxCalculator.Data
{
    public class TaxCalculatorDBContext : DbContext
    {
        public TaxCalculatorDBContext(DbContextOptions<TaxCalculatorDBContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Models.Entity.TaxCalculationResult> TaxCalculationResults { get; set; }
        public DbSet<Models.Entity.TaxTable> TaxTables { get; set; }
        public DbSet<Models.Entity.TaxType> TaxTypes { get; set; }

        public DbSet<Models.Entity.TaxPostalCode> TaxPostalCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Models.Entity.TaxCalculationResult>().ToTable("TaxCalculationResult");
            modelBuilder.Entity<Models.Entity.TaxTable>().ToTable("TaxTable");
            modelBuilder.Entity<Models.Entity.TaxType>().ToTable("TaxType");
            modelBuilder.Entity<Models.Entity.TaxPostalCode>().ToTable("TaxPostalCode");
        }
    }
}
