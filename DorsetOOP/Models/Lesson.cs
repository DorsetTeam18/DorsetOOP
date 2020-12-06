/// Team 18
/// Student names | ID:
/// Wim POIGNON | 23408
/// Maélis YONES | 23217
/// Rémi LOMBARD | 23210
/// Christophe NGUYEN | 23219
/// Gwendoline MAREK | 23397
/// Maxime DENNERY | 23203
/// Victor TACHOIRES | 22844

using DorsetOOP.Models.Users;
using DorsetOOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using DorsetOOP.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace DorsetOOP.Models
{
    public class Lesson
    {
        public Lesson()
        {
            this.Students = new HashSet<Student>();
        }

        #region Properties / columns
        public int LessonId { get; set; }

        [Required]
        public string RoomName { get; set; }

        [Required]
        public string Day { get; set; }

        [Required]
        public string Hour { get; set; } // Prefered format is 00:15 / 10:00 / 10:30 / 12:15 / 16:00 / 17:20

        [Required]
        public string Duration { get; set; } // Format is 01:30 / 01:00

        // One to many (each lesson corresponds to one course, each course has multiple lessons)
        public int? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        // One to many (each lesson has one teacher, each teacher has many lessons)
        public int? TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }

        // Many to many (each lesson has multiple students and each student has multiple lessons)
        public ICollection<Student> Students { get; set; }

        // Many to manyj
        public ICollection<Student> PresentStudents { get; set; }
        #endregion

        public string DateAndTime // Returns things in a nice way
        {
            get
            {
                return $"{ Day } - { Hour }";
            }
        }

        public override string ToString() // Custom ToString
        {
            return $"{Course} : {RoomName} - {DateAndTime} - {Duration} - {Teacher.FullName}";
        }
    }
}
