using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class CustomerRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["uid"] != null)
                {
                    Response.Redirect("SeatSelection.aspx");
                }
            }
            if (Session["rmid"] == null)
            {
                Response.Redirect("MovieSchedule.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int t = Business_Logic.CustomerLogic.loginCustomer(TextBox1.Text, TextBox2.Text);
            if (t > 0)
            {
                Session["uid"] = t;
                Customer ct = Business_Logic.CustomerLogic.getCustomerByPK(t);
                Session["uname"] = ct.Customer_Name;
                Response.Redirect("SeatSelection.aspx");
            }
            else
            {
                lblErrLog.Text = "Username or password is wrong";
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            bool ErrorBro = false;

            if (tbxCustomerName.Text == "")
            {
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
                Response.Redirect("SeatSelection.aspx");
            }
        }
    }
}