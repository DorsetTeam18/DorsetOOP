/// Team 18
/// Student names | ID:
/// Wim POIGNON 23408
/// Maélis YONES 23217
/// Rémi LOMBARD 23210
/// Christophe NGUYEN 23219
/// Gwendoline MAREK 23397
/// Maxime DENNERY 23203
/// Victor TACHOIRES 22844

using DorsetOOP.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorsetOOP.Models.Users
{
    public class Student : User // Student class inherits from the User class. Therefore, it has all the properties Users have
    {
        public Student()
        {
            this.Lessons = new HashSet<Lesson>();
            this.Grades = new HashSet<Grade>();
            this.Payments = new HashSet<Payment>();
        }

        #region Properties / columns
        [Required]
        public decimal Fees { get; set; }
        public decimal Paid { get; set; }

        // One to many (one student has one tutor and one tutor has many students)
        public int? TutorId { get; set; }
        [ForeignKey("TutorId")]
        public Teacher Tutor { get; set; }

        // Many to one (each student has many grades, each grade corresponds to one student)
        public ICollection<Grade> Grades { get; set; }

        // Many to many (each student has multiple lessons and each lessons have multiple students)
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<Lesson> PresentLessons { get; set; }

        // Many to one (each student has multiple payments, each payment corresponds to one student)
        public ICollection<Payment> Payments { get; set; }
        #endregion
    }
}
