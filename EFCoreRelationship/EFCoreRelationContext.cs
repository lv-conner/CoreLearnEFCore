using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Linq;

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
            var registType = Assembly.GetExecutingAssembly().GetTypes().Where(p => p.GetInterface(typeof(IEntityTypeConfiguration<>).FullName) != null && p.Name.EndsWith("Map"));
            foreach (var item in registType)
            {
                dynamic configInstance = Activator.CreateInstance(item);
                modelBuilder.ApplyConfiguration(configInstance);

            }
            //modelBuilder.ApplyConfiguration(new UserMap());
            //modelBuilder.ApplyConfiguration(new BookMap());
            //modelBuilder.ApplyConfiguration(new StudentInfoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
