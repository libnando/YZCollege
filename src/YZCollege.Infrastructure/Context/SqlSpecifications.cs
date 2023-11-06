using Microsoft.EntityFrameworkCore;
using YZCollege.Domain.Entities;

namespace YZCollege.Infrastructure.Context
{
    public static class SqlSpecifications
    {
        public static void Configure(this ModelBuilder builder)
        {
            builder.Entity<Teacher>().Property(p => p.Name).HasMaxLength(50);

            builder.Entity<Course>().Property(p => p.Name).HasMaxLength(50);
            builder.Entity<Course>().Property(p => p.Description).HasMaxLength(2000);
        }
    }
}
