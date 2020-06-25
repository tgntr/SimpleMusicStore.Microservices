using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleMusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Data.Relations
{
    class WishRelations : IEntityTypeConfiguration<Wish>
    {
        public void Configure(EntityTypeBuilder<Wish> builder)
        {
            builder
               .HasKey(w => new { w.RecordId, w.UserId });

            builder
                .HasOne(w => w.Record)
                .WithMany(r => r.WishedBy)
                .HasForeignKey(w => w.RecordId);

            builder
                .HasOne(w => w.User)
                .WithMany(u => u.Wishlist)
                .HasForeignKey(w => w.UserId);
        }
    }
}
