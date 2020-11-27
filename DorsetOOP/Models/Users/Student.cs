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

        // Many to one (one students has one tutor and one tutor has many students)
        public int? TutorId { get; set; }
        [ForeignKey("TutorId")]
        public Teacher Tutor { get; set; }

        // One to many (each student has many grades)
        public ICollection<Grade> Grades { get; set; }

        // Many to many (each student has multiple lessons and each lessons have multiple students)
        public ICollection<Lesson> Lessons { get; set; }

        public ICollection<Payment> Payments { get; set; }

        
        #endregion

        //public string GradesInfo
        //{
        //    get
        //    {
        //        string r = $" { FullName }'s grades:\n";
        //        foreach (var g in Grades) r += $"{ g.Course.Title } : { g.ExamName } - { g.Mark }% (Coeff. { g.Coefficient })\n";
        //        return r;
        //    }
        //}

        public void AddGrade(Course _course, decimal _mark, string _examName, decimal _coefficient)
        {
            using (var AppDB = new VirtualCollegeContext())
            {
                AppDB.Grades.Add(new Grade
                {
                    Course = _course,
                    Mark = _mark,
                    ExamName = _examName,
                    Coefficient = _coefficient,
                    Student = this
                });
            }
        }

        public void AddPayment(DateTime _datetime,long _amount)
        {
            using (var AppDB = new VirtualCollegeContext()) 
            {
                AppDB.Payments.Add(new Payment
                {
                    Date=_datetime,
                    Amount=_amount,
                    Student=this
                });
            }
        }

    }
}
