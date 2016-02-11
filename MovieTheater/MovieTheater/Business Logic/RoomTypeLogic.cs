using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTheater.Business_Logic
{
    public class RoomTypeLogic
    {
        public static List<RoomType> getRoomTypeList()
        {
            var context = new MovieTheaterEntities();
            return context.RoomType.Where(s => s.Active_Indicator == true).ToList();
        }

        public static RoomType getRoomTypeByPK(int rtid)
        {
            var context = new MovieTheaterEntities();
            return context.RoomType.Where(s => s.RoomType_ID == rtid).First();
        }

        public static void insertRoomType(string name, double price)
        {
            var context = new MovieTheaterEntities();
            RoomType rt = new RoomType();
            rt.RoomType_Name = name;
            rt.Price = price;
            rt.Active_Indicator = true;
            rt.Update_Datetime = DateTime.Today;
            context.RoomType.Add(rt);
            context.SaveChanges();
        }

        public static void updateRoomType(int rtid, string name, double price)
        {
            var context = new MovieTheaterEntities();
            RoomType rt = context.RoomType.Where(s => s.RoomType_ID == rtid).First();
            rt.RoomType_Name = name;
            rt.Price = price;
            rt.Update_Datetime = DateTime.Today;
            context.SaveChanges();
        }

        public static void deleteTheater(int rtid)
        {
            var context = new MovieTheaterEntities();
            RoomType rt = context.RoomType.Where(s => s.RoomType_ID == rtid).First();
            rt.Active_Indicator = false;
            rt.Update_Datetime = DateTime.Today;
            context.SaveChanges();
        }
    }
}