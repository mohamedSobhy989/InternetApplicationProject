using InternetApplicationProject.Models;
using InternetApplicationProject.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternetApplicationProject.Controllers
{
    public class OurHomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: OurHome
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OnProgress()
        {
            var onProgressProject = getOnProgressProject();
            return View(onProgressProject);
            
        }

        public IEnumerable<OnProgress> getOnProgressProject()
        {
            var projects = db.onProgresses.ToList();
            return projects;
        }

        [HttpPost]
        public ActionResult AddProduct()
        {
            if (!ModelState.IsValid)
            {
                return View("OnProgress");
            }

            if (Session["userRole"] != null)
            {
                int id = int.Parse(Session["userID"].ToString()); 
                int role = int.Parse(Session["userRole"].ToString()); 

                if (role == 2)
                {
                    return RedirectToAction("AddProduct" , "Customer");
                //    string fileName = Path.GetFileNameWithoutExtension(model.imageFile.FileName);
                //    string extention = Path.GetExtension(model.imageFile.FileName);
                //    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                //    model.PhotoPath = "~/Image/" + fileName;
                //    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                //    model.imageFile.SaveAs(fileName);

                //    model.customerid = id;
                //    model.projectDelevered = 0;



                //    db.onProgresses.Add(model);
                //    db.SaveChanges();
                //    ModelState.Clear();

                //    return View();
                }
                else
                {
                    ViewBag.role = "Sorry Just Customer Can Add Projects";
                    return RedirectToAction("OnProgress");
                }

            }
            else
            {
                return RedirectToAction("HomeLogin", "OurHome");
            }
            

        }


        public ActionResult AssignProject(int id)
        {


            if (Session["userRole"] != null)
            {
                int userid = int.Parse(Session["userID"].ToString());
                int role = int.Parse(Session["userRole"].ToString());

                var OurUser = db.user.Single(u => u.Id == userid);
                var OurProject = db.onProgresses.Single(p => p.Id == id);
                

                if (role == 3)
                {

                    projectAssignedDirector PAD = new projectAssignedDirector();
                    PAD.projectID = id;
                    PAD.directoryID = userid;
                    PAD.project = OurProject;
                    PAD.directory = OurUser;


                    db.P_AssignDirector.Add(PAD);
                    db.SaveChanges();

                    ViewBag.rolcheck = 1;
                    ViewBag.sussefullyAssigned = " Assigned Successfully Wait Accept customer ";
                    //return RedirectToAction("OnProgress", "OurHome");
                    return View("OnProgress");
                    
                }
                else
                {
                    ViewBag.rolcheck = 0;
                    ViewBag.role = "Sorry Just Director  Can Assign Projects";
                    return RedirectToAction("OnProgress");
                    //return View();
                }

            }
            else
            {
                return RedirectToAction("HomeLogin", "OurHome");
            }

        }
















        [HttpGet]
        public ActionResult HomeLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HomeLogin(OurUsers user)
        {
            if (ModelState.IsValid == true)
            {
                return View("HomeLogin", user);
            }

            var myUser = db.user.Where(u => u.UserEmail == user.UserEmail
                                && u.UserPassword == user.UserPassword).FirstOrDefault();
            if (myUser != null)
            {
                Session["userID"] = myUser.Id.ToString();
                Session["userF_Name"] = myUser.FirstName.ToString();
                Session["userL_Name"] = myUser.LastName.ToString();
                Session["userEmail"] = myUser.UserEmail.ToString();
                Session["userPassword"] = myUser.UserPassword.ToString();
                Session["userPhone"] = myUser.Phone.ToString();
                Session["userJob"] = myUser.job_description.ToString();
                Session["userRole"] = myUser.role.ToString();
                Session["userImage"] = myUser.PhotoPath.ToString();

                if (myUser.role == 2)
                {
                    return RedirectToAction("AddProduct", "Customer");
                }
                else
                {
                    ViewBag.errorMessege = " Sorry Just Customer Can Add Product ";
                    return RedirectToAction("OnProgress", "OurHome");
                }
            }
            else
            {
                ViewBag.errorMessege = " Incorrect User Email Or Password ";
                return RedirectToAction("HomeLogin", user);
                //return View("MyLogin", "User Email or password in incorrect", user);

            }



            return View();
        }
























    }

}