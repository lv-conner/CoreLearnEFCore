using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLearnEFCore
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions options):base(options)
        {
            Database.EnsureCreated();
        }
        public TestDbContext()
        {

        }

        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration()
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Man> Mans { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("data source=PRCNMG1L0311;initial catalog=CoreEFTestDB;user id=sa;password=Root@admin");
        }
    }
}
