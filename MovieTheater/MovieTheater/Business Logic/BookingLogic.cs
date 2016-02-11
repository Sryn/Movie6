using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTheater.Business_Logic
{
    public class BookingLogic
    {
        public static Booking getBookingByPK(int bid)
        {
            var context = new MovieTheaterEntities();
            return context.Booking.Where(s => s.Booking_ID == bid).First();
        }

        public static List<BookingDetail> getBookingDetailByBooking(int bid)
        {
            var context = new MovieTheaterEntities();
            return context.BookingDetail.Where(s => s.Booking_ID == bid).ToList();
        }

        public static void insertBooking(int cid, int rmid, List<int>Listsid)
        {
            var context = new MovieTheaterEntities();
            Booking bk = new Booking();
            bk.Customer_ID = cid;
            bk.RoomMovie_ID = rmid;
            bk.Amount = Listsid.Count * bk.RoomMovie.Price;
            
            foreach (int sid in Listsid)
            {
                BookingDetail bd = new BookingDetail();
                bd.Seat_ID = sid;
                bk.BookingDetail.Add(bd);
            }
            
            context.Booking.Add(bk);
            context.SaveChanges();
        }
    }
}