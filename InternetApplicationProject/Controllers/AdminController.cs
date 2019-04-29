using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InternetApplicationProject.Models;

namespace InternetApplicationProject.Controllers
{
    public class AdminController : Controller
    {
        public handleUsers users = new handleUsers();
        public handleProjects projects = new handleProjects();
        public handleMemberFeedBacks feedbacks = new handleMemberFeedBacks();

        // GET: Admin
        public ActionResult Index()
        {
            //to view all admin information
            Users user = new handleUsers().getUser(7); //to be replaced with session user
            return View(user);
        }

        //------------------------------------------------------------

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //------------------------------------------------------------

        [HttpPost]
        public ActionResult Create(Users userNew)
        {
            if(ModelState.IsValid)
            {
                users.addUser(userNew);
            }
            return RedirectToAction("Index");
        } 

        //------------------------------------------------------------

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (ModelState.IsValid && (! (id == null)))
            {
                Users currentUser = users.getUser(id.Value);
                if (currentUser == null) { return RedirectToAction("Index") ; }
                return View(currentUser);
            }
            return View("Index");
        }

        //-------------------------------------------------------------

        [HttpPost]
        public ActionResult Edit(int id , Users newUser)
        {
            users.updateUser(id, newUser);
            users.checkOrNormalize();
            return RedirectToAction("Index");
        }

        //-------------------------------------------------------------

        public ActionResult Delete(int? id)
        {
            if(id == null) { return RedirectToAction("Index"); }
            users.deleteUser(id.Value);
            //reflect all deletions here
            users.checkOrNormalize();
            return RedirectToAction("Index");
        }

        //-------------------------------------------------------------

        public ActionResult ShowNames()
        {
            return View(users.getAllUsers());
        }

        //-------------------------------------------------------------

        public ActionResult ShowProjects()
        {
            return View(projects.getAllProjects());
        }

        //-------------------------------------------------------------

        [HttpGet]
        public ViewResult createProject()
        {
            return View();
        }

        //-------------------------------------------------------------

        [HttpPost]
        public ActionResult CreateProject(Projects newProject)
        {
            if(newProject.customerid != null && users.isUser(newProject.customerid))
            {
                if(newProject.projectState == 1 || (newProject.projectState == 0 && newProject.projectDelevered == 0))
                {
                    projects.addProject(newProject);
                }
            }
            return RedirectToAction("index");
        }

        //--------------------------------------------------------------

        public ActionResult DeleteProject(int? id)
        {
            if (id == null) { return RedirectToAction("Index"); }
            projects.deleteProject(id.Value);
            //reflect all deletions here
            projects.checkOrNormalize();
            return RedirectToAction("Index");
        }

        //--------------------------------------------------------------

        [HttpGet]
        public ActionResult EditProject(int? id)
        {
            if (!(id == null))
            {
                Projects currentProject = projects.getProject(id.Value);
                if (currentProject == null) { return RedirectToAction("Index"); }
                return View(currentProject);
            }
            return View("Index");
        }

        //--------------------------------------------------------------

        [HttpPost]
        public ActionResult EditProject(int id , Projects newProject)
        {
            if (newProject.projectState == 1 || (newProject.projectState == 0 && newProject.projectDelevered == 0))
            {
                projects.updateProject(id, newProject);
            }
            return RedirectToAction("Index");
        }
    }
}