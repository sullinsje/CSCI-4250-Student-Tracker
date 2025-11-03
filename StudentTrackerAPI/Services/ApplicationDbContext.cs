using Microsoft.EntityFrameworkCore;
using StudentTrackerAPI.Models.Entities;

namespace StudentTrackerAPI.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Student> Students => Set<Student>();
}