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

        }

        public virtual DbSet<User> Users { get; set; }
        //public virtual DbSet<Student> Students { get; set; }
        //public virtual DbSet<Teacher> Teachers { get; set; }
        //public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

        public static List<Student> GetStudents()
        {
            var t = new List<Student>();
            using (var myDB = new VirtualCollegeContext())
            {
                var addresses = myDB.Addresses.ToList();
                var teachers = myDB.Users.OfType<Teacher>().ToList();
                var courses = myDB.Courses.ToList();
                var lessons = myDB.Lessons.ToList();
                var grades = myDB.Grades.ToList();
                var payments = myDB.Payments.ToList();
                t = myDB.Users.OfType<Student>().ToList();
            }
            return t;
        }

        public static bool CreateUser(User _userToAdd, Address _addressToAdd)
        {
            using (var myDB = new VirtualCollegeContext())
            {
                bool done = false;
                var users = myDB.Users.ToList();
                var addresses = myDB.Addresses.ToList();
                var students = myDB.Users.OfType<Student>().ToList();
                var teachers = myDB.Users.OfType<Teacher>().ToList();
                var courses = myDB.Courses.ToList();
                var lessons = myDB.Lessons.ToList();
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

        public static bool RemoveUser(User _userToRemove)
        {
            using (var myDB = new VirtualCollegeContext())
            {
                var users = myDB.Users.ToList();
                var addresses = myDB.Addresses.ToList();
                var courses = myDB.Courses.ToList();
                var lessons = myDB.Lessons.ToList();
                var grades = myDB.Grades.ToList();
                var payments = myDB.Payments.ToList();

                myDB.Users.Remove(myDB.Users.Find(_userToRemove.UserId));

                myDB.SaveChanges();
            }

            return true;
        }
        public static bool RemoveUser(List<User> _usersToRemove)
        {
            foreach (User u in _usersToRemove) RemoveUser(u);
            return true;
        }
    }
}