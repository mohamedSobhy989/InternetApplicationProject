using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InternetApplicationProject.Models;

namespace InternetApplicationProject.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        //***************************************************************************
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(OurUsers user)
        {
            if (!ModelState.IsValid)
            {
                return View("Registration", user);
            }
            // take image
            
            string fileName = Path.GetFileNameWithoutExtension(user.imageFile.FileName);
            string extention = Path.GetExtension(user.imageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
            user.PhotoPath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            user.imageFile.SaveAs(fileName);
            

            db.user.Add(user);
            db.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("MyLogin", "Authontcation");
             
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
            userDB.LastName  = user.LastName;
            userDB.UserEmail = user.UserEmail;
            userDB.UserPassword = user.UserPassword;
            userDB.confirmPassword = user.confirmPassword;
            userDB.job_description = user.job_description;
            userDB.role = user.role;

            db.SaveChanges();



            return View(user);
        }
        //********************************************************************
        public ActionResult DeleverdProject()
        {
            try
            {
                int id = int.Parse(Session["userID"].ToString());
                var projects = getDeleverdProject().Where(project => project.projectDelevered == 1 && project.customerid == id);
                return View(projects);
            }
            catch (Exception)
            {
                return RedirectToAction("MyLogin", "Authontcation");
            }
            
        }

        public ActionResult JoiningProject()
        {
            try
            {
                int id = int.Parse(Session["userID"].ToString());
                var projects = getDeleverdProject().Where(project => project.projectDelevered == 0 && project.customerid == id);

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

        //************************ Add Product *************************************************

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Projects project)
        {

            string fileName = Path.GetFileNameWithoutExtension(project.imageFile.FileName);
            string extention = Path.GetExtension(project.imageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
            project.PhotoPath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            project.imageFile.SaveAs(fileName);


            int id = int.Parse(Session["userID"].ToString());
            project.customerid = id;
            project.projectDelevered = 0;

            if (!ModelState.IsValid)
            {
                return View("AddProduct", project);
            }

            db.project.Add(project);
            db.SaveChanges();
            ModelState.Clear();
          
            return View();
        }
        
        //**************************************************************************************
        [HttpGet]
        public ActionResult UpdateProduct(int? Id)
        {
            if (Id != null)
            {
                var myProduct = db.project.Single(p => p.Id == Id);
                return View(myProduct);
            }
            else
                return View();
        }

        [HttpPost]
        public ActionResult UpdateProduct(Projects project)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateProduct", project);
            }


            string fileName = Path.GetFileNameWithoutExtension(project.imageFile.FileName);
            string extention = Path.GetExtension(project.imageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
            project.PhotoPath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            project.imageFile.SaveAs(fileName);


            var myProduct = db.project.Single(p => p.Id == project.Id);
            myProduct.project_Name = project.project_Name;
            myProduct.description = project.description;
            myProduct.PhotoPath = project.PhotoPath;

            db.SaveChanges();



            return View(myProduct);
        }
        //***************************************************************
        [HttpGet]
        public ActionResult RemoveProduct(int? id)
        {
            if (!ModelState.IsValid || id == null)
            {
                return View("RemoveProduct");
            }
            var myProduct = db.project.Single(p => p.Id == id);
            db.project.Remove(myProduct);
            db.SaveChanges();
            int Userid = int.Parse(Session["userID"].ToString());
            var allProjects = getDeleverdProject().Where(project => project.projectDelevered == 0 && project.customerid == Userid);
            
            return View("JoiningProject" , allProjects);
        }
        public ActionResult RemoveDeleverdProduct(int? id)
        {
            if (!ModelState.IsValid || id == null)
            {
                return View("RemoveDeleverdProduct");
            }
            var myProduct = db.project.Single(p => p.Id == id);
            db.project.Remove(myProduct);
            db.SaveChanges();
            int Userid = int.Parse(Session["userID"].ToString());
            var allProjects = getDeleverdProject().Where(project => project.projectDelevered == 1 && project.customerid == Userid);

            return View("DeleverdProject", allProjects);
        }

    }
}