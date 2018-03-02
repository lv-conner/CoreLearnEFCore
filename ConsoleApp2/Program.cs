using System;
using EFCoreRelationship;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EFCoreRelationContext())
            {
                //var user1 = db.Set<User>().First();
                var user1 = db.Set<User>().Include(p => p.Books).First();
                var book = db.Set<Book>().First();
                //db.Database.EnsureCreated();
                //var user = new User("tim", 24);
                //var book = new Book("Hello Charp", Guid.NewGuid().ToString(), user);
                //var book1 = new Book("Hello plus plus", Guid.NewGuid().ToString(), user);
                //user.AddBook(book);
                //user.AddBook(book1);
                //db.Set<User>().Add(user);
                //db.SaveChanges();

                //var user1 = db.Set<User>().Find(user.Id);


            }
            Console.WriteLine("Hello World!");
        }
    }
}
