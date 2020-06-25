using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleMusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Data.Relations
{
    class LabelFollowRelations : IEntityTypeConfiguration<LabelFollow>
    {
        public void Configure(EntityTypeBuilder<LabelFollow> builder)
        {
            builder
               .HasKey(lf => new { lf.LabelId, lf.UserId });

            builder
                .HasOne(lf => lf.Label)
                .WithMany(l => l.Followers)
                .HasForeignKey(lf => lf.LabelId);

            builder
                .HasOne(lf => lf.User)
                .WithMany(u => u.FollowedLabels)
                .HasForeignKey(lf => lf.UserId);
        }
    }
}
