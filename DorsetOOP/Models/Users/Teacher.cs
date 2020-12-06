/// Team 18
/// Student names | ID:
/// Wim POIGNON 23408
/// Maélis YONES 23217
/// Rémi LOMBARD 23210
/// Christophe NGUYEN 23219
/// Gwendoline MAREK 23397
/// Maxime DENNERY 23203
/// Victor TACHOIRES 22844

using DorsetOOP.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorsetOOP.Models.Users
{
    public class Teacher : User // Teacher class inherits from the User class. Therefore, it has all the properties the User class has
    {
        public Teacher()
        {
            this.Courses = new HashSet<Course>();
            this.Tutoring = new HashSet<Student>();
            this.Lessons = new HashSet<Lesson>();
        }

        #region Properties / columns
        // Many to one (one teacher has multiple lessons and each esson has only one teacher teaching it)
        public ICollection<Lesson> Lessons { get; set; }

        // Many to one (one teacher has multiple students that he's tutoring, each student has one tutor)
        public ICollection<Student> Tutoring { get; set; }

        // Many to many (one teacher has multiple courses and each course has multiple teachers that can teach in it)
        public ICollection<Course> Courses { get; set; }
        #endregion
    }
}
