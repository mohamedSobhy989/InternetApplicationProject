using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternetApplicationProject.Models
{
    public class Projects
    {
        // this is primary key 
        public int Id { get; set; }

        [Display(Name = "Project Name")]
        [Required(ErrorMessage = "The Project Name is required")]
        public string project_Name { get; set; }

        [Required]
        [Display(Name = "customer ID")]
        //public Users customer { get; set; }
        public int customerid { get; set; }

        // {0 , 1}
        // 0 is not assigned to director 
        // 1 is assigned to director
        [Required]
        [Display(Name = "Is Project Assigned")]
        public int projectState { get; set; }

        // {0 , 1}
        // 0 is not finished
        // 1 is finished
        [Required]
        [Display(Name = "Is Project Delevered")]
        public int projectDelevered { get; set; }

        [Display(Name = "Project Price")]
        [Required(ErrorMessage = "The Project Price is required")]
        public float Price { get; set; }

        // this is description for project
        [Display(Name = "Project description")]
        [Required(ErrorMessage = "The Project description is required")]
        public string description { get; set; }
    }
}