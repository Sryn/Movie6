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

        public static bool deactivateRoomSeats(int rid, out String errorMsg)
        {
            bool boolResult = false;
            errorMsg = " No Error, Just Success!!!";
            int sid;

            try
            {
                List<Seat> roomSeats = getSeatListByRoom(rid);

                foreach (Seat aSeat in roomSeats)
                {
                    sid = aSeat.Seat_ID;
                    errorMsg = " Trying to 'delete' roomID="+rid+" seatID="+sid+" ";
                    deleteSeat(sid);
                }

                errorMsg = " Successfully deactivated all seats in theatreRoom with roomID=" + rid.ToString();
                boolResult = true;
            }
            catch (Exception ex)
            {
                // ERROR
                boolResult = false;
                errorMsg += ex.Message;
                System.Diagnostics.Debug.WriteLine("\n>> Error Exception Message = \"" + errorMsg + "\"");
            }

            return boolResult;
        }

        public static bool createRoomSeats(int rid, int rowCount, int seatColCount, out String errorMsg)
        {
            System.Diagnostics.Debug.WriteLine(">> createRoomSeats(rid=" + rid + ", rowCount=" + rowCount + ", seatColCount=" + seatColCount + ")");

            bool boolResult = false;
            errorMsg = " No Error, Just Success!!!";

            var context = new MovieTheaterEntities();

            // check there must be no other seats with rid in dB
            List<Seat> roomSeatList = getSeatListByRoom(rid);
            if (roomSeatList.Count == 0)
            {
                String seatName = "";
                int i, j;

                for (i = 1; i <= rowCount; i++) // rows
                {
                    for (j = 1; j <= seatColCount; j++) // columns
                    {
                        seatName = getSeatName(i, j);

                        try
                        {
                            errorMsg = "createRoomSeats insertSeat(rid=" + rid + ", seatName=" + seatName + ", row i=" + i + ", column j=" + j + ") ";
                            System.Diagnostics.Debug.Write(">> " + errorMsg);
                            insertSeat(rid, seatName, i, j);

                            boolResult = true;
                            System.Diagnostics.Debug.WriteLine(" Success");
                        }
                        catch (Exception ex)
                        {
                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + ex.Message + "');", true);

                            // ERROR
                            boolResult = false;
                            errorMsg += ex.Message;
                            System.Diagnostics.Debug.WriteLine("\n>> Error Exception Message = \""+errorMsg+"\"");
                        }

                        if (!boolResult)
                        {
                            break;
                        }
                    }
                }

                errorMsg = " Successfully created " + (rowCount * seatColCount).ToString() + " seats for theatreRoom with roomID=" + rid.ToString();
            }
            else
            {
                boolResult = false;
                errorMsg = " ErrorNo: 01 - \"theatreRoom with roomID=" + rid + " already has " + roomSeatList.Count + " seats inside.\"";
            }

            return boolResult;
        }

        private static String getSeatName(int seatRow, int seatColumn)
        {
            System.Diagnostics.Debug.WriteLine(">> getSeatName( seatRow=" + seatRow + ", seatColumn=" + seatColumn + ")");

            //throw new NotImplementedException();
            const String Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            return (Alphabet[seatRow-1] + seatColumn.ToString());
        }
    }
}