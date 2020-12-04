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
	/// <summary>
	/// Name of the Students :
	/// Wim Poignon 23408
    /// </summary>
    public class Address
    {
        public int AddressId { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Postcode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        // One to many (each adress can have multiple users)
        public ICollection<User> Users { get; set; }

        public override string ToString()
        {
            return $"{ AddressLine1 }\n{ AddressLine2 }\n{ Postcode }, { City }\n{ State }, { Country }";
        }
    }
}
