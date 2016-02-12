using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class Confirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Booking book = new Booking();
            //Business_Logic.BookingLogic.getBookingByPK();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lbl1.Visible = true;
            Button1.Visible = false;
        }
    }
}