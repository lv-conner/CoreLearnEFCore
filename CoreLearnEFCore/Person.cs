using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLearnEFCore
{
    public class Person
    {
        public　Person()
        {
            BookList = new List<Book>();
        }
        public string Name { get; set; }
        public string Id { get; set; }
        public virtual IList<Book> BookList { get; set; }
    }
}
