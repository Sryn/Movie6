using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTheater.Business_Logic
{
    public class TheaterLogic
    {
        public static List<Theater> getTheaterList()
        {
            var context = new MovieTheaterEntities();
            return context.Theater.Where(s => s.Active_Indicator == true).ToList<Theater>();
        }

        public static Theater getTheaterByPK(int tid)
        {
            var context = new MovieTheaterEntities();
            return context.Theater.Where(s => s.Theater_ID == tid).First();
        }

        public static void insertTheater(string name, string address, string phone)
        {
            var context = new MovieTheaterEntities();
            Theater tr = new Theater();
            tr.Theater_Name = name;
            tr.Theater_Address = address;
            tr.Theater_Phone_No = phone;
            tr.Active_Indicator = true;
            tr.Update_Datetime = DateTime.Today;
            context.Theater.Add(tr);
            context.SaveChanges();
        }

        public static void updateTheater(int tid, string name, string address, string phone)
        {
            var context = new MovieTheaterEntities();
            Theater tr = context.Theater.Where(s => s.Theater_ID == tid).First();
            tr.Theater_Name = name;
            tr.Theater_Address = address;
            tr.Theater_Phone_No = phone;
            tr.Update_Datetime = DateTime.Today;
            context.SaveChanges();
        }

        public static void deleteTheater(int tid)
        {
            var context = new MovieTheaterEntities();
            Theater tr = context.Theater.Where(s => s.Theater_ID == tid).First();
            tr.Active_Indicator = false;
            tr.Update_Datetime = DateTime.Today;
            context.SaveChanges();
        }
    }
}