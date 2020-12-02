using DorsetOOP.ViewModels;
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
            this.Payments = new HashSet<Payment>();
        }

        #region Properties
        
        public decimal Fees { get; set; }
        public decimal Paid { get; set; }

        // Many to one (one students has one tutor and one tutor has many students)
        public int? TutorId { get; set; }
        [ForeignKey("TutorId")]
        public Teacher Tutor { get; set; }

        // One to many (each student has many grades)
        public ICollection<Grade> Grades { get; set; }

        // Many to many (each student has multiple lessons and each lessons have multiple students)
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<Lesson> PresentLessons { get; set; }

        public ICollection<Payment> Payments { get; set; }

        #endregion
    }
}
