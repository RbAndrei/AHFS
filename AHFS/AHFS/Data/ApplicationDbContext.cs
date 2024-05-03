using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;
using AHFS.Models;

namespace AHFS.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { }

        public DbSet<Document>? Document { get; set; }
        public DbSet<Grade>? Grade { get; set; }
        public DbSet<Student>? Student { get; set; }
        public DbSet<Teacher>? Subject { get; set; }
        public DbSet<Subject>? Teacher { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Call base method

            // Your fluent modeling here
            // For example, if you need to specify configurations for your entities:
            // modelBuilder.Entity<Document>().Property(d => d.Name).IsRequired();
            // modelBuilder.Entity<Grade>().HasMany(g => g.Students).WithOne(s => s.Grade);
            // Add any additional configurations for your entities here
        }

    }
}
