using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTheater.Business_Logic
{
    public class RoomMovieLogic
    {
        public static List<RoomMovie> getRoomMovieList()
        {
            var context = new MovieTheaterEntities();
            return context.RoomMovie.Where(s => s.Active_Indicator == true).ToList();
        }

        public static List<RoomMovie> getRoomMovieByDateandRoom(int roomID, DateTime d)
        {
            var context = new MovieTheaterEntities();
            return context.RoomMovie.Where(s => s.Room_ID == roomID && s.Date == d && s.Active_Indicator == true).ToList();
        }

        public static List<Theater> getThByMovie(int mid)
        {
            var context = new MovieTheaterEntities();
            var tList = from rm in context.RoomMovie
                        where rm.Movie_ID == mid && rm.Publish == true
                        group rm by rm.Room.Theater_ID into teates
                        select teates;
            List<Theater> tt = new List<Theater>();
            foreach (var tti in tList)
            {
                tt.Add(context.Theater.Where(s => s.Theater_ID == tti.Key).First());
            }
            return tt;
        }

        public static List<DateTime> getRMDateByTheaterMovie(int tid, int mid)
        {
            var context = new MovieTheaterEntities();
            //return context.RoomMovie.Where(s => s.Room.Theater_ID == tid && s.Movie_ID == mid).ToList();
            var dateList = from rm in context.RoomMovie
                           where rm.Room.Theater_ID == tid && rm.Movie_ID == mid && rm.Publish == true
                           group rm by rm.Date into dates
                           select dates;
            List<DateTime> dt = new List<DateTime>();
            foreach(var datei in dateList){
                dt.Add(datei.Key);
            }
            return dt;
        }

        public static bool confirmRoomMovieByDateAndRoom(int roomID, DateTime d, TimeSpan starttime, TimeSpan endtime)
        {
            var context = new MovieTheaterEntities();
            var a = context.RoomMovie.Where(s => s.Room_ID == roomID && s.Date == d && s.Active_Indicator == true && ((s.StartTime >= starttime && s.StartTime < endtime) || (endtime >= s.EndTime && starttime < s.EndTime))).ToList();
            if (a.Count == 0)
                return true;
            return false;
        }

        public static List<TimeSpan> getRMTimeByTheaterMovieDate(int tid, int mid, DateTime dt)
        {
            var context = new MovieTheaterEntities();
            var mrList = context.RoomMovie.Where(s => s.Room.Theater_ID == tid && s.Movie_ID == mid && s.Date == dt && s.Publish == true).OrderBy(s=>s.StartTime).ToList();
            List<TimeSpan> tsList = new List<TimeSpan>();
            foreach (var vr in mrList)
            {
                tsList.Add(vr.StartTime);
            }
            return tsList;
        }

        public static List<SeatMovie> getSeatMovieListByRoomMovie(int rmid)
        {
            var context = new MovieTheaterEntities();
            return context.SeatMovie.Where(s => s.RoomMovie_ID == rmid && s.Active_Indicator == true).ToList();
        }

        public static RoomMovie getRoomMovieByPK(int rmid)
        {
            var context = new MovieTheaterEntities();
            return context.RoomMovie.Where(s => s.RoomMovie_ID == rmid).First();
        }

        public static SeatMovie getSeatMovieByPK(int smid)
        {
            var context = new MovieTheaterEntities();
            return context.SeatMovie.Where(s => s.SeatMovie_ID == smid).First();
        }

        public static void insertRoomMovie(int rid, DateTime dt, TimeSpan startTime
            ,TimeSpan endTime, int mid, double price)
        {
            var context = new MovieTheaterEntities();
            RoomMovie rm = new RoomMovie();
            rm.Room_ID = rid;
            rm.Date = dt;
            rm.StartTime = startTime;
            rm.EndTime = endTime;
            rm.Movie_ID = mid;
            rm.Price = price;
            rm.Publish = false;
            rm.Active_Indicator = true;
            rm.Update_Datetime = DateTime.Today;
            context.RoomMovie.Add(rm);
            context.SaveChanges();
        }

        public static int updateRoomMovie(int rmid, DateTime dt
            , TimeSpan startTime, TimeSpan endTime)
        {
            var context = new MovieTheaterEntities();
            RoomMovie rm = context.RoomMovie.Where(s => s.RoomMovie_ID == rmid).First();
            if (rm.Publish == false)
            {
                //rm.Room_ID = rid;
                rm.Date = dt;
                rm.StartTime = startTime;
                rm.EndTime = endTime;
                //rm.Movie_ID = mid;
                //rm.Price = price;
                rm.Update_Datetime = DateTime.Today;
                context.SaveChanges();
                return 1;
            }
            return 0;
        }

        public static int publishRoomMovie(int rmid)
        {
            var context = new MovieTheaterEntities();
            RoomMovie rm = context.RoomMovie.Where(s => s.RoomMovie_ID == rmid).First();
            if (rm.Publish == false)
            {
                rm.Publish = true;
                Room ro = rm.Room;
                List<Seat> listSt = context.Seat.Where(s => s.Room_ID == ro.Room_ID && s.Active_Indicator == true).ToList();
                foreach(Seat st in listSt){
                    SeatMovie sm = new SeatMovie();
                    sm.RoomMovie_ID = rm.RoomMovie_ID;
                    sm.Seat_ID = st.Seat_ID;
                    sm.Occupied = false;
                    sm.Active_Indicator = true;
                    sm.Update_Datetime = DateTime.Today;
                    context.SeatMovie.Add(sm);
                }
                context.SaveChanges();
                return 1;
            }
            return 0;
        }

        public static int deleteRoomMovie(int rmid)
        {
            var context = new MovieTheaterEntities();
            RoomMovie rm = context.RoomMovie.Where(s => s.RoomMovie_ID == rmid).First();
            if (rm.Date.CompareTo(DateTime.Today) < 0)
            {
                rm.Active_Indicator = false;
                rm.Update_Datetime = DateTime.Today;
                context.SaveChanges();
                return 1;
            }
            else
            {
                if (rm.Publish == false)
                {
                    rm.Active_Indicator = false;
                    rm.Update_Datetime = DateTime.Today;
                    context.SaveChanges();
                    return 1;
                }
            }
            return 0;
        }
    }
}