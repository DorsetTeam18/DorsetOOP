using DorsetOOP.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorsetOOP.Models.Users
{
    /// <summary>
    /// Team 18
    /// Name of the Students :
    /// Wim POIGNON 23408
    /// Maélis YONES 23217
    /// Rémi LOMBARD 23210
    /// Christophe NGUYEN 23219
    /// Gwendoline MAREK 23397
    /// Maxime DENNERY 23203
    /// Victor TACHOIRES 22844
    /// </summary>
    public class Teacher : User
    {
        public Teacher()
        {
            this.Courses = new HashSet<Course>();
            this.Tutoring = new HashSet<Student>();
            this.Lessons = new HashSet<Lesson>();
        }

        // One to many (one teacher has multiple lessons and each Lesson has only one Teacher)
        public ICollection<Lesson> Lessons { get; set; }

        // One to many
        public ICollection<Student> Tutoring { get; set; }

        // Many to many (one teacher has multiple courses and each course has multiple teachers)
        public ICollection<Course> Courses { get; set; }
    }
}
