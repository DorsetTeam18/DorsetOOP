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
using DorsetOOP.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorsetOOP.Models
{
    public class Course
    {
        public Course()
        {
            this.Teachers = new HashSet<Teacher>();
        }
        
        #region Properties / columns
        public int CourseId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public decimal Credits { get; set; }

        // One to many (each course has one referent teacher, each teacher can be the referent of multiple courses)
        public int ReferentTeacherId { get; set; }
        [ForeignKey("ReferentTeacherId")]
        public Teacher ReferentTeacher { get; set; }

        // Many to one (each course has multiple lessons, each lesson has multiple courses)
        public ICollection<Lesson> Lessons { get; set; }

        // Many to many (each course can be tought by multiple teachers and each teacher can teach multiple courses)
        public ICollection<Teacher> Teachers { get; set; }
        #endregion

        public override string ToString() // Customized ToString (used for comparaison later)
        {
            return $"{ Title } ({ Credits } credits) - Referent is { ReferentTeacher.FullName }";
        }

        public ObservableCollection<Student> ParticipatingStudents // Returns a, ObservableCollection<Student> for the participating students of an instance
        {
            get
            {
                List<Student> myList = new List<Student>(); // Creates an exmpty list
                if (Lessons != null) // If there are lessons that exist in this course
                {
                    foreach (Lesson lesson in Lessons) myList.AddRange(lesson.Students.ToList()); // For each lesson, add the students in it to the list
                }
                return new ObservableCollection<Student>(myList); // Return the List as and ObservableCollection (type used for displaying data in datagrids)
            }
        }

        public ObservableCollection<Grade> AllCourseGrades { get { return new ObservableCollection<Grade>(VirtualCollegeContext.GetAllGrades(this)); } } // Returns all grades in a course
    }
}
