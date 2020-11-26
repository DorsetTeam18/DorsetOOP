using DorsetOOP.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorsetOOP.Models
{
    public class Payment
    {

        public int PaymentId { get; set; }
        public DateTime Date { get; set; }
        public long Amount { get; set; }

        // One to many (each student has many fees, each fee has one student)
        public int? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
