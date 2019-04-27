
using InternetApplicationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternetApplicationProject.Controllers
{
    public class TreaneeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Treanee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TreaneeJoiningProject()
        {
            CustomerController customer = new CustomerController();
            try
            {
                int id = int.Parse(Session["userID"].ToString());
                var projects = customer.getDeleverdProject().Where(project => project.projectDelevered == 0 && project.TreaneeId == id);

                return View(projects);
            }
            catch (Exception)
            {
                return RedirectToAction("MyLogin", "Authontcation");
            }

        }

        //********************************************************************
        [HttpGet]
        public ActionResult updateInfo()
        {
            int id = int.Parse(Session["userID"].ToString());
            var data = db.user.Single(u => u.Id == id);
            return View(data);
        }

        [HttpPost]
        public ActionResult updateInfo(OurUsers user)
        {
            int id = int.Parse(Session["userID"].ToString());
            if (!ModelState.IsValid)
            {
                var myuser = db.user.ToList();
                return View("updateInfo", myuser);
            }
            var userDB = db.user.Single(u => u.Id == id);
            userDB.FirstName = user.FirstName;
            userDB.LastName = user.LastName;
            userDB.UserEmail = user.UserEmail;
            userDB.UserPassword = user.UserPassword;
            userDB.confirmPassword = user.confirmPassword;
            userDB.job_description = user.job_description;
            userDB.role = user.role;

            db.SaveChanges();



            return View(user);
        }
        //********************************************************************

        public ActionResult TreaneeDeleverdProject()
        {
            try
            {
                int id = int.Parse(Session["userID"].ToString());
                var projects = getDeleverdProject().Where(project => project.projectDelevered == 1 && project.TreaneeId == id);
                return View(projects);
            }
            catch (Exception)
            {
                return RedirectToAction("MyLogin", "Authontcation");
            }

        }
       

        public IEnumerable<Projects> getDeleverdProject()
        {
            var projects = db.project.ToList();
            return projects;
        }

        //****************************************************************************

        public ActionResult RemoveDeleverdTreaneeProduct(int? id)
        {
            if (!ModelState.IsValid || id == null)
            {
                return View("TreaneeDeleverdProject");
            }
            var myProduct = db.project.Single(p => p.Id == id);
            db.project.Remove(myProduct);
            db.SaveChanges();
            int Userid = int.Parse(Session["userID"].ToString());
            var allProjects = getDeleverdProject().Where(project => project.projectDelevered == 1 && project.customerid == Userid);

            return RedirectToAction("TreaneeDeleverdProject", allProjects);

            //return View("TreaneeDeleverdProject", allProjects);
        }

        //*************************************************************************************

        public ActionResult LeaveProject(int id)
        {
            try
            {
                int UserId = int.Parse(Session["userID"].ToString());
                ProjectLeavesTreanee tl = new ProjectLeavesTreanee();
                ViewBag.wait = "You Must continue in Your Work Unless Director Accept Your Request";

                tl.ProjectID = id;
                tl.TreaneeID = UserId;
                db.TreaneeLeaves.Add(tl);
                db.SaveChanges();
                return RedirectToAction("TreaneeJoiningProject");
            }
            catch (Exception)
            {
                ViewBag.wait = "Error .... try again later";
                return RedirectToAction("TreaneeJoiningProject");
            }
        }

    }
}