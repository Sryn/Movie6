using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTheater.Business_Logic
{
    public class UserLogic
    {
        public static int StaffLogin(string userId, string pass)
        {
            var context = new MovieTheaterEntities();
            User u = context.User.Where(s => s.User_ID == userId && s.Password == pass).FirstOrDefault();
            if (u == null)
            {
                return 0;
            }
            else
            {
                if (u.User_ID == null || u.User_ID == "")
                {
                    return 0;
                }
            }
            return 1;
        }
    }
}