/// Team 18
/// Student names | ID:
/// Wim POIGNON 23408
/// Maélis YONES 23217
/// Rémi LOMBARD 23210
/// Christophe NGUYEN 23219
/// Gwendoline MAREK 23397
/// Maxime DENNERY 23203
/// Victor TACHOIRES 22844

using DorsetOOP.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DorsetOOP.Models
{
    public class Address
    {

        #region Properties / columns
        public int AddressId { get; set; }

        [Required]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Required]
        public string City { get; set; }

        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        // Many to one (each address has many users living at it, each user lives at only one address
        public ICollection<User> Users { get; set; }
        #endregion

        public override string ToString() // Custom ToString
        {
            string str = $"{ AddressLine1 }";
            if (AddressLine2 != null && AddressLine2 != "") str += $", { AddressLine2 }";
            str += $"\n{ Postcode }, { City }\n";
            if (State != null && State != "") str += $"{ State }, ";
            str += $"{ Country }";
            return str;
        }
    }
}
