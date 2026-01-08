using lab3_12.api.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<PatientRoom> PatientRooms { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PatientRoom>()
            .HasOne(sr => sr.Patient)
            .WithMany(s => s.PatientRoom)
            .HasForeignKey(sr => sr.PatientId);

        modelBuilder.Entity<PatientRoom>()
            .HasOne(sr => sr.Room)
            .WithMany(r => r.PatientRooms)
            .HasForeignKey(sr => sr.RoomId);
        
        modelBuilder.Entity<Review>()
            .HasOne(r => r.Room)
            .WithMany(ro => ro.Reviews)
            .HasForeignKey(r => r.RoomId);
    }
}