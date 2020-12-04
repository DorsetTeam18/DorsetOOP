using DorsetOOP.Models.Users;
using DorsetOOP.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorsetOOP.Models
{
	/// <summary>
	/// Name of the Students :
	/// Wim Poignon 23408
    /// </summary>
    public class Course
    {
        public Course()
        {
            this.Teachers = new HashSet<Teacher>();
        }
        
        #region Preoperties
        public int CourseId { get; set; }
        public string Title { get; set; }
        public decimal Credits { get; set; }

        // Many to one (each course has one leader, each leader can have multiple courses)
        public int ReferentTeacherId { get; set; }
        [ForeignKey("ReferentTeacherId")]
        public Teacher ReferentTeacher { get; set; }

        // Many to many (each course can be tought by multiple teachers and each teacher can teach multiple courses)
        public ICollection<Teacher> Teachers { get; set; }

        // One to many 
        public ICollection<Lesson> Lessons { get; set; }
        #endregion

        public override string ToString()
        {
            return $"{ Title } ({ Credits } credits) - Referent is { ReferentTeacher.FullName }";
        }

        public ObservableCollection<Student> ParticipatingStudents
        {
            get
            {
                List<Student> myList = new List<Student>();
                if (Lessons != null)
                {
                    foreach (Lesson lesson in Lessons)
                    {
                        myList.AddRange(lesson.Students.ToList());
                    }
                }
                return new ObservableCollection<Student>(myList);
            }
        }

        public ObservableCollection<Grade> AllCourseGrades { get { return new ObservableCollection<Grade>(VirtualCollegeContext.GetAllGrades(this)); } }
    }
}
