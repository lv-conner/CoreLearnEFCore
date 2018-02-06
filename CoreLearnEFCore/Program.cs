using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Reflection;

namespace CoreLearnEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            IFileProvider fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().AddJsonFile(fileProvider,"appsettings.json",false,true);
            var configuration = configurationBuilder.Build();
                
            var dbConnectString = configuration.GetConnectionString("DefaultConnection");
            IServiceCollection serviceCollection = new ServiceCollection().AddSingleton<IConfiguration>(configurationBuilder.Build()).AddOptions().AddDbContext<TestDbContext>(option =>
            {
                option.UseSqlServer("data source=PRCNMG1L0311;initial catalog=CoreEFTestDB;user id=sa;password=Root@admin");
            });
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            using (var db = serviceProvider.GetService<TestDbContext>())
            {
                var list = db.Persons.ToList();
            }




            using (var db = serviceProvider.GetService<TestDbContext>())
            {
                db.Database.EnsureCreated();
                for (int i = 0; i < 10; i++)
                {
                    var p = new Person()
                    {
                        Id = i.ToString(),
                        Name = "tim" + i.ToString(),
                    };
                    p.BookList.Add(new Book()
                    {
                        BookId = i.ToString("00000"),
                        BookName = "Tim book" + i.ToString("0000")
                    });

                    db.Persons.Add(p);

                }
                db.SaveChanges();
            }

            //using (var db = serviceProvider.GetService<TestDbContext>())
            //{
            //    foreach (var item in db.Persons.ToList())
            //    {
            //        foreach (var book in item.BookList)
            //        {
            //            Console.WriteLine("{0}/{1}/{2}/{3}", item.Id, item.Name, book.BookId, book.BookName);
            //        }
            //    }
            //}
            //IConfigurationRoot root = configurationBuilder.Build();
            //Console.WriteLine(root.GetConnectionString("DefaultConnection"));




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
