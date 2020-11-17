using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorsetOOP
{
    public class Student
    {
        public Student()
        {

        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double StudentFees { get; set; }
        //public DataBaseSQL StudentGradeBook { get; set; }
        //public FacultyMembers StudentTutor { get; set; }

        public string ShowContact()
        {
            string showContact = $"ID : {ID}\nFirst Name : {FirstName}\nLast Name : {LastName}";
            return showContact;
        }

        public string ShowFees()
        {
            string ShowFees = $"Fees : {StudentFees}\n";
            return ShowFees;
        }
    }
}
