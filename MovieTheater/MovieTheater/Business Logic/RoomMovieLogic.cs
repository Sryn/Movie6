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

        public static int getRoomMovieId(DateTime d, TimeSpan tmsp)
        {
            var context = new MovieTheaterEntities();
            return context.RoomMovie.Where(s => s.Date == d && s.StartTime == tmsp).Select(v => v.RoomMovie_ID).First();
        }

        public static List<RoomMovie> getRoomMovieByDateandRoom(int roomID, DateTime d)
        {
            var context = new MovieTheaterEntities();
            return context.RoomMovie.Where(s => s.Room_ID == roomID && s.Date == d && s.Active_Indicator == true).ToList();
        }

        public static List<RoomMovie> getTodayRoomMovie()
        {
            var context = new MovieTheaterEntities();
            return context.RoomMovie.Where(s => s.Active_Indicator == true && s.Date == DateTime.Today && s.Publish == true).ToList();
        }

        public static List<RoomMovie> getTodayRoomMovieByTheater(int theaterID)
        {
            var context = new MovieTheaterEntities();
            return context.RoomMovie.Where(s => s.Room.Theater_ID == theaterID && s.Active_Indicator == true && s.Date == DateTime.Today && s.Publish == true).ToList();
        }

        public static List<RoomMovie> getTodayRoomMovieByMovie(int movieID)
        {
            var context = new MovieTheaterEntities();
            return context.RoomMovie.Where(s => s.Movie_ID == movieID && s.Active_Indicator == true && s.Date == DateTime.Today && s.Publish == true).ToList();
        }

        public static List<Movie> getTodayMovie()
        {
            var context = new MovieTheaterEntities();
            var mList = context.RoomMovie.Where(rm => rm.Date == DateTime.Today && rm.Publish == true).GroupBy(rm => rm.Movie_ID);
            List<Movie> lm = new List<Movie>();
            foreach (var mm in mList)
            {
                lm.Add(context.Movie.Where(s=>s.Movie_ID == mm.Key).First());
            }
            return lm;
        }

        public static List<Theater> getTodayTheater()
        {
            var context = new MovieTheaterEntities();
            var tList = context.RoomMovie.Where(rm => rm.Date == DateTime.Today && rm.Publish == true).GroupBy(rm => rm.Room.Theater_ID);
            List<Theater> lt = new List<Theater>();
            foreach (var tt in tList)
            {
                lt.Add(context.Theater.Where(s => s.Theater_ID== tt.Key).First());
            }
            return lt;
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

        public static bool confirmEdit(int rmID, int roomID, DateTime d, TimeSpan starttime, TimeSpan endtime)
        {
            var context = new MovieTheaterEntities();
            var a = context.RoomMovie.Where(s => s.RoomMovie_ID != rmID && s.Room_ID == roomID && s.Date == d && s.Active_Indicator == true && ((s.StartTime >= starttime && s.StartTime < endtime) || (endtime >= s.EndTime && starttime < s.EndTime))).ToList();
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

        public static List<SeatMovie> getSeatMovieListByJustRoomMovie(int rmid)
        {
            var context = new MovieTheaterEntities();
            return context.SeatMovie.Where(s => s.RoomMovie_ID == rmid).ToList();
        }

        public static List<SeatMovie> getSeatMovieListByRoomMovieAndOccupiedFalse(int rmid)
        {
            var context = new MovieTheaterEntities();
            return context.SeatMovie.Where(s => s.RoomMovie_ID == rmid && s.Occupied == false).ToList();
        }

        public static RoomMovie getRoomMovieByPK(int rmid)
        {
            var context = new MovieTheaterEntities();
            return context.RoomMovie.Where(s => s.RoomMovie_ID == rmid).First();
        }

        public static SeatMovie getSeatMovieByPK(int smid)
        {
            System.Diagnostics.Debug.WriteLine(">>> getSeatMovieByPK(smid="+smid+")");

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

        // returns the newly created SeatMovie seatMovieID or 0 if Error
        internal static int insertNewSeatMovie(SeatMovie aSeatMovie)
        {
            //throw new NotImplementedException();

            if (checkNoDuplicate(aSeatMovie)) {
                SeatMovie newSeatMovie;

                var context = new MovieTheaterEntities();

                newSeatMovie = context.SeatMovie.Add(aSeatMovie);
                context.SaveChanges();

                System.Diagnostics.Debug.WriteLine(">>> insertNewSeatMovie newSeatMovie.SeatMovie_ID=" + newSeatMovie.SeatMovie_ID);

                if (newSeatMovie != null)
                    return newSeatMovie.SeatMovie_ID;
                else
                    return 0;
            }
            else
            {
                return 0;
            }
        }

        private static bool checkNoDuplicate(SeatMovie aSeatMovie)
        {
            //throw new NotImplementedException();

            List<SeatMovie> seatMovieList = getSeatMovieListByJustRoomMovie(aSeatMovie.RoomMovie_ID);

            if (seatMovieList.Count > 0)
            {
                foreach (SeatMovie aSeatMovie2 in seatMovieList)
                {
                    if (aSeatMovie.Seat_ID == aSeatMovie2.Seat_ID)
                    {
                        // duplicate found
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return true;
            }
        }

        internal static bool OnHoldSeat(int roomMovieID, int aSeatMovieID)
        {
            //throw new NotImplementedException();

            if (countHowManyInstances(roomMovieID, aSeatMovieID) == 1)
            {
                // no error
                var context = new MovieTheaterEntities();

                SeatMovie aSeatMovie = context.SeatMovie.Where(s => s.SeatMovie_ID == aSeatMovieID).First();

                if (aSeatMovie.Occupied == false)
                {
                    aSeatMovie.Occupied = true;
                    aSeatMovie.Active_Indicator = false;

                    context.SaveChanges();

                    return true;
                }

                //RoomMovie rm = context.RoomMovie.Where(s => s.RoomMovie_ID == rmid).First();
                //if (rm.Publish == false)
                //{
                //    //rm.Room_ID = rid;
                //    rm.Date = dt;
                //    rm.StartTime = startTime;
                //    rm.EndTime = endTime;
                //    //rm.Movie_ID = mid;
                //    //rm.Price = price;
                //    rm.Update_Datetime = DateTime.Today;
                //    context.SaveChanges();
                //}

            }

            return false;
        }

        private static int countHowManyInstances(int roomMovieID, int aSeatMovieID)
        {
            //throw new NotImplementedException();
            List<SeatMovie> seatMovieList = null;
            int count = 0;

            try {
                seatMovieList = getSeatMovieListByJustRoomMovie(roomMovieID);
            } catch(Exception ex) {
                System.Diagnostics.Debug.WriteLine(">> ERROR: countHowManyInstances ex.Message=" + ex.Message);
            }

            if (seatMovieList != null && seatMovieList.Count > 0)
            {
                foreach (SeatMovie aSeatMovie in seatMovieList)
                {
                    if (aSeatMovie.SeatMovie_ID == aSeatMovieID)
                        count++;
                }
            }
            else
            {
                return seatMovieList.Count;
            }

            return count;
        }

        internal static void FreeSeat(int aSeatMovieID)
        {
            //throw new NotImplementedException();
            var context = new MovieTheaterEntities();

            SeatMovie aSeatMovie = context.SeatMovie.Where(s => s.SeatMovie_ID == aSeatMovieID).First();

            aSeatMovie.Occupied = false;
            aSeatMovie.Active_Indicator = true;

            context.SaveChanges();

        }

        internal static double getTicketPrice(int roomMovieID)
        {
            //throw new NotImplementedException();
            var context = new MovieTheaterEntities();

            return context.RoomMovie.Where(r => r.RoomMovie_ID == roomMovieID).First().Price;

        }
    }
}