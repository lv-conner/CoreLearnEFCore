using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreRelationship
{
    public class StudentInfoMap : IEntityTypeConfiguration<StudentInfo>
    {
        public void Configure(EntityTypeBuilder<StudentInfo> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.StudentNumber).HasMaxLength(50).IsUnicode();
            builder.HasOne(p => p.User).WithOne(p => p.StudentInfo).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
