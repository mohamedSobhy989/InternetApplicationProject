using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetApplicationProject.Models
{
    public class requestsForTeam
    {
        // this is primary key 
        public int Id { get; set; }

        // Forign key refers to user (team leader)
        public int role { get; set; }

        // Forign key refers to project
        public Projects project { get; set; }
        public int projectID { get; set; }

        // this is the member that requested to project
        // Forign key refers to user
        public Users Member { get; set; }
        public int memberID { get; set; }
    }
}