using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InternetApplicationProject.Models;

namespace InternetApplicationProject.Models
{
    public class handleRequests
    {
        public ApplicationDbContext bda = new ApplicationDbContext();

        public void addRequest(requestsForTeam newRequest)
        {
            if (bda.R_ForTeam.ToList()
                .Where(item => item.role == newRequest.role &&
                       item.projectID == newRequest.projectID &&
                       item.memberID == newRequest.memberID).Count() == 0)
            {
                if (bda.R_ForTeam.ToList()
                .Where(item =>  item.role == newRequest.role &&
                                item.projectID == newRequest.projectID).Count() < 3)
                {
                    bda.R_ForTeam.Add(newRequest);
                    bda.SaveChanges();
                }
            }
        }
    }
}