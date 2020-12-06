/// Team 18
/// Student names | ID:
/// Wim POIGNON | 23408
/// Maélis YONES | 23217
/// Rémi LOMBARD | 23210
/// Christophe NGUYEN | 23219
/// Gwendoline MAREK | 23397
/// Maxime DENNERY | 23203
/// Victor TACHOIRES | 22844

using DorsetOOP.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorsetOOP.Models
{
    public class Payment // Registers a payment
    {
        #region Properties / columns
        public int PaymentId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Amount { get; set; }

        // One to many (each student has many payments, each payment has one student)
        public int? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        #endregion
    }
}
