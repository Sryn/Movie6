using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class Staff : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["StaffID"] == null)
            //    Response.Redirect("StaffLogin.aspx");
        }

        protected void btnTheater_Click(object sender, EventArgs e)
        {
            Response.Redirect("TheaterPage.aspx");
        }

        protected void btnMovie_Click(object sender, EventArgs e)
        {
            Response.Redirect("MoviePage.aspx");
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            Response.Redirect("RoomMoviePage.aspx");
        }

        protected void btnRoomType_Click(object sender, EventArgs e)
        {
            Response.Redirect("RoomTypePage.aspx");
        }
    }
}