using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace College.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Subject> Subject { get; set; }
    }
}
