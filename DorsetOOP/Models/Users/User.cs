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
    public abstract class User
    //This class regroups all the information for a person to log in
    {
        #region Properties
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        // One to many
        public int? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public Address Address { get; set; }

        #endregion

        public string FullName
        {
            get { return $"{ FirstName } { LastName }"; }
        }
           
        /*public override string ToString()
        {
            if (loginStatus == "online")
            {
                return $"{UserId} is connected";
            }
            else
            {
                return $"{UserId} is not connected for the moment";
            }
        }*/

        /*public bool VerifyPassword()
        {
            Console.WriteLine("Verify your password");
            Console.WriteLine("Enter you password : ");
            string triedPassword = Convert.ToString(Console.ReadLine());
            if (triedPassword == Password && triedPassword != null)
            {
                Console.Write("Correct password");
                return true;
            }
            else
            {
                Console.WriteLine("Incorrect password");
                return false;
            }
        }*/
    }
}
