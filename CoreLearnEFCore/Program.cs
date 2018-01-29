using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoreLearnEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            
            IServiceCollection serviceCollection = new ServiceCollection().AddSingleton<IConfiguration>(configurationBuilder.Build()).AddOptions().AddDbContext<TestDbContext>(option =>
            {
                option.UseSqlServer("data source=PRCNMG1L0311;initial catalog=CoreEFTestDB;user id=sa;password=Root@admin");
            });
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            using (var db = serviceProvider.GetService<TestDbContext>())
            {
                db.Database.EnsureCreated();
                var list = db.Persons.ToList();
                foreach (var item in list)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Name);
                }
            }
            IConfigurationRoot root = configurationBuilder.Build();
            Console.WriteLine(root.GetConnectionString("DefaultConnection"));




            //using (var db = new TestDbContext())
            //{
            //    db.Database.BeginTransaction();
            //    db.Persons.RemoveRange(db.Persons);
            //    var list = db.Persons.Where(p => p.Id == "001");
            //    Console.WriteLine(list.ToString());
            //    db.Database.RollbackTransaction();
            //}
            Console.WriteLine("Hello World!");
        }
    }
}
