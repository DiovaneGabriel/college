using System.Collections.Generic;

namespace College.Models
{
    public class Subject
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int CourseID { get; set; }
        public int TeacherID { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
