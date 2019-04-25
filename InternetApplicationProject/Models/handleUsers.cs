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

    }
}