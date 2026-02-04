using CSE325App.Models;
using Microsoft.EntityFrameworkCore;

namespace CSE325App.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

       public DbSet<TodoTask> Tasks { get; set; }
    
    }




