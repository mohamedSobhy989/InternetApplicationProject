﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InternetApplicationProject.Models;

namespace InternetApplicationProject.Controllers
{
    [Authorize]
    public class TeamLeaderController : Controller
    {
        public handleTeamLeader leaders = new handleTeamLeader();
        public handleUsers users = new handleUsers();
        public handleProjects projects = new handleProjects();
        public handleRequests requests = new handleRequests();
        public handleMemberFeedBacks feedbacks = new handleMemberFeedBacks();

        public ActionResult Index()
        {
            
            Users currentUser = users.getUser(Convert.ToInt32(Session["userID"]));
            if(currentUser == null)
            {
                return HttpNotFound();
            }
            return View(currentUser);
        }

        //------------------------------------------------------------------

        public ActionResult Requested()
        {
            return View(leaders.getRequestedProjects(Convert.ToInt32(Session["userID"])));
        }

        //------------------------------------------------------------------

        public ActionResult ViewDirector(int? id)
        {

            if(id == null) { return RedirectToAction("Requested"); }
            if(! users.isDirector(id.Value)) { return RedirectToAction("Requested"); }
            if(! leaders.isRelated(Convert.ToInt32(Session["userID"]), id.Value)) { return RedirectToAction("Requested"); }

            Users u = users.getUser(id.Value);
            if(u == null) { return RedirectToAction("Requested"); }
            return View(u);
        }

        //------------------------------------------------------------------

        public ActionResult ViewProject(int? id)
        {
            if (id == null) { return RedirectToAction("Requested"); }
            if (! projects.isProject(id.Value)) { return RedirectToAction("Requested"); }
            if (! leaders.isProjectRelated(Convert.ToInt32(Session["userID"]), id.Value)) { return RedirectToAction("Requested"); }

            Projects project = projects.getProject(id.Value);
            return View(project);
        }

        //-----------------------------------------------------------------
        
        public ActionResult AcceptRequested(int? id)
        {
            if(id == null) { return RedirectToAction("Requested"); }
            
            teamLeaderProjects item = leaders.getItem(id.Value);
            if(item != null && item.teamleaderID == Convert.ToInt32(Session["userID"])) //here it's 11 waiting for sessio
                item.ProjectState = 1;
                leaders.updateItem(id.Value , item);
            return RedirectToAction("Requested");
        }

        //-----------------------------------------------------------------

        public ActionResult RejectRequested(int? id)
        {
            if (id == null) { return RedirectToAction("Requested"); }

            teamLeaderProjects item = leaders.getItem(id.Value);
            if (item != null && item.teamleaderID == Convert.ToInt32(Session["userID"])) //here it's 11 waiting for sessio
                item.ProjectState = 3;
            leaders.updateItem(id.Value, item);
            return RedirectToAction("Requested");
        }

        //--------------------------------------------------------------

        public ActionResult projectStatues()
        {
            projectViewModel allProjects = new projectViewModel
            {
                joined = leaders.getJoinedProjects(Convert.ToInt32(Session["userID"])),
                deliverd = leaders.getDeliveredProjects(Convert.ToInt32(Session["userID"]))
            };
            return View(allProjects);
        }

        //--------------------------------------------------------------

        public ActionResult Evaluate()
        {
            TempData["ID"] = Convert.ToInt32(Session["userID"]);
            return View();
        }

        //--------------------------------------------------------------

        public ActionResult LeaveProject(int? id)
        {
            if(id == null) { return RedirectToAction("Index"); }
            if(!projects.isProject(id.Value)) { return RedirectToAction("Index"); }

            if (! leaders.isProjectRelated(Convert.ToInt32(Session["userID"]), id.Value)) { return RedirectToAction("Index"); }
            teamLeaderProjects p = leaders.getItemByProjectId(id.Value);
            if (p.ProjectState != 1) { return RedirectToAction("Index"); }
            p.ProjectState = 3;
            p.memberOne = 0;
            p.memberTwo = 0;
            p.memberThree = 0;
            leaders.updateItem(p.Id , p);
            return RedirectToAction("Index");
        }

        //------------------------------------------------------------------

        public ActionResult RemoveMember(int? id , int? uid)
        {
            if(id == null || uid == null) { return RedirectToAction("Index"); }
            if(! users.isUser(uid.Value)) { return RedirectToAction("Index"); }
            if(! leaders.isIdRelated(id.Value, Convert.ToInt32(Session["userID"]))) { return RedirectToAction("Index"); }

            teamLeaderProjects t = leaders.getItem(id.Value);
            if (t.memberOne == uid.Value) t.memberOne = 0;
            if (t.memberTwo == uid.Value) t.memberTwo = 0;
            if (t.memberThree == uid.Value) t.memberThree = 0;

            leaders.updateItem(id.Value, t);

            return RedirectToAction("Index");

        }

        //-------------------------------------------------------------------

        public ActionResult EvaluateMember(String names , String text)
        {
            if(names == null) { return RedirectToAction("Index"); }
            if(! leaders.isMemberRelated(Convert.ToInt32(Session["userID"]), int.Parse(names))) { return RedirectToAction("Index"); }
            if((! users.isUser(Convert.ToInt32(Session["userID"])) || (! users.isUser(int.Parse(names))))) { return RedirectToAction("Index"); }
            if (text == null) { text = ""; }
            int memberId = int.Parse(names);

            FeedBacks newOne = new FeedBacks();
            newOne.leaderId = Convert.ToInt32(Session["userID"]);
            newOne.feedback = text;
            newOne.memberId = memberId;

            feedbacks.addFeedBack(newOne);
            //ViewData["text"] = Request["text"];
            return View();
        }

        //-------------------------------------------------------------------

        [HttpGet]
        public ActionResult RequestMember()
        {
            TempData["ID"] = Convert.ToInt32(Session["userID"]);
            return View(new requestsForTeam());
        }

        //-------------------------------------------------------------------

        [HttpPost]
        public ActionResult RequestMember(requestsForTeam newRequest)
        {
            if(newRequest.projectID == 0 || newRequest.memberID == 0) return RedirectToAction("index");
            if (newRequest == null) return RedirectToAction("index");
            requests.addRequest(newRequest);
            return RedirectToAction("Index");
        }

        //-------------------------------------------------------------------

        public ActionResult statistics()
        {
            ViewData["r"] = leaders.getRequestedProjects(Convert.ToInt32(Session["userID"])).Count();
            ViewData["j"] = leaders.getJoinedProjects(Convert.ToInt32(Session["userID"])).Count();
            ViewData["d"] = leaders.getDeliveredProjects(Convert.ToInt32(Session["userID"])).Count();
            ViewData["l"] = leaders.getLeavedProjects(Convert.ToInt32(Session["userID"])).Count();
            return View();
        }
    }
}