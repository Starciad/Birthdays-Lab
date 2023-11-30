using Birthdays.Models;

using Microsoft.EntityFrameworkCore;

namespace Birthdays.Database
{
    public sealed class BirthdaysDbContext : DbContext
    {
        public BirthdaysDbContext(DbContextOptions<BirthdaysDbContext> options) : base(options)
        {

        }

        public DbSet<BirthdayRegister> Birthdays { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            _ = builder.Entity<BirthdayRegister>().HasKey(x => x.Id);
            base.OnModelCreating(builder);
        }
    }
}
