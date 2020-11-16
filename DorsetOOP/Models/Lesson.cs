using DorsetOOP.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorsetOOP.Models
{
    public class Lesson
    {
        public Course TaughtCourse { get; set; }
        public Faculty Professor { get; set; }
        public List<Student> ListofStudents { get; set; }
        public int RoomNumber { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Duration { get; set; }

        void AddStudent(Student studenttoEnroll)
        {
            ListofStudents.Add(studenttoEnroll);
        }
    }
}
