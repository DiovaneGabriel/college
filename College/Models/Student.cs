using System;
using System.Collections.Generic;

namespace College.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
