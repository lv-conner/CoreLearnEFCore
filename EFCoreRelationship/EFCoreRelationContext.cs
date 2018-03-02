using Microsoft.EntityFrameworkCore;
using System;

namespace EFCoreRelationship
{
    public class EFCoreRelationContext:DbContext
    {
        public EFCoreRelationContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=PRCNMG1L0311;Initial Catalog=EFCoreRelationContext;User Id=sa;Password=Root@admin;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new BookMap());
            modelBuilder.ApplyConfiguration(new StudentInfoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
