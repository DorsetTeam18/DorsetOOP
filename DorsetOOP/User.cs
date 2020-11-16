using System;
using System.Collections.Generic;
using System.Text;

namespace User
{
    class User
        //This class regroups all the information for a person to log in
    {
        //CHAMPS
        string userId;
        string password;
        string loginStatus;

        //CONSTRUCTOR
        public User(string UserId, string Password, string LoginStatus)
        {
            this.userId = UserId;
            this.password = Password;
            this.loginStatus = LoginStatus;
        }

        //PROPRIETIES   
        public string UserId
        {
            get { return this.userId; }
            set { this.userId = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public string LoginStatus
        {
            get { return this.loginStatus; }
            set { this.loginStatus = value; }
        }

        //METHODS
        public override string ToString()
        {
            if(loginStatus=="online")
            {
                return $"{UserId} is connected";
            }
            else
            {
                return $"{UserId} is not connected for the moment";
            }
        }

        public bool VerifyPassword()
        {
            Console.WriteLine("Verify your password");
            Console.WriteLine("Enter you password : ");
            string triedPassword = Convert.ToString(Console.ReadLine());
            if(triedPassword==Password && triedPassword!=null)
            {
                Console.Write("Correct password");
                return true;
            }
            else
            {
                Console.WriteLine("Incorrect password");
                return false;
            }
            

        }
    }
}
