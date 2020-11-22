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
            modelBuilder.Entity<Lesson>().ToTable("Lessons");
        }

        public virtual DbSet<User> Users { get; set; }
        //public virtual DbSet<Student> Students { get; set; }
        //public virtual DbSet<Teacher> Teachers { get; set; }
        //public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
    }
}
