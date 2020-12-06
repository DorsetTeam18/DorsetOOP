/// Team 18
/// Student names | ID:
/// Wim POIGNON 23408
/// Maélis YONES 23217
/// Rémi LOMBARD 23210
/// Christophe NGUYEN 23219
/// Gwendoline MAREK 23397
/// Maxime DENNERY 23203
/// Victor TACHOIRES 22844

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;


namespace DorsetOOP.Models.Users
{
    public abstract class User // Set as abstract because nobody can only be a user. They are necessarely a student, teacher or admin. This class regroups the common caracteristics
    {
        #region Properties / columns
        public int UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        // One to many (each user lives at only one address, each address can have multiple users live at it)
        public int? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public Address Address { get; set; }
        #endregion

        public string FullName // Returns the full name of a user
        {
            get { return $"{ FirstName } { LastName }"; }
        }
    }
}
