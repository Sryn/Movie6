using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class SeatSelection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //MovieName.Text = Session["movName"].ToString();
            //string mnamstr = Session["movName"].ToString();
            //TheatreName.Text = Session["theatre"].ToString();
            //string thtstr = Session["theatre"].ToString(); 
            //Date.Text = Session["date"].ToString();
            
            //Time.Text = Session["time"].ToString();
            
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int s = 1;
            List<int> seats = new List<int>();
            seats.Add(s);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<int> seats = new List<int>();
            seats.Add(Convert.ToInt32( DropDownList1.SelectedItem.Text));
            DateTime datstr = Convert.ToDateTime(Session["date"].ToString());
            TimeSpan timstr =  TimeSpan.Parse(Session["time"].ToString());
            int id = Business_Logic.RoomMovieLogic.getRoomMovieId(datstr,timstr);
            int cid = Convert.ToInt32(Session["uid"].ToString());
            
            Business_Logic.BookingLogic.insertBooking(cid,id,seats);

            Response.Redirect("Confirm.aspx");
           
        }

      

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}