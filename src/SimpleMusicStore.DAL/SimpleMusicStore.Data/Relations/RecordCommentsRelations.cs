using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleMusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Data.Relations
{
    class RecordCommentsRelations : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(c => c.Record)
                .WithMany(r => r.Comments)
                .HasForeignKey(c => c.RecordId);
        }
    }
}
