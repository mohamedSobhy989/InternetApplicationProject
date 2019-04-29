using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InternetApplicationProject.Models;
namespace InternetApplicationProject.ViewModels
{
    public class HomeModeles
    {
        public OnProgress project = new OnProgress();

        public IEnumerable<OnProgress> projects;

        public OurUsers user = new OurUsers();
    }
}