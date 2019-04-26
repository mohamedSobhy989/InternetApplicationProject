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
    }
}