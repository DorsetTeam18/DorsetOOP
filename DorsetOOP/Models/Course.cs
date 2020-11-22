using DorsetOOP.Models.Users;
using System;
using System.Collections.Generic;
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

        public int CourseId { get; set; }
        public string Title { get; set; }
        public decimal Credits { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
    }
}
