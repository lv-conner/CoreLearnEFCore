using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EFCoreRelationship
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int? Age { get; private set; }
        public User()
        {
            Books = new HashSet<Book>();
        }
        public User(string name,int? age)
            :this()
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
        }
        public ICollection<Book> Books { get; private set; }
        public void AddBook(Book book)
        {
            Books.Add(book);
        }
        public void RemoveBook(Guid key)
        {
            var book = Books.Where(p=>p.Id == key).FirstOrDefault();
            Books.Remove(book);
        }
        
    }
}
