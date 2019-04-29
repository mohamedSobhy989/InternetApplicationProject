using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetApplicationProject.Models
{
    public class handleMemberFeedBacks
    {
        ApplicationDbContext bda = new ApplicationDbContext();

        public void addFeedBack(FeedBacks newFeedBack)
        {
            if(bda.feedback.ToList().Where(
                f => f.memberId == newFeedBack.memberId &&
                     f.leaderId == newFeedBack.leaderId
                ).Count() == 0)
            {
                bda.feedback.Add(newFeedBack);
                bda.SaveChanges();
            }
            else
            {
                FeedBacks oldFeedBack = bda.feedback.SingleOrDefault(
                     f => f.memberId == newFeedBack.memberId &&
                          f.leaderId == newFeedBack.leaderId
                );
                if(! (oldFeedBack == null))
                {
                    oldFeedBack.feedback = newFeedBack.feedback;
                    bda.SaveChanges();
                }
            }
        }
    }
}