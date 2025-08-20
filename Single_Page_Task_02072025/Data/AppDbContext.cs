using Microsoft.EntityFrameworkCore;
using Single_Page_Task_02072025.Models;
namespace Single_Page_Task_02072025.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<CorporateCustomer> Corporate_Customer_Tbl { get; set; }
        public DbSet<IndividualCustomer> Individual_Customer_Tbl { get; set; }
        public DbSet<MeetingMinute> Meeting_Minutes_Master_Tbl { get; set; }
        public DbSet<MeetingMinuteDetail> Meeting_Minutes_Details_Tbl { get; set; }
        public DbSet<ProductService> Products_Service_Tbl { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MeetingMinuteDetail>()
                .HasOne(d => d.MeetingMinute)
                .WithMany(m => m.Details).HasForeignKey(d => d.MeetingMinuteId)
                .OnDelete(DeleteBehavior.Cascade);
        }


    }
}
