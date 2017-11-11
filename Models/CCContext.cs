using convertizzle.Models;
using Microsoft.EntityFrameworkCore;

public class CCContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Conversion> Conversions { get; set; }

      public CCContext(DbContextOptions<CCContext> options) : base(options) { }
    }