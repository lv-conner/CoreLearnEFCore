using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreRelationship
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.ForSqlServerIsMemoryOptimized(true);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(50).IsUnicode();
            builder.HasMany(p => p.Books).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.StudentInfo).WithOne(p => p.User).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
