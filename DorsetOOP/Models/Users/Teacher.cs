using DorsetOOP.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorsetOOP.Models.Users
{
    public class Teacher : User
    {
        public Teacher()
        {
            this.Courses = new HashSet<Course>();
        }

        public int TeacherId { get; set; }

        // One to many (one teacher has multiple) and each Lesson et Student has only one Teacher
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<Student> Tutoring { get; set; }

        // Many to many
        public ICollection<Course> Courses { get; set; }
    }
}
