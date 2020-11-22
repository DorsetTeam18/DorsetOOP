﻿using DorsetOOP.Models.Users;
using DorsetOOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DorsetOOP.Models
{
    public class Lesson : Course
    {
        public Lesson()
        {
            this.Students = new HashSet<Student>();
        }

        public int LessonId { get; set; }
        public string RoomName { get; set; }
        public string Day { get; set; }
        public string Hour { get; set; } // Format is 00:15 / 10:00 / 10:30 / 12:15 / 16:00 / 17:20
        public string Duration { get; set; } // Format is 01:30 / 01:00

        // Many to one (each teacher has many lessons, each lesson has one teacher)
        public int? TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }

        // Many to many (each lesson has multiple students and each student has multiple lessons)
        public ICollection<Student> Students { get; set; }

        public void EnrollStudent(Student studentToEnroll)
        {
            Students.Add(studentToEnroll);
        }
    }
}
