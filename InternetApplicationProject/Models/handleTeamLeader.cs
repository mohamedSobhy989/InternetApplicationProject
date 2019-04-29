using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InternetApplicationProject.Models;

namespace InternetApplicationProject.Models
{
  
    public class handleTeamLeader
    {
        public ApplicationDbContext bda = new ApplicationDbContext();

        public teamLeaderProjects getItem(int id)
        {
            return bda.TL_Project.SingleOrDefault(item => item.Id == id);
        }

        //----------------------------------------------------------------------

        public void updateItem(int id , teamLeaderProjects newItem)
        {
            teamLeaderProjects oldItem = getItem(id);
            if(oldItem != null)
            {
                oldItem.teamleaderID = newItem.teamleaderID;
                oldItem.directorID = newItem.directorID;
                oldItem.ProjectState = newItem.ProjectState;
            }
            bda.SaveChanges();
        }

        //----------------------------------------------------------------------

        public teamLeaderProjects getItemByProjectId(int pid)
        {
            return bda.TL_Project.SingleOrDefault(item => item.projectID == pid);
        }

        //----------------------------------------------------------------------

        public IEnumerable<teamLeaderProjects> getRequestedProjects(int id)
        {
            return bda.TL_Project.ToList().Where(pr => pr.ProjectState == 2 && pr.teamleaderID == id);
        }

        //----------------------------------------------------------------------

        public IEnumerable<teamLeaderProjects> getJoinedProjects(int id)
        {
            return bda.TL_Project.ToList().Where(pr => pr.ProjectState == 1 && pr.teamleaderID == id);
        }

        //----------------------------------------------------------------------

        public IEnumerable<teamLeaderProjects> getDeliveredProjects(int id)
        {
            return bda.TL_Project.ToList().Where(pr => pr.ProjectState == 0 && pr.teamleaderID == id);
        }

        //----------------------------------------------------------------------

        public IEnumerable<teamLeaderProjects> getLeavedProjects(int id)
        {
            return bda.TL_Project.ToList().Where(pr => pr.ProjectState == 3 && pr.teamleaderID == id);
        }

        //----------------------------------------------------------------------

        public bool isRelated(int leaderId , int directorId)
        {
            return bda.TL_Project.ToList()
                 .Where(
                     item => item.teamleaderID == leaderId && item.directorID == directorId && item.ProjectState != 3)
                 .Count() == 0 ? false : true;
        }

        //----------------------------------------------------------------------

        public bool isProjectRelated(int leaderId, int projectId)
        {
            return bda.TL_Project.ToList()
                 .Where(
                     item => item.teamleaderID == leaderId && item.projectID == projectId && item.ProjectState != 3)
                 .Count() == 0 ? false : true;
        }

        //----------------------------------------------------------------------

        public bool isMemberRelated(int leaderId , int memberId)
        {
            return bda.TL_Project.ToList()
                 .Where(
                     item => item.teamleaderID == leaderId && ( 
                     item.memberOne == memberId || item.memberTwo == memberId ||
                     item.memberThree == memberId))
                 .Count() == 0 ? false : true;
        }

        //----------------------------------------------------------------------

        public IEnumerable<Users> getProjectUsers(int pid , int Lid)
        {
            List<Users> c = new List<Users>();
            handleUsers users = new handleUsers(); 

            foreach(var item in getJoinedProjects(Lid))
            {
                if(item.projectID == pid)
                {
                    if (item.memberOne != 0)
                    {
                        if(users.isUser(item.memberOne)) c.Add(users.getUser(item.memberOne));
                    }
                    if (item.memberTwo != 0)
                    {
                        if (users.isUser(item.memberTwo)) c.Add(users.getUser(item.memberTwo));
                    }
                    if (item.memberThree != 0)
                    {
                        if (users.isUser(item.memberThree)) c.Add(users.getUser(item.memberThree));
                    }
                }
            }
            return c;
        }

        //-------------------------------------------------------------------

        public bool isIdRelated(int id, int leaderId)
        {
            return bda.TL_Project.ToList()
                 .Where(
                     item => item.teamleaderID == leaderId && item.Id == id)
                 .Count() == 0 ? false : true;
        }

        //-------------------------------------------------------------------

        public IEnumerable<Users> getAllRelatedMembers(int leaderId)
        {
            List<teamLeaderProjects> t = bda.TL_Project.ToList().Where
                (
                    item => item.ProjectState == 1 && item.teamleaderID == leaderId
                ).ToList();
            List<Users> relatedMembers = new List<Users>();
            handleUsers users = new handleUsers();
            foreach (var tp in t)
            {
                if (tp.memberOne != 0) {
                    Users user = users.getUser(tp.memberOne);
                    if (user != null) relatedMembers.Add(user);
                }
                if (tp.memberTwo != 0)
                {
                    Users user = users.getUser(tp.memberTwo);
                    if (user != null) relatedMembers.Add(user);
                }
                if (tp.memberThree != 0)
                {
                    Users user = users.getUser(tp.memberThree);
                    if (user != null) relatedMembers.Add(user);
                }

            }
            return relatedMembers;
        }
    }
}