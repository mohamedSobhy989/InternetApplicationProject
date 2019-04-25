using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetApplicationProject.Models
{
    public class projectMembers
    {
        // this is primary key 
        public int id { get; set; }

        // Forign key refers to project 
        public Projects project { get; set; }
        public int projectid { get; set; }


        // Forign key refers to user
        public OurUsers user { get; set; }
        public int member { get; set; }

        
        public int role { get; set; }

    }
}