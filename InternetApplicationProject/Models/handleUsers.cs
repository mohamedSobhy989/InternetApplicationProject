using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InternetApplicationProject.Models;

namespace InternetApplicationProject.Models
{
    public class handleUsers
    {
        public ApplicationDbContext bda = new ApplicationDbContext();

        public void addUser(Users usr)
        {
            bda.user.Add(usr);
            bda.SaveChanges();
        }

        //------------------------------------------------------------------

        public void deleteUser(int id)
        {
            Users s = bda.user.SingleOrDefault(c => c.Id == id);
            if(s != null) {
                bda.user.Remove(s);
                bda.SaveChanges();
            }
        }

        //------------------------------------------------------------------

        public void updateUser(int id,Users userNew) {
            Users userOld = bda.user.SingleOrDefault(c => c.Id == id);
            if (userOld != null)
            {
                userOld.Email = userNew.Email;
                userOld.FirstName = userNew.FirstName;
                userOld.LastName = userNew.LastName;
                userOld.Phone = userNew.Phone;
                userOld.Photo = userNew.Photo;
                userOld.role = userNew.role;
                bda.SaveChanges();
            }
        } 

        //------------------------------------------------------------------

        public Users getUser(int id) {
            Users s = bda.user.SingleOrDefault(c => c.Id == id);
            
            if (s != null)
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
                return s;
            }
            return null;

        }

        //------------------------------------------------------------------

        public IEnumerable<Users> getAllUsers() {
            return bda.user.ToList();
        }

        //------------------------------------------------------------------

        public IEnumerable<int> getAvailableCustomersId()
        {
            List<int> ids = new List<int>();
            foreach(var c in bda.user.ToList().Where(c => c.role == 2))
            {
                ids.Add(c.Id);
            }
            return ids;
        }

        //------------------------------------------------------------------

        public bool isUser(int id)
        {
            if(bda.user.SingleOrDefault(c => c.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        //------------------------------------------------------------------

        public string getUserName(int id)
        {
            Users user = bda.user.SingleOrDefault(c => c.Id == id);
            return user.FirstName != null && user.LastName != null ? user.FirstName + " " + user.LastName : "";
        }

        //-----------------------------------------------------------------

        public bool isDirector(int id)
        {
            if(isUser(id))
            {
                return bda.user.SingleOrDefault(c => c.Id == id && c.role == 3) == null ? false : true; 
            }
            return false;
        }

        //-----------------------------------------------------------------

        public IEnumerable<Users> getMembers()
        {
            return bda.user.ToList().Where(c => c.role == 5);
        }

        //-----------------------------------------------------------------

        public bool isWithRole(int id , int role)
        {
            //return true when user is found and with the role given otherwise false
            if (bda.user.SingleOrDefault(c => c.Id == id) != null)
            {
                Users user = getUser(id);
                if (user.role == role) return true;
            }
            return false;
        }

        //-----------------------------------------------------------------

        public void checkOrNormalize()
        {
            foreach(var item1 in bda.R_ForTeam.ToList()) {
                if(! isWithRole(item1.memberID , 5)) {
                    bda.R_ForTeam.Remove(item1);
                    bda.SaveChanges();
                }
            }

            foreach (var item2 in bda.TL_Project.ToList()) {
                if ((! isWithRole(item2.teamleaderID, 4)) || (!isWithRole(item2.directorID, 3))) { //leader-director
                    bda.TL_Project.Remove(item2);
                    bda.SaveChanges();
                }
                if(! isWithRole(item2.memberOne, 5)) {
                    item2.memberOne = 0;
                    bda.SaveChanges();
                }
                if (!isWithRole(item2.memberTwo, 5))
                {
                    item2.memberTwo = 0;
                    bda.SaveChanges();
                }
                if (!isWithRole(item2.memberThree, 5))
                {
                    item2.memberThree = 0;
                    bda.SaveChanges();
                }
            }

            foreach (var item3 in bda.project.ToList())
            {
                if (!isWithRole(item3.customerid, 2)) { 
                    bda.project.Remove(item3);
                    bda.SaveChanges();
                }
            }

            foreach (var item4 in bda.feedback.ToList()) {
                if ((!isWithRole(item4.memberId, 5)) || (!isWithRole(item4.leaderId, 4))) {
                    bda.feedback.Remove(item4);
                    bda.SaveChanges();
                }
            }

        }


    }
}