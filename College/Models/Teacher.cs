using System;
using System.Collections.Generic;

namespace College.Models
{
    public class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public double Salary { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Subject> Subject { get; set; }
    }
}
