using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Validation;
using System.Data;

namespace MovieTheater
{
    public partial class RoomPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DatagridviewRefresh();
            }
        }

        protected void clearErrorMessage()
        {
            lblname.Text = "";
        }

        protected void hideAllPanel()
        {
            pnlAdd.Visible = false;
            pnlEdit.Visible = false;
        }

        protected void DatagridviewRefresh()
        {
            try
            {
                gdvRoom.Columns[0].Visible = true;
                int param = Convert.ToInt32(Session["Var1"]);
                String name = Session["name"].ToString();
                lblTheaterNameTitle.Text = name;
                gdvRoom.DataSource = Business_Logic.RoomLogic.getRoomListByTheater(param);
                gdvRoom.DataBind();
                gdvRoom.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            hideAllPanel();
            clearErrorMessage();
            txtRoomName.Text = "";
            tbxSeatPattern.Text = "";
            pnlAdd.Visible = true;

            ddlRoomtypename.DataSource = Business_Logic.RoomTypeLogic.getRoomTypeList();
            ddlRoomtypename.DataTextField = "RoomType_Name";
            ddlRoomtypename.DataValueField = "RoomType_ID";
            ddlRoomtypename.DataBind();
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
                    Business_Logic.RoomLogic.insertRoom(txtRoomName.Text, Convert.ToInt32(Session["Var1"]), Convert.ToInt32(ddlRoomtypename.SelectedValue.ToString()), tbxSeatPattern.Text);
                    DatagridviewRefresh();
                    hideAllPanel();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Add New Room Success');", true);
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + ex.Message + "');", true);
                }
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            hideAllPanel();
        }

        protected void gdvRoom_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hideAllPanel();

            if (e.CommandName == "EditComm")
            {
                try
                {
                    int ee = Convert.ToInt32(e.CommandArgument);
                    int rid = Convert.ToInt32(gdvRoom.Rows[ee].Cells[0].Text);
                    Room r = Business_Logic.RoomLogic.getRoomByPK(rid);
                    hfEditId.Value = r.Room_ID.ToString();
                    txtrname.Text = r.Room_Name;
                    tbxESeatPattern.Text = r.Seat_Pattern;

                    ddlroomtype.DataSource = Business_Logic.RoomTypeLogic.getRoomTypeList();
                    ddlroomtype.DataTextField = "RoomType_Name";
                    ddlroomtype.DataValueField = "RoomType_ID";
                    ddlroomtype.DataBind();
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
                    int rid = Convert.ToInt32(gdvRoom.Rows[ee].Cells[0].Text);
                    Business_Logic.RoomLogic.deleteRoom(rid);
                    DatagridviewRefresh();
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
            if (txtRoomName.Text == "")
            {
                lblname.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            if (tbxSeatPattern.Text == "")
            {
                lbltsPattern.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            return ErrorBro;
        }

        protected bool errorEditChecking()
        {
            Boolean ErrorBro = false;
            if (txtrname.Text == "")
            {
                lbleditname.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            if (tbxESeatPattern.Text == "")
            {
                lbltSeatPattern.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            return ErrorBro;
        }

        protected void emptyEditMsgError()
        {
            lbleditname.Text = "";
            lbltSeatPattern.Text = "";
        }

        protected void emptyAddMsgError()
        {
            lblname.Text = "";
            lbltsPattern.Text = "";
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
                    Business_Logic.RoomLogic.updateRoom(Convert.ToInt32(hfEditId.Value), txtrname.Text, Convert.ToInt32(ddlroomtype.SelectedValue.ToString()), tbxESeatPattern.Text);
                    DatagridviewRefresh();
                    hideAllPanel();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Update Room Success');", true);
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