using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreRelationship
{
    public class StudentInfo
    {
        public Guid Id { get; private set; }
        public User User { get;private set; }
        public string UserId { get; private set; }
        public string StudentNumber { get; private set; }
        public StudentInfo()
        {
            Id = Guid.NewGuid();
        }
        public StudentInfo(User user,string userId,string studentNumber)
            :this()
        {
            User = user;
            UserId = UserId;
            StudentNumber = studentNumber;
        }
    }
}
