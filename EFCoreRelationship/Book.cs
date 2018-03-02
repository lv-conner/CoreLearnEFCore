using System;

namespace EFCoreRelationship
{
    public class Book
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public string ISBM { get; private set; }
        public User User { get; private set; }
        public Book() { }
        public Book(string name,string isbn,User user)
        {
            Id = Guid.NewGuid();
            Name = name;
            ISBM = isbn;
            User = user;
        }
    }
}