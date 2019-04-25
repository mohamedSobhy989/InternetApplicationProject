using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetApplicationProject.App_Code
{
    public class UserRoles
    {
        public enum userRole
        {
            Admin               = 1,
            Customer            = 2,
            Marketing_Director  = 3,
            Marketing_TeamLeade = 4,
            Marketing_Trainee   = 5
        }
    }
}