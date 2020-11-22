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
    public class VirtualCollegeDBContext : DbContext
    {
        public VirtualCollegeDBContext() : base("name=VirtualCollegeDB") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
    }
}
