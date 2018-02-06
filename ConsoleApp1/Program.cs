using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MyContext())
            {
                var list1 = db.Blogs.Where(p => p.BlogId == 2).First();
                var post = list1.Posts.ToList();

                db.Database.EnsureCreated();
                Blog blog = new Blog()
                {
                    Posts = new System.Collections.Generic.List<Post>(),
                    Url = "http:sdfasdf"
                };
                blog.Posts.Add(new Post()
                {
                    Content = "dfasdf",
                    Title = "dfasdfa"
                });
                db.Blogs.Add(blog);
                db.SaveChanges();
                var list = db.Blogs.ToList();
            }
        }
    }
}
