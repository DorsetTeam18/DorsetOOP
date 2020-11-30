﻿using DorsetOOP.Models;
using DorsetOOP.Models.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorsetOOP.ViewModels
{
    public class VirtualCollegeContext : DbContext
    {
        public VirtualCollegeContext() : base("name=VirtualCollege") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Lesson>().
                HasMany(c => c.Students).
                WithMany(p => p.Lessons).
                Map(
                m =>
                    {
                        m.MapLeftKey("LessonId");
                        m.MapRightKey("UserId");
                        m.ToTable("StudentLessons");
                    });

            modelBuilder.Entity<Course>().
                Ignore(x => x.ParticipatingStudents).
                Ignore(x=> x.AllCourseGrades).
                HasMany(c => c.Teachers).
                WithMany(p => p.Courses).
                Map(
                m =>
                    {
                        m.MapLeftKey("CourseId");
                        m.MapRightKey("UserId");
                        m.ToTable("TeacherCourses");
                    });
        }

        #region Tables
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        #endregion

        #region Static Methods

        #region Get All Elements
        public static List<Student> GetAllStudents()
        {
            var t = new List<Student>();
            using (var myDB = new VirtualCollegeContext())
            {
                var addresses = myDB.Addresses.ToList();

                var courses = myDB.Courses.Include("Teachers").
                    ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    ToList();
                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                var teachers = myDB.Users.
                    Include("Courses").OfType<Teacher>().
                    ToList();

                t = myDB.Users.
                    Include("Lessons").
                    OfType<Student>().
                    ToList();
            }
            return t;
        }

        public static List<Teacher> GetAllTeachers()
        {
            var t = new List<Teacher>();
            using (var myDB = new VirtualCollegeContext())
            {
                var addresses = myDB.Addresses.ToList();

                var courses = myDB.Courses.Include("Teachers").
                    ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    ToList();
                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                var students = myDB.Users.
                    Include("Lessons").
                    OfType<Student>().
                    ToList();

                t = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();
            }
            return t;
        }

        public static List<Course> GetAllCourses()
        {
            var t = new List<Course>();
            using (var myDB = new VirtualCollegeContext())
            {
                var students = myDB.Users.
                    Include("Lessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var addresses = myDB.Addresses.ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                t = myDB.Courses.
                    Include("Teachers").
                    ToList();
            }
            return t;
        }

        public static List<Course> GetAllCourses(Student _studentToGetCoursesOf)
        {
            var t = new List<Course>();
            using (var myDB = new VirtualCollegeContext())
            {
                var students = myDB.Users.
                    Include("Lessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var addresses = myDB.Addresses.ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                var courses = myDB.Courses.
                    Include("Teachers").
                    ToList();

                foreach (Lesson lesson in students.Find(s=>s.UserId == _studentToGetCoursesOf.UserId).Lessons)
                {
                    if(t.FindAll(c=>c.Title == lesson.Course.Title).Count == 0) t.Add(lesson.Course);
                }
            }
            return t;
        }

        public static List<Grade> GetAllGrades(Course _courseToGetGradesOf)
        {
            var grades = new List<Grade>();
            using (var myDB = new VirtualCollegeContext())
            {
                var students = myDB.Users.
                    Include("Lessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var addresses = myDB.Addresses.ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    ToList();

                var payments = myDB.Payments.ToList();

                grades = myDB.Grades.ToList().FindAll(g=>g.Course.CourseId == _courseToGetGradesOf.CourseId);
            }
            return grades;
        }
        #endregion

        #region Get all that match text
        public static List<Student> GetAllStudentsThatMatchFullName(string _fullName) // Returns a list of all the students in the DB whose full names math the input
        {
            var tempStuds = new List<Student>();
            using (var myDB = new VirtualCollegeContext())
            {
                var addresses = myDB.Addresses.ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var courses = myDB.Courses.
                    Include("Teachers")
                    .ToList();

                var lessons = myDB.Lessons.
                    Include("Students")
                    .ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                tempStuds = myDB.Users.
                    Include("Lessons").
                    OfType<Student>().
                    ToList().
                    FindAll(s => s.FullName.ToLower().Contains(_fullName.ToLower()));
            }

            return tempStuds;
        }

        public static List<Teacher> GetAllTeachersThatMatchFullName(string _fullName)
        {
            var tempTeach = new List<Teacher>();
            using (var myDB = new VirtualCollegeContext())
            {
                var addresses = myDB.Addresses.ToList();

                var students = myDB.Users.
                    Include("Lessons").
                    OfType<Student>().
                    ToList();

                var courses = myDB.Courses.
                    Include("Teachers")
                    .ToList();

                var lessons = myDB.Lessons.
                    Include("Students")
                    .ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                tempTeach = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList().
                    FindAll(s => s.FullName.ToLower().Contains(_fullName.ToLower()));
            }
            return tempTeach;
        }

        public static List<Course> GetAllCoursesThatMatchTitle(string _courseTitle)
        {
            var courses = new List<Course>();
            using (var myDB = new VirtualCollegeContext())
            {
                var addresses = myDB.Addresses.ToList();

                var students = myDB.Users.
                    Include("Lessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                courses = myDB.Courses.
                    Include("Teachers").
                    ToList().FindAll(c => c.Title.ToLower().Contains(_courseTitle.ToLower()));
            }
            return courses;
        }
        #endregion

        #region Add entitites
        public static bool CreateUser(User _userToAdd, Address _addressToAdd) // Creates new User if doesn't already exist (checks email)
        {
            bool done = false;
            using (var myDB = new VirtualCollegeContext())
            {
                var users = myDB.Users.
                    ToList();

                var addresses = myDB.Addresses.ToList();

                var courses = myDB.Courses.
                    Include("Teachers").
                    ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                Address match = addresses.Find(a => a.ToString() == _addressToAdd.ToString());

                if (users.FindAll(s => s.EmailAddress == _userToAdd.EmailAddress).Count() == 0)
                {
                    if (match == null) _userToAdd.Address = _addressToAdd;
                    else _userToAdd.Address = match;
                    myDB.Users.Add(_userToAdd);
                    done = true;
                }
                myDB.SaveChanges();
            }
            return done;
        }

        public static bool CreateCourse(Course _courseToAdd)
        {
            bool done = false;
            using (var myDB = new VirtualCollegeContext())
            {
                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var courses = myDB.Courses.
                    Include("Teachers")
                    .ToList();

                var addresses = myDB.Addresses.ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                if (courses.FindAll(c => c.ToString() == _courseToAdd.ToString()).Count == 0)
                {
                    Course co = new Course
                    {
                        Title = _courseToAdd.Title,
                        Credits = _courseToAdd.Credits,
                        ReferentTeacher = teachers.Find(x => x.FullName == _courseToAdd.ReferentTeacher.FullName)
                    };

                    foreach (Teacher t in _courseToAdd.Teachers)
                    {
                        co.Teachers.Add(teachers.Find(x => x.FullName == t.FullName));
                    }

                    myDB.Courses.Add(co);
                    done = true;
                }
                myDB.SaveChanges();
            }
            return done;
        }

        public static bool AddPayment(Payment paymentToAdd)
        {
            bool done = true;
            using (var myDB = new VirtualCollegeContext())
            {
                var users = myDB.Users.
                    ToList();

                var addresses = myDB.Addresses.ToList();

                var courses = myDB.Courses.
                    Include("Teachers").
                    ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                Student userToAddPayment = (Student)users.Find(u => u.UserId == paymentToAdd.Student.UserId);
                userToAddPayment.AddPayment(paymentToAdd.Date, paymentToAdd.Amount);

                myDB.SaveChanges();
            }
            return done;
        }

        public static bool UpdateCourse(Course _courseToEdit)
        {
            using (var myDB = new VirtualCollegeContext())
            {
                var students = myDB.Users.
                    Include("Lessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var addresses = myDB.Addresses.ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                var courses = myDB.Courses.
                    Include("Teachers").
                    ToList();

                var courseToEdit = courses.Find(c => c.CourseId == _courseToEdit.CourseId);
                courseToEdit.Title = _courseToEdit.Title;
                courseToEdit.Credits = _courseToEdit.Credits;
                courseToEdit.ReferentTeacher = teachers.Find(x => x.UserId == _courseToEdit.ReferentTeacher.UserId);
                courseToEdit.Teachers.Clear();
                foreach (Teacher teacher in _courseToEdit.Teachers)
                {
                    courseToEdit.Teachers.Add(teachers.Find(x=>x.UserId == teacher.UserId));
                }
                myDB.SaveChanges();
            }
            return true;
        }

        public static bool UpdateGrade(Grade _gradeToEdit)
        {
            using (var myDB = new VirtualCollegeContext())
            {
                var students = myDB.Users.
                    Include("Lessons").
                    OfType<Student>().
                    ToList();

                var teachers = myDB.Users.
                    Include("Courses").
                    OfType<Teacher>().
                    ToList();

                var addresses = myDB.Addresses.ToList();

                var lessons = myDB.Lessons.
                    Include("Students").
                    ToList();

                var grades = myDB.Grades.ToList();

                var payments = myDB.Payments.ToList();

                var courses = myDB.Courses.
                    Include("Teachers").
                    ToList();

                var gradeToChange = grades.Find(g => g.GradeId == _gradeToEdit.GradeId);
                gradeToChange.Mark = _gradeToEdit.Mark;
                gradeToChange.ExamName = _gradeToEdit.ExamName;
                gradeToChange.Coefficient = _gradeToEdit.Coefficient;

                myDB.SaveChanges();
            }
            return true;
        }
        #endregion

        #region Remove entitites
        public static bool RemoveUser(User _userToRemove) // Removes a single User
        {
            using (var myDB = new VirtualCollegeContext())
            {
                myDB.Users.Remove(myDB.Users.Find(_userToRemove.UserId));
                myDB.SaveChanges();
            }

            return true;
        }

        public static bool RemoveUser(List<User> _usersToRemove) // Removes a list of Users
        {
            foreach (User u in _usersToRemove) RemoveUser(u);
            return true;
        }

        public static void RemoveCourse(Course _courseToRemove)
        {
            if (_courseToRemove != null)
            {
                using (var myDB = new VirtualCollegeContext())
                {
                    myDB.Courses.Remove(myDB.Courses.Find(_courseToRemove.CourseId));
                    myDB.SaveChanges();
                }
            }
        }

        public static void RemoveGrade(Grade _gradeToRemove)
        {
            using (var myDB = new VirtualCollegeContext())
            {
                myDB.Grades.Remove(myDB.Grades.Find(_gradeToRemove.GradeId));
                myDB.SaveChanges();
            }
        }
        #endregion

        #endregion
    }
}