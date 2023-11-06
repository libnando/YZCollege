using Microsoft.EntityFrameworkCore;
using YZCollege.Domain.Entities;

namespace YZCollege.Infrastructure.Context
{
    public class SqlContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public SqlContext(DbContextOptions<SqlContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Configure();
        }
    }
}