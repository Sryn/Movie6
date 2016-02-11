using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class CRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool ErrorBro = false;

            if (tbxCustomerName.Text == "") {
                lbltname.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            if (tbxEmail.Text == "")
            {
                lbltemail.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            if (tbxMobileno.Text == "")
            {
                lbltmobileno.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            if (tbxLoginID.Text == "")
            {
                lbltloginid.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            if (tbxPassword.Text == "")
            {
                lbltpassword.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            if (ErrorBro == false)
            {
                Business_Logic.CustomerLogic.insertCustomer(tbxCustomerName.Text, tbxEmail.Text, tbxMobileno.Text, tbxLoginID.Text, tbxPassword.Text);
                int t = Business_Logic.CustomerLogic.loginCustomer(tbxLoginID.Text, tbxPassword.Text);
                Session["uid"] = t;
                Session["uname"] = tbxCustomerName.Text;
                Response.Redirect("MovieSchedule.aspx");
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("MovieSchedule.aspx");
        }
    }
}