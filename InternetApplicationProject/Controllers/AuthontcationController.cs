using InternetApplicationProject.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternetApplicationProject.Controllers
{
    public class AuthontcationController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        // GET: Authontcation
        // this is to view (UI)
        public ActionResult MyLogin()
        {
            return View();
        }
        
        [HttpPost]
        // Post: Authontcation
        // event hundler
        public ActionResult MyLogin(OurUsers user)
        {
            if (ModelState.IsValid == true)
            {
                return View("MyLogin", user);
            }
            try
            {

                var myUser = db.user.Single(u => u.UserEmail == user.UserEmail
                                    && u.UserPassword == user.UserPassword);
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
                    Session["userImage"]    = myUser.PhotoPath.ToString();

                    if (myUser.role == 1)
                    {
                        return RedirectToAction("actionName", "controllerName");

                    }

                    else if (myUser.role == 2)
                    {
                        // just to test when in need to call action 
                        // i will call index action in customer controller 
                        //return RedirectToAction("LoggedIn"); DeleverdProject
                        return RedirectToAction("DeleverdProject", "Customer");

                    }
                    else if (myUser.role == 3)
                    {
                        return RedirectToAction("actionName", "controllerName");

                    }
                    else if (myUser.role == 4)
                    {
                        return RedirectToAction("actionName", "controllerName");

                    }
                    else
                    {
                        return RedirectToAction("actionName", "controllerName");

                    }
                    //return Content("<h1> this is the role" + Session["userID"] + "</h1>");
                    //return RedirectToAction("");
                }
                else
                {
                    ModelState.AddModelError("", "User Email or password in incorrect");
                }
            }
            catch (Exception)
            {

                return View("MyLogin", user);
            }

            return View();
        }
        



    }
}