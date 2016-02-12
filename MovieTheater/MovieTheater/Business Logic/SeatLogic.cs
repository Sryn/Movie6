using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTheater.Business_Logic
{
    public class SeatLogic
    {
        public static List<Seat> getSeatListByRoom(int rid)
        {
            var context = new MovieTheaterEntities();
            return context.Seat.Where(s => s.Room_ID == rid && s.Active_Indicator == true).ToList();
        }

        public static Seat getSeatByPK(int sid)
        {
            var context = new MovieTheaterEntities();
            return context.Seat.Where(s => s.Seat_ID == sid).First();
        }

        public static void insertSeat(int rid, string name, int rows, int columns)
        {
            var context = new MovieTheaterEntities();
            Seat st = new Seat();
            st.Seat_Name = name;
            st.Room_ID = rid;
            st.Rows = rows;
            st.Columns = columns;
            st.Active_Indicator = true;
            st.Update_Datetime = DateTime.Today;
            context.Seat.Add(st);
            context.SaveChanges();
        }

        public static void updateSeat(int sid, string name, int rows, int columns)
        {
            var context = new MovieTheaterEntities();
            Seat st = context.Seat.Where(s => s.Seat_ID == sid).First();
            st.Seat_Name = name;
            st.Rows = rows;
            st.Columns = columns;
            st.Update_Datetime = DateTime.Today;
            context.SaveChanges();
        }

        public static void deleteSeat(int sid)
        {
            var context = new MovieTheaterEntities();
            Seat st = context.Seat.Where(s => s.Seat_ID == sid).First();
            st.Active_Indicator = false;
            st.Update_Datetime = DateTime.Today;
            context.SaveChanges();
        }
    }
}