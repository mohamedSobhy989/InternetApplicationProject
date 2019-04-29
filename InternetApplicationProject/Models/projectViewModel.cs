using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InternetApplicationProject.Models;

namespace InternetApplicationProject.Models
{
    public class projectViewModel
    {
        public IEnumerable<teamLeaderProjects> joined { get; set; }
        public IEnumerable<teamLeaderProjects> deliverd {get; set;}
    }
}