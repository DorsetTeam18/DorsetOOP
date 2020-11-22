using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorsetOOP.Models.Users
{
    public class Student : User
    {
        public Student()
        {
            this.Lessons = new HashSet<Lesson>();
        }
        #region Properties
        public int StudentId { get; set; }
        public double Fees { get; set; }

        // Many to one (many students have one tutor and one tutor has many students)
        public int? TutorId { get; set; }
        [ForeignKey("TutorId")]
        public Teacher Tutor { get; set; }

        // One to many (each student has many grades)
        public ICollection<Grade> Grades { get; set; }

        // Many to many (multiple students have multiple lessons and many lessons have multiple students)
        public ICollection<Lesson> Lessons { get; set; }
        #endregion

        public void AddGrade(Course _course, string _examName, decimal _coefficient)
        {
            Grades.Add(new Grade()
            {
                Course = _course,
                ExamName = _examName,
                Coefficient = _coefficient,
                Student = this
            });
        }
    }
}
