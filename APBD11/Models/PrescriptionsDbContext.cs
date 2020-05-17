
using Microsoft.EntityFrameworkCore;

namespace APBD11.Models
{
    public class PrescriptionsDbContext : DbContext
    {

        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        
        
        
        public PrescriptionsDbContext() {}

        public PrescriptionsDbContext(DbContextOptions options)
            :base(options){ }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            

            //FluentAPI
            /*
            modelBuilder.Entity<Studies>()
                        .HasKey(e => e.IdStudies); //[Key]

            modelBuilder.Entity<Studies>()
                        .Property(e => e.Name)
                        .HasMaxLength(100) //[MaxLength(100)]
                        .IsRequired(); // [Required]

            var dictStudies = new List<Studies>();
            dictStudies.Add(new Studies { IdStudies = 1, Name = "IT", Description = "AAA" });
            dictStudies.Add(new Studies { IdStudies = 2, Name = "Graphic design", Description = "BBB" });

            modelBuilder.Entity<Studies>()
                        .HasData(dictStudies);
            */

        }
        
    }
}