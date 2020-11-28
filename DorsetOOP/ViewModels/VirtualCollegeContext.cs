using DorsetOOP.Models;
using DorsetOOP.Models.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Payment> Payments { get; set; }

        #region Static Methods

        #region Get All Elements
        public static List<T> GetAll<T>()
        {
            var t = new List<T>();
            using (var myDB = new VirtualCollegeContext())
            {
                var addresses = myDB.Addresses.ToList();
                var courses = myDB.Courses.ToList();
                var lessons = myDB.Lessons.ToList();
                var grades = myDB.Grades.ToList();
                var payments = myDB.Payments.ToList();

                t = myDB.Users.OfType<T>().ToList();
            }
            return t;
        }

        public static List<Course> GetAllCourses()
        {
            var t = new List<Course>();
            using (var myDB = new VirtualCollegeContext())
            {
                var addresses = myDB.Addresses.ToList();
                var users = myDB.Users.ToList();
                var lessons = myDB.Lessons.ToList();
                var grades = myDB.Grades.ToList();
                var payments = myDB.Payments.ToList();

                t = myDB.Courses.ToList();
            }
            return t;
        }
        #endregion

        #region Get all that match text
        public static List<Student> GetAllStudentsThatMatchFullName(string _fullName) // Returns a list of all the students in the DB whose full names math the input
        {
            var tempStuds = new List<Student>();
            using (var myDB = new VirtualCollegeContext())
            {
                var addresses = myDB.Addresses.ToList();
                var teachers = myDB.Users.OfType<Teacher>().ToList();
                var courses = myDB.Courses.ToList();
                var lessons = myDB.Lessons.ToList();
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
            var tempStuds = new List<Teacher>();
            using (var myDB = new VirtualCollegeContext())
            {
                var addresses = myDB.Addresses.ToList();
                var students = myDB.Users.OfType<Student>().ToList();
                var courses = myDB.Courses.ToList();
                var lessons = myDB.Lessons.ToList();
                var grades = myDB.Grades.ToList();
                var payments = myDB.Payments.ToList();

                tempStuds = myDB.Users.OfType<Teacher>().ToList().FindAll(s => s.FullName.ToLower().Contains(_fullName.ToLower()));
            }
            return tempStuds;
        }

        public static List<Course> GetAllCoursesThatMatchTitle(string _courseTitle)
        {
            var courses = new List<Course>();
            using (var myDB = new VirtualCollegeContext())
            {
                var addresses = myDB.Addresses.ToList();
                var students = myDB.Users.OfType<Student>().ToList();
                var lessons = myDB.Lessons.ToList();
                var grades = myDB.Grades.ToList();
                var payments = myDB.Payments.ToList();

                courses = myDB.Courses.ToList().FindAll(c => c.Title.ToLower().Contains(_courseTitle.ToLower()));
            }
            return courses;
        }
        #endregion

        #region Add and Remove
        public static bool CreateUser(User _userToAdd, Address _addressToAdd) // Creates new User if doesn't already exist (checks email)
        {
            using (var myDB = new VirtualCollegeContext())
            {
                bool done = false;
                var users = myDB.Users.ToList();
                var addresses = myDB.Addresses.ToList();
                var students = myDB.Users.OfType<Student>().ToList();
                var teachers = myDB.Users.OfType<Teacher>().ToList();
                var courses = myDB.Courses.ToList();
                var lessons = myDB.Lessons.Include("Students").ToList();
                var grades = myDB.Grades.ToList();
                var payments = myDB.Payments.ToList();

                string _description = _addressToAdd.ToString();
                Address match = addresses.Find(a => a.ToString() == _description);

                if (users.FindAll(s => s.EmailAddress == _userToAdd.EmailAddress).Count() == 0)
                {
                    if (match == null) _userToAdd.Address = _addressToAdd;
                    else _userToAdd.Address = match;
                    myDB.Users.Add(_userToAdd);
                    done = true;
                }
                myDB.SaveChanges();
                return done;
            }
        }

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
        #endregion

        #endregion
    }
}