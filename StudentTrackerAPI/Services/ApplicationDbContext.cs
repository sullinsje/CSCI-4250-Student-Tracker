using Microsoft.EntityFrameworkCore;
using StudentTrackerAPI.Models.Entities;

namespace StudentTrackerAPI.Services;

public class ApplicationDbContext : DbContext
{
    // public ApplicationDbContext(DbContextOptions options) : base(options)
    // {
    // }
    // public DbSet<Student> Students => Set<Student>();

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Student>().HasData(
    //     new Student
    //     {
            
    //     }
    //     );
    // }
}