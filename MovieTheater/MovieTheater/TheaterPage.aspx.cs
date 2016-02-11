using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class TheaterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DatagridviewRefresh();
            }
        }

        protected void DatagridviewRefresh()
        {
            try
            {
                gdvTheater.Columns[0].Visible = true;
                gdvTheater.DataSource = Business_Logic.TheaterLogic.getTheaterList();
                gdvTheater.DataBind();
                gdvTheater.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void hideAllPanel()
        {
            pnlAdd.Visible = false;
            pnlEdit.Visible = false;
        }

        protected void gdvTheater_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hideAllPanel();
            gdvTheater.Visible = true;

            if (e.CommandName == "EditComm")
            {
                try
                {
                    int ee = Convert.ToInt32(e.CommandArgument);
                    int tid = Convert.ToInt32(gdvTheater.Rows[ee].Cells[0].Text);
                    Theater t = Business_Logic.TheaterLogic.getTheaterByPK(tid);
                    hfEditId.Value = t.Theater_ID.ToString();
                    txtname.Text = t.Theater_Name;
                    txtAddress.Text = t.Theater_Address;
                    txtPhoneno.Text = t.Theater_Phone_No;
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + ex.Message + "');", true);
                }
                pnlEdit.Visible = true;
            }

            if (e.CommandName == "DeleteComm")
            {
                try
                {
                    int ee = Convert.ToInt32(e.CommandArgument);
                    int tid = Convert.ToInt32(gdvTheater.Rows[ee].Cells[0].Text);
                    Business_Logic.TheaterLogic.deleteTheater(tid);
                    DatagridviewRefresh();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Delete Theater Success');", true);
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + ex.Message + "');", true);
                }
            }


            if (e.CommandName == "NextComm")
            {
                try
                {
                    int ee = Convert.ToInt32(e.CommandArgument);
                    int tid = Convert.ToInt32(gdvTheater.Rows[ee].Cells[0].Text);
                    String name = gdvTheater.Rows[ee].Cells[1].Text;
                    Session["Var1"] = tid;
                    Session["name"] = name;
                    Response.Redirect("RoomPage.aspx");

                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + ex.Message + "');", true);
                }
            }
        }

        protected bool errorAddChecking()
        {
            Boolean ErrorBro = false;
            if (txtTheaterName.Text == "")
            {
                lbltname.Text = "this field should not be blank!";
                ErrorBro = true;
            }

            if (txtTheaterAddress.Text == "")
            {
                lbladdress.Text = "this field should not be blank!";
                ErrorBro = true;
            }

            if (txtPhNo.Text == "")
            {
                lblphno.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            return ErrorBro;
        }

        protected bool errorEditChecking()
        {
            Boolean ErrorBro = false;
            if (txtname.Text == "")
            {
                lbleditname.Text = "this field should not be blank!";
                ErrorBro = true;
            }

            if (txtAddress.Text == "")
            {
                lbleditaddress.Text = "this field should not be blank!";
                ErrorBro = true;
            }

            if (txtPhoneno.Text == "")
            {
                lbleditphno.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            return ErrorBro;
        }

        protected void emptyEditMsgError()
        {
            lbleditname.Text = "";
            lbleditaddress.Text = "";
            lbleditphno.Text = "";
        }

        protected void emptyAddMsgError()
        {
            lbltname.Text = "";
            lbladdress.Text = "";
            lblphno.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            emptyAddMsgError();
            Boolean error = false;
            error = errorAddChecking();

            if (error == false)
            {
                try
                {
                    Business_Logic.TheaterLogic.insertTheater(txtTheaterName.Text, txtTheaterAddress.Text, txtPhNo.Text);
                    DatagridviewRefresh();
                    hideAllPanel();

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Add New Theater Success');", true);
                }

                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + ex.Message + "');", true);
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            hideAllPanel();

            txtTheaterName.Text = "";
            txtTheaterAddress.Text = "";
            txtPhNo.Text = "";
            pnlAdd.Visible = true;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            hideAllPanel();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            emptyEditMsgError();
            Boolean error = false;
            error = errorEditChecking();

            if (error == false)
            {
                try
                {
                    Business_Logic.TheaterLogic.updateTheater(Convert.ToInt32(hfEditId.Value), txtname.Text, txtAddress.Text, txtPhoneno.Text);
                    DatagridviewRefresh();
                    hideAllPanel();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Update Theater Success');", true);
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + ex.Message + "');", true);
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            hideAllPanel();
        }
    }
}