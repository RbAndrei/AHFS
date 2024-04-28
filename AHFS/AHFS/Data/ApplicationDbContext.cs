using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;
using AHFS.Models;

namespace AHFS.Data
{
    public class AplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
        : base(options)
        { }

        public DbSet<Document>? Brands { get; set; }
        public DbSet<Grade>? Categories { get; set; }
        public DbSet<Student>? Employees { get; set; }
        public DbSet<Teacher>? Items { get; set; }
        public DbSet<Subject>? Orders { get; set; }
    }
}
