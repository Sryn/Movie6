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

        internal static bool createRoomSeats(int theatreRoomID, int rowCount, int seatColCount, out string errorMsg)
        {
            throw new NotImplementedException();
        }

        internal static bool deactivateRoomSeats(int theatreRoomID, out string errorMsg)
        {
            throw new NotImplementedException();
        }

        // will return the LAST Active_Indicator=true seat in the matched returned List<seat>, else return the FIRST in the list
        internal static Seat getSeatByRoomID_row_col(int roomID, int rowNum, int colNum)
        {
            System.Diagnostics.Debug.WriteLine(">>> SeatLogic getSeatByRoomID_row_col( roomID=" + roomID + " rowNum=" + rowNum + " colNum=" + colNum + ")");

            Seat aSeat = null;
            List<Seat> seatListMain;
            List<Seat> seatListInner = new List<Seat>();

            try
            {
                seatListMain = getSeatListByRoom(roomID);

                foreach (Seat aSeat2 in seatListMain)
                {
                    if (aSeat2.Rows == rowNum && aSeat2.Columns == colNum)
                    {
                        seatListInner.Add(aSeat2);
                    }
                }

                if (seatListInner.Count > 0)
                {
                    aSeat = seatListInner.ElementAt(0);

                    foreach (Seat aSeat3 in seatListInner)
                    {
                        if (aSeat3.Active_Indicator == true)
                        {
                            aSeat = aSeat3;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(">>> ERROR: SeatLogic getSeatByRoomID_row_col ex.Message=" + ex.Message);
            }

            return aSeat;
        }
    }
}