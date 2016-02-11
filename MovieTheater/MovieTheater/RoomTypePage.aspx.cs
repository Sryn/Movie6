using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class RoomTypePageaspx : System.Web.UI.Page
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
                gdvRoomtpe.Columns[0].Visible = true;
                gdvRoomtpe.DataSource = Business_Logic.RoomTypeLogic.getRoomTypeList();
                gdvRoomtpe.DataBind();
                gdvRoomtpe.Columns[0].Visible = false;
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

        protected void gdvRoomtpe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hideAllPanel();
            int i = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditComm")
            {
                try
                {
                    int ee = Convert.ToInt32(e.CommandArgument);
                    int rtid = Convert.ToInt32(gdvRoomtpe.Rows[ee].Cells[0].Text);
                    RoomType rt = Business_Logic.RoomTypeLogic.getRoomTypeByPK(rtid);

                    hfEditId.Value = rt.RoomType_ID.ToString();
                    txtRTName.Text = rt.RoomType_Name;
                    txtroomtypeprice.Text = rt.Price.ToString();
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
                    int rtid = Convert.ToInt32(gdvRoomtpe.Rows[ee].Cells[0].Text);
                    Business_Logic.RoomTypeLogic.deleteTheater(rtid);
                    DatagridviewRefresh();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Delete RoomType Success');", true);
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
            if (txtRoomTypeName.Text == "")
            {
                lblname.Text = "this field should not be blank!";
                ErrorBro = true;
            }

            if (txtprice.Text == "")
            {
                lblprice.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            return ErrorBro;
        }

        protected bool errorEditChecking()
        {
            Boolean ErrorBro = false;
            if (txtRTName.Text == "")
            {
                lbleditname.Text = "this field should not be blank!";
                ErrorBro = true;
            }

            if (txtroomtypeprice.Text == "")
            {
                lbleditprice.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            return ErrorBro;
        }

        protected void emptyEditMsgError()
        {
            lbleditname.Text = "";
            lbleditprice.Text = "";
        }

        protected void emptyAddMsgError()
        {
            lblname.Text = "";
            lblprice.Text = "";
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
                    Business_Logic.RoomTypeLogic.insertRoomType(txtRoomTypeName.Text, Convert.ToInt32(txtprice.Text));
                    DatagridviewRefresh();
                    hideAllPanel();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Add New Room Type Success');", true);
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

            txtRoomTypeName.Text = "";
            txtprice.Text = "";
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
                    Business_Logic.RoomTypeLogic.updateRoomType(Convert.ToInt32(hfEditId.Value), txtRTName.Text, Convert.ToInt32(txtroomtypeprice.Text));
                    DatagridviewRefresh();
                    hideAllPanel();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Update Room Type Success');", true);
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