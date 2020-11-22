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
            this.Grades = new HashSet<Grade>();
        }

        #region Properties
        public int StudentId { get; set; }
        public double Fees { get; set; }

        // Many to one (one students has one tutor and one tutor has many students)
        public int? TutorId { get; set; }
        [ForeignKey("TutorId")]
        public Teacher Tutor { get; set; }

        // One to many (each student has many grades)
        public ICollection<Grade> Grades { get; set; }

        // Many to many (each student has multiple lessons and each lessons have multiple students)
        public ICollection<Lesson> Lessons { get; set; }
        #endregion

        public void AddGrade(Course _course, decimal _mark, string _examName, decimal _coefficient)
        {
            Grades.Add(new Grade()
            {
                Course = _course,
                Mark = _mark,
                ExamName = _examName,
                Coefficient = _coefficient
            });
        }

        public string GradesInfo
        {
            get
            {
                string r = $" { FullName }'s grades:\n";
                foreach (var g in Grades) r += $"{ g.Course.Title } : { g.ExamName } - { g.Mark }% (Coeff. { g.Coefficient })\n";
                return r;
            }
        }
    }
}
