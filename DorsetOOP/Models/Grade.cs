using DorsetOOP.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorsetOOP.Models
{
	// <summary>
	/// Name of the Students :
	/// Wim Poignon 23408
    /// </summary>
    public class Grade
    {
        public int GradeId { get; set; }
        public string ExamName { get; set; }
        public decimal Mark { get; set; }
        public decimal Coefficient { get; set; }

        // One to many (each course has many grades, each grade corresonds to one course)
        public int? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        // One to many (each student has many grades, each grade has one student)
        public int? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
