using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTheater.Business_Logic
{
    public class RoomLogic
    {
        public static List<Room> getRoomListByTheater(int tid)
        {
            var context = new MovieTheaterEntities();
            return context.Room.Where(s => s.Theater_ID == tid && s.Active_Indicator == true).ToList();
        }

        public static List<Room> getRoomListByTheaterRoomType(int tid, int rtid)
        {
            var context = new MovieTheaterEntities();
            return context.Room.Where(s => s.Theater_ID == tid && s.RoomType_ID == rtid && s.Active_Indicator == true).ToList();
        }

        public static Room getRoomByPK(int rid)
        {
            var context = new MovieTheaterEntities();
            return context.Room.Where(s => s.Room_ID == rid).First();
        }

        public static void insertRoom(string name, int tid, int rtid, string pattern)
        {
            var context = new MovieTheaterEntities();
            Room rm = new Room();
            rm.Room_Name = name;
            rm.Theater_ID = tid;
            rm.RoomType_ID = rtid;
            rm.Seat_Pattern = pattern;
            rm.Active_Indicator = true;
            rm.Update_Datetime = DateTime.Today;
            context.Room.Add(rm);
            context.SaveChanges();
        }

        public static void updateRoom(int rid, string name, int rtid, string pattern)
        {
            var context = new MovieTheaterEntities();
            Room rm = context.Room.Where(s => s.Room_ID == rid).First();
            rm.Room_Name = name;
            rm.RoomType_ID = rtid;
            rm.Seat_Pattern = pattern;
            rm.Update_Datetime = DateTime.Today;
            context.SaveChanges();
        }

        public static void deleteRoom(int rid)
        {
            var context = new MovieTheaterEntities();
            Room rm = context.Room.Where(s => s.Room_ID == rid).First();
            rm.Active_Indicator = false;
            rm.Update_Datetime = DateTime.Today;
            context.SaveChanges();
        }
    }
}