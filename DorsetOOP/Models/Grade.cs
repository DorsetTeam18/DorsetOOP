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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorsetOOP.Models
{
    public class Grade
    {
        #region Properties / columns
        public int GradeId { get; set; }

        [Required]
        public string ExamName { get; set; }

        [Required]
        public decimal Mark { get; set; }

        [Required]
        public decimal Coefficient { get; set; }

        // One to many (each grade corresponds to one course, each course has multiple grades)
        public int? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        // One to many (each grade corresponds to one student, each student has many grades)
        public int? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        #endregion
    }
}
