using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InternetApplicationProject.Models;
namespace InternetApplicationProject.Controllers
{
    public class DirectorController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Director
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Userinfo()
        {

            return View();

        }

        public ActionResult deliveredprojects()
        {

            int id = int.Parse(Session["userID"].ToString());
            var projects = delivered().Where(p => p.projectDelevered == 1 && p.customerid == id);
            return View(projects);

        }


        public IEnumerable<Projects> delivered()
        {
            var projects = db.project.ToList();
            return projects;
           
        }

    }
}