using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InternetApplicationProject.Models;

namespace InternetApplicationProject.Controllers
{
    public class TeamLeaderController : Controller
    {
        public handleTeamLeader leaders = new handleTeamLeader();
        public handleUsers users = new handleUsers();
        public handleProjects projects = new handleProjects();

        public ActionResult Index()
        {
            Users currentUser = users.getUser(11);
            if(currentUser == null)
            {
                return HttpNotFound();
            }
            return View(currentUser);
        }

        //------------------------------------------------------------------

        public ActionResult Requested()
        {
            return View(leaders.getRequestedProjects(11));
        }

        //------------------------------------------------------------------

        public ActionResult ViewDirector(int? id)
        {

            if(id == null) { return RedirectToAction("Requested"); }
            if(! users.isDirector(id.Value)) { return RedirectToAction("Requested"); }
            if(! leaders.isRelated(11 , id.Value)) { return RedirectToAction("Requested"); }

            Users u = users.getUser(id.Value);
            if(u == null) { return RedirectToAction("Requested"); }
            return View(u);
        }

        //------------------------------------------------------------------

        public ActionResult ViewProject(int? id)
        {
            if (id == null) { return RedirectToAction("Requested"); }
            if (! projects.isProject(id.Value)) { return RedirectToAction("Requested"); }
            if (! leaders.isProjectRelated(11, id.Value)) { return RedirectToAction("Requested"); }

            Projects project = projects.getProject(id.Value);
            return View(project);
        }

        //-----------------------------------------------------------------
        
        public ActionResult AcceptRequested(int? id)
        {
            if(id == null) { return RedirectToAction("Requested"); }
            
            teamLeaderProjects item = leaders.getItem(id.Value);
            if(item != null && item.teamleaderID == 11) //here it's 11 waiting for sessio
                item.ProjectState = 1;
                leaders.updateItem(id.Value , item);
            return RedirectToAction("Requested");
        }

        //-----------------------------------------------------------------

        public ActionResult RejectRequested(int? id)
        {
            if (id == null) { return RedirectToAction("Requested"); }

            teamLeaderProjects item = leaders.getItem(id.Value);
            if (item != null && item.teamleaderID == 11) //here it's 11 waiting for sessio
                item.ProjectState = 3;
            leaders.updateItem(id.Value, item);
            return RedirectToAction("Requested");
        }

    }
}