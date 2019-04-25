using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetApplicationProject.Models
{
    public class projectAssignedDirector
    {
        // this is primary key 
        public int Id { get; set; }

        // Forign key refers to project 
        public Projects project { get; set; }
        public int projectID { get; set; }

        // Forign key refers to user (director)
        public OurUsers directory { get; set; }
        public int directoryID { get; set; }

    }
}