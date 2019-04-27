using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetApplicationProject.Models
{
    public class ProjectLeavesTreanee
    {
        // this is primary key 
        public int Id { get; set; }

        public Projects Project { get; set; } 
        public int ProjectID { get; set; }

        public OurUsers treanee { get; set; }
        public int TreaneeID { get; set; } 
    }
}