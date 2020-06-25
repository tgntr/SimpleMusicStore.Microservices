using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleMusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Data.Relations
{
    class ArtistFollowRelations : IEntityTypeConfiguration<ArtistFollow>
    {
        public void Configure(EntityTypeBuilder<ArtistFollow> builder)
        {
            builder
                .HasKey(af => new { af.ArtistId, af.UserId });

            builder
                .HasOne(af => af.Artist)
                .WithMany(a => a.Followers)
                .HasForeignKey(af => af.ArtistId);

            builder
                .HasOne(af => af.User)
                .WithMany(u => u.FollowedArtists)
                .HasForeignKey(af => af.UserId);
        }
    }
}
