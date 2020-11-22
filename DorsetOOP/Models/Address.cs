using DorsetOOP.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorsetOOP.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        [Required]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
