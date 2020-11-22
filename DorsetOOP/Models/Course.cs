using DorsetOOP.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorsetOOP.Models
{
    public class Course
    {
        public Course()
        {
            this.Teachers = new HashSet<Teacher>();
        }

        public int CourseId { get; set; }
        public string Title { get; set; }
        public decimal Credits { get; set; }

        // One to many (each course has one leader, each leader can have multiple courses)
        public int ReferentTeacherId { get; set; }
        [ForeignKey("ReferentTeacherId")]
        public Teacher ReferentTeacher { get; set; }

        // Many to many (each course can be tought by multiple teachers and each teacher can teach multiple courses)
        public ICollection<Teacher> Teachers { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}
