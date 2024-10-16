using DataAccessLayer.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data.Context
{
    public class GoDoctorContext : IdentityDbContext<ApplicationUser>
    {
        public GoDoctorContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Configure your database connection string here
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=GoDoctor;Integrated Security=True;TrustServerCertificate=True");

                
            }
        }
        public GoDoctorContext(DbContextOptions<GoDoctorContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>()
            .HasIndex(u => u.Email)
            .IsUnique();
            // Configure Doctor and Comment relationship
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Doctor) // Each comment has one doctor
                .WithMany(d => d.Comments) // A doctor can have many comments
                .HasForeignKey(c => c.DoctorId) // Foreign key in Comment
                .OnDelete(DeleteBehavior.Restrict); // Change to Restrict or NoAction to prevent cycles


            modelBuilder.Entity<Booking>()
                .HasOne(b => b.TimeSlot)
                .WithMany()
                .HasForeignKey(b => b.TimeSlotId)
                .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction

            // Configure other foreign keys similarly to avoid multiple cascading paths
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.Email)
                .IsRequired();
            modelBuilder.Entity<Docktor>()
                .Property(u => u.IsValid)
                .HasDefaultValue(false);
            modelBuilder.Entity<Docktor>()
              .Property(u => u.Price)
              .HasDefaultValue(0.00);
            modelBuilder.Entity<Specialty>().HasData(
    new Specialty
    {
        Id = 1,
        Name = "Cardiology",
        Description = "Heart and cardiovascular system specialists.",
        CreatedDate = DateTime.Now,
        UpdatedDate = null,
        IsDeleted = false
    },
    new Specialty
    {
        Id = 2,
        Name = "Neurology",
        Description = "Specializes in the treatment of nervous system disorders.",
        CreatedDate = DateTime.Now,
        UpdatedDate = null,
        IsDeleted = false
    },
    new Specialty
    {
        Id = 3,
        Name = "Dermatology",
        Description = "Treats skin conditions and diseases.",
        CreatedDate = DateTime.Now,
        UpdatedDate = null,
        IsDeleted = false
    },
    new Specialty
    {
        Id = 4,
        Name = "Pediatrics",
        Description = "Focused on children's health and well-being.",
        CreatedDate = DateTime.Now,
        UpdatedDate = null,
        IsDeleted = false
    },
    new Specialty
    {
        Id = 5,
        Name = "Orthopedics",
        Description = "Treats conditions related to bones, joints, and muscles.",
        CreatedDate = DateTime.Now,
        UpdatedDate = null,
        IsDeleted = false
    },
    new Specialty
    {
        Id = 6,
        Name = "Ophthalmology",
        Description = "Specializes in the diagnosis and treatment of eye disorders.",
        CreatedDate = DateTime.Now,
        UpdatedDate = null,
        IsDeleted = false
    },
    new Specialty
    {
        Id = 7,
        Name = "Gynecology",
        Description = "Focuses on the health of the female reproductive systems.",
        CreatedDate = DateTime.Now,
        UpdatedDate = null,
        IsDeleted = false
    },
    new Specialty
    {
        Id = 8,
        Name = "Oncology",
        Description = "Specializes in diagnosing and treating cancer.",
        CreatedDate = DateTime.Now,
        UpdatedDate = null,
        IsDeleted = false
    }

);


        }
        public DbSet<Docktor> Docktor { get; set; }
        public DbSet<Specialty> Specialty { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public  DbSet<Booking> Bookings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }

    }
}
