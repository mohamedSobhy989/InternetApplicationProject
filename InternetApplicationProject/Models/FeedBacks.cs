using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using InternetApplicationProject.Models;

namespace InternetApplicationProject.Models
{
    public class FeedBacks
    {
        // this is primary key 
        public int Id { get; set; }

        public int leaderId { get; set; }

        public string feedback { get; set; }

        public Users member { get; set; }
        public int memberId { get; set; }

    }
}