using Microsoft.EntityFrameworkCore;
using SimpleMusicStore.Entities;

namespace SimpleMusicStore.User.Data
{ 
    public class SimpleMusicStoreUserDataContext : DbContext
    {
        public SimpleMusicStoreUserDataContext(DbContextOptions<SimpleMusicStoreUserDataContext> options)
            : base(options)
        {
        }

        public DbSet<SimpleUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<SimpleUser>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
