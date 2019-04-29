using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InternetApplicationProject.Models;

namespace InternetApplicationProject.Models
{
    public class handleProjects
    {
        ApplicationDbContext bda = new ApplicationDbContext();

        //-------------------------------------------------------------

        public IEnumerable<Projects> getAllProjects()
        {
            return bda.project.ToList();
        }

        //-------------------------------------------------------------

        public void addProject(Projects newProject)
        {
            bda.project.Add(newProject);
            bda.SaveChanges();
        }

        //-------------------------------------------------------------

        public void deleteProject(int id)
        {
            Projects p = bda.project.SingleOrDefault(c => c.Id == id);
            if (p != null)
            {
                bda.project.Remove(p);
                bda.SaveChanges();
            }
        }

        //-------------------------------------------------------------

        public Projects getProject(int id)
        {
            Projects p = bda.project.SingleOrDefault(c => c.Id == id);
            if (p != null)
            {
                /*
                List<string> data = new List<string>();
                data.Add(user.FirstName);
                data.Add(user.LastName);
                data.Add(user.Email);
                data.Add(user.Phone.ToString());
                data.Add(user.role.ToString());
                data.Add(user.Photo.ToString());
                return data; */
                return p;
            }
            return null;
        }
       
        //--------------------------------------------------------------

        public void updateProject(int id , Projects projectNew)
        {
            Projects projectOld = bda.project.SingleOrDefault(c => c.Id == id);
            if (projectOld != null)
            {
                projectOld.description = projectNew.description;
                projectOld.Price = projectNew.Price;
                projectOld.projectState = projectNew.projectState;
                projectOld.projectDelevered = projectNew.projectDelevered;
                projectOld.customerid = projectNew.customerid;
                projectOld.project_Name = projectNew.project_Name;

                bda.SaveChanges();
            }
        }

        //---------------------------------------------------------------

        public string getProjectName(int id)
        {
            Projects project = bda.project.SingleOrDefault(c => c.Id == id);
            return project.project_Name != null ? project.project_Name : "";
        }

        //---------------------------------------------------------------

        public bool isProject(int id)
        {
            return bda.project.ToList().SingleOrDefault(item => item.Id == id) == null ? false : true;
        }

        //---------------------------------------------------------------

        public void checkOrNormalize()
        {
            foreach(var item1 in bda.R_ForTeam.ToList()) {
                if(! isProject(item1.projectID)) {
                    bda.R_ForTeam.Remove(item1);
                    bda.SaveChanges();
                }
            }

            foreach (var item2 in bda.TL_Project.ToList()) {
                if(! isProject(item2.projectID)) {
                    bda.TL_Project.Remove(item2);
                    bda.SaveChanges();
                }
            }
        }
    }
}