using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.Concrete
{
    public class Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=YAZILIM001;Database=PenaltyCalculatorDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryWeekendDay> CountryWeekendDays { get; set; }
        public DbSet<NationalReligiousDay> NationalReligiousDays { get; set; }
        public DbSet<WeekDay> WeekDays { get; set; }
    }
}
