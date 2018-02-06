using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLearnEFCore
{
    public class Book
    {
        public string BookId { get; set; }
        public string BookName { get; set; }
        public string PersonId { get; set; }
        public Person person { get; set; }
    }
}
