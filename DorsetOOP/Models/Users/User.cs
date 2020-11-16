using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;


namespace DorsetOOP.Users
{
    public class User
    //This class regroups all the information for a person to log in
    {
        // Properties
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

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
