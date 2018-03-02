using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreRelationship
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //builder.ForSqlServerIsMemoryOptimized(true);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(50).IsUnicode();
            builder.HasOne(p => p.User).WithMany(p => p.Books).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
