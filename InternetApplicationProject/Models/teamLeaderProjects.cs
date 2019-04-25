using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetApplicationProject.Models
{
    public class teamLeaderProjects
    {
        // this is primary key 
        public int Id { get; set; }

        // Forign key refers to user (team leader)
        public OurUsers teamleader { get; set; }
        public int teamleaderID { get; set; }

        // Forign key refers to project
        public Projects project { get; set; }
        public int projectID { get; set; }

        // {0 , 1 , 2}
        // 0 is not delevered
        // 1 is joining
        // 2 is requested
        public int ProjectState { get; set; }
    }
}