using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace DorsetOOP.Users
{
    public abstract class User
    {
        public string userId { get; set; }
        public string Password { get; set; }
        public bool loginStatus { get; set; }

    }
}
