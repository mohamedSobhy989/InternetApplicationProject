﻿using System;
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
        public Users teamleader { get; set; }
        public int teamleaderID { get; set; }

        // Forign key refers to project
        public Projects project { get; set; }
        public int projectID { get; set; }

        public int directorID { get; set; }

        // {0 , 1 , 2}
        // 0 is delevered
        // 1 is joining
        // 2 is requested
        // 3 is rejected from the leader
        public int ProjectState { get; set; }

        
        public int memberOne   { get; set; }

        public int memberTwo   { get; set; }

        public int memberThree { get; set; }
    }
}