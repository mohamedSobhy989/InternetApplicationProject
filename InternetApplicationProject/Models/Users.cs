﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternetApplicationProject.Models
{
    public class Users
    {

        // this is primary key 
        public int Id { get; set; }

        [Display(Name = "First Name")]   // this is the name that display in view
        [Required(ErrorMessage = "The User First Name is required")] // it is required
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "The User Last Name is required")]
        public string LastName { get; set; }

        [Display(Name = "User Email")]
        [Required(ErrorMessage = "The User Email is required ")]
        [EmailAddress(ErrorMessage = " the format of your mail is Invalid")]// this is belong the format of email 
        public string Email { get; set; }

        [Display(Name = "User Photo")]
        public byte[] Photo { get; set; }

        [Display(Name = "User Phone")]
        [Required(ErrorMessage = "Your Phone is required ")]
        public long Phone { get; set; }

        [Display(Name = "User job description")]
        [Required(ErrorMessage = "Your Job description is required ")]
        public string job_description { get; set; }

        // {1 , 2 , 3 , 4 , 5}
        // 1 is Admin
        // 2 is customer
        // 3 is Director
        // 4 is team leader
        // 5 is members
        [Required]
        public int role { get; set; }

    }
}