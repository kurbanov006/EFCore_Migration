using Microsoft.EntityFrameworkCore;
using Model;

namespace PracticeEFCore.DataContext;

public class ConsoleAppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Server=localhost; Port=5432; Database=test_db; User Id=postgres; Password=12345");
    }
}