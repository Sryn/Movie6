using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class StaffLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Text = "";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Business_Logic.UserLogic.StaffLogin(tbxUsername.Text, tbxPassword.Text) == 1)
            {
                Session["StaffID"] = tbxUsername.Text;
                Response.Redirect("RoomMoviePage.aspx");
            }
            else
            {
                lblError.Text = "Username or Password is wrong";
            }
        }
    }
}