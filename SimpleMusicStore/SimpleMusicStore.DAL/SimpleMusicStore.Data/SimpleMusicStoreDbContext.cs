using Microsoft.EntityFrameworkCore;
using SimpleMusicStore.Data.Relations;
using SimpleMusicStore.Entities;

namespace SimpleMusicStore.Data
{
    public class SimpleMusicStoreDbContext : DbContext
    {
        public SimpleMusicStoreDbContext(DbContextOptions<SimpleMusicStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<ArtistFollow> ArtistFollows { get; set; }
        public DbSet<LabelFollow> LabelFollows { get; set; }
        public DbSet<Wish> Wishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            builder.ApplyConfiguration(new ArtistFollowRelations());
            builder.ApplyConfiguration(new LabelFollowRelations());
            builder.ApplyConfiguration(new WishRelations());
            builder.ApplyConfiguration(new ItemRelations());
            builder.ApplyConfiguration(new OrderRelations());
            builder.ApplyConfiguration(new RecordCommentsRelations());
        }
    }
}
