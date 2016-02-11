using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTheater.Business_Logic
{
    public class CustomerLogic
    {
        public static Customer getCustomerByPK(int cid){
            var context = new MovieTheaterEntities();
            return context.Customer.Where(s => s.Customer_ID == cid).First();
        }

        public static void insertCustomer(string name, string email, string mobileNo,
            string loginId, string password)
        {
            var context = new MovieTheaterEntities();
            Customer cu = new Customer();
            cu.Customer_Name = name;
            cu.Email = email;
            cu.MobileNo = mobileNo;
            cu.Login_ID = loginId;
            cu.Password = password;
            cu.Active_Indicator = true;
            cu.Create_Datetime = DateTime.Today;
            context.Customer.Add(cu);
            context.SaveChanges();
        }

        public static void updateCustomer(int cid, string name, string email,
            string mobileNo, string loginId, string password)
        {
            var context = new MovieTheaterEntities();
            Customer cu = context.Customer.Where(s => s.Customer_ID == cid).First();
            cu.Customer_Name = name;
            cu.Email = email;
            cu.MobileNo = mobileNo;
            cu.Login_ID = loginId;
            cu.Password = password;
            cu.Create_Datetime = DateTime.Today;
            context.SaveChanges();
        }

        public static int loginCustomer(string loginId, string password)
        {
            var context = new MovieTheaterEntities();
            Customer cu = context.Customer.Where(s => s.Login_ID == loginId && s.Password == password).FirstOrDefault();
            if (cu == null)
            {
                return 0;
            }
            else
            {
                if (cu.Login_ID== null || cu.Login_ID== "")
                {
                    return 0;
                }
            }
            return cu.Customer_ID;
        }
    }
}