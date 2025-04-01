using BeginnerCSharpApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeginnerCSharpApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed initial data
            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem { Id = 1, Name = "Learn C#", IsComplete = false },
                new TodoItem { Id = 2, Name = "Build a web API", IsComplete = false }
            );
        }
    }
}