using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int t = Business_Logic.CustomerLogic.loginCustomer(tbxLoginID.Text, tbxPassword.Text);
            if (t > 0)
            {
                Session["uid"] = t;
                Customer ct = Business_Logic.CustomerLogic.getCustomerByPK(t);
                Session["uname"] = ct.Customer_Name;
                Response.Redirect("MovieSchedule.aspx");
            }
            else
            {
                lblErrLog.Text = "Username or password is wrong";
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("MovieSchedule.aspx");
        }
    }
}