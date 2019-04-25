using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InternetApplicationProject.Models;

namespace InternetApplicationProject.ViewModels
{
    public class ProjectWithMembers
    { 
        public IEnumerable<Projects> project { get; set; }
        public IEnumerable<projectAssignedDirector> markitingDirector { get; set; }
    }
}