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
        private Boolean inEdit
        {
            set { ViewState["inEdit"] = value; }
            get { return (Boolean)ViewState["inEdit"]; }
        }

        //public String theatreName
        //{
        //    get { return lblTheaterNameTitle.Text; }
        //}

        private String theatreName2
        {
            set { Session["name"] = value; }
            get { return Session["name"] as String; }
        }

        //public String theatreRoomName
        //{
        //    get {
        //        if (inEdit) return txtrname.Text;
        //        else return txtRoomName.Text; }
        //}

        private String theatreRoomName2
        {
            set { Session["theatreRoomName"] = value; }
            get { return Session["theatreRoomName"] as String; }
        }

        private int theatreRoomID
        {
            set { Session["theatreRoomID"] = value; }
            get { return Convert.ToInt32(Session["theatreRoomID"]); }
        }

        //public String theatreRoomSeatMapPattern
        //{
        //    get {
        //        if (inEdit) return lbl2ESeatPattern.Text;
        //        else return lblSeatPattern.Text; }
        //}

        private String theatreSeatMapPattern2
        {
            get { return Session["seatMapPattern"] as String; }
            set { Session["seatMapPattern"] = value; }
        }

        //public String theatreRoomType
        //{
        //    get {
        //        if (inEdit) return ddlroomtype.SelectedValue;
        //        else return ddlRoomtypename.SelectedValue; }
        //}

        private String theatreRoomType2
        {
            set { Session["theatreRoomType"] = value; }
            get { return Session["theatreRoomType"] as String; }
        }

        //public String theatreRoomTypeText
        //{
        //    get {
        //        if (inEdit) return ddlroomtype.Items.FindByValue(theatreRoomType).Text;
        //        else return ddlRoomtypename.Items.FindByValue(theatreRoomType).Text; }
        //}

        private String theatreRoomTypeText2
        {
            set { Session["theatreRoomTypeText"] = value; }
            get { return Session["theatreRoomTypeText"] as String; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DatagridviewRefresh();
                checkReferrer();
                inEdit = false;
                initiateSessionVars();
            }
            showReferrerDetails();
            System.Diagnostics.Debug.WriteLine(">> Page_Load inEdit=" + inEdit);
        }

        private void initiateSessionVars()
        {
            if (Session["name"] == null)
            {
                theatreName2 = lblTheaterNameTitle.Text;
            }
            if (Session["theatreRoomName"] == null)
            {
                theatreRoomName2 = "";
            }
            if (Session["theatreRoomID"] == null)
            {
                theatreRoomID = Int32.MinValue;
            }
            if (Session["theatreSeatMapPattern"] == null)
            {
                theatreSeatMapPattern2 = "";
            }
            if (Session["theatreRoomType"] == null)
            {
                theatreRoomType2 = "";
            }
            if (Session["theatreRoomTypeText"] == null)
            {
                theatreRoomTypeText2 = "";
            }
        }

        private void updateSessionVars()
        {
            if (!inEdit)
            {
                theatreRoomName2 = txtRoomName.Text;
                theatreSeatMapPattern2 = lblSeatPattern.Text;
                theatreRoomType2 = ddlRoomtypename.SelectedValue;
                theatreRoomTypeText2 = ddlRoomtypename.Items.FindByValue(theatreRoomType2).Text;
            }
            else
            {
                //theatreRoomID = Convert.ToInt32(hfEditId.Value);
                theatreRoomName2 = txtrname.Text;
                theatreSeatMapPattern2 = lbl2ESeatPattern.Text;
                theatreRoomType2 = ddlroomtype.SelectedValue;
                theatreRoomTypeText2 = ddlroomtype.Items.FindByValue(theatreRoomType2).Text;
            }
        }

        private void checkReferrer()
        {
            //throw new NotImplementedException();

            if (GetReferrerPageName() == "DesignTheatreSeatMap.aspx")
            {
                String roomName = string.Empty;
                String roomType = string.Empty;
                String privSeatMapPattern = string.Empty;

                if (Request.QueryString["roomName"] != null)
                {
                    roomName = Request.QueryString["roomName"];
                    System.Diagnostics.Debug.WriteLine(">> Request.QueryString[\"roomName\"]=" + roomName);
                }

                if (Request.QueryString["roomType"] != null)
                {
                    roomType = Request.QueryString["roomType"];
                    System.Diagnostics.Debug.WriteLine(">> Request.QueryString[\"roomType\"]=" + roomType);
                }

                if (Session["seatMapPattern"] != null)
                {
                    privSeatMapPattern = Session["seatMapPattern"] as String;
                    System.Diagnostics.Debug.WriteLine(">> Session[\"seatMapPattern\"]=" + privSeatMapPattern);
                }

                // this overrides session because this is assumed to be the updated/edited one
                if (Request.QueryString["seatMapPattern"] != null)
                {
                    privSeatMapPattern = Request.QueryString["seatMapPattern"];
                    System.Diagnostics.Debug.WriteLine(">> Request.QueryString[\"seatMapPattern\"]=" + privSeatMapPattern);
                }

                doBtnAdd_Click();
                txtRoomName.Text = roomName;
                ddlRoomtypename.SelectedValue = roomType;
                lblSeatPattern.Text = privSeatMapPattern;
                lbl2ESeatPattern.Text = privSeatMapPattern;
                theatreSeatMapPattern2 = privSeatMapPattern;
            }
        }

        private void showReferrerDetails()
        {
            System.Diagnostics.Debug.WriteLine(">> Request.UrlReferrer=" + Request.UrlReferrer.ToString());

            System.Diagnostics.Debug.WriteLine(">> GetReferrerPageName()=" + GetReferrerPageName());

            if (Request.QueryString["roomName"] != null)
                System.Diagnostics.Debug.WriteLine(">> Request.QueryString[\"roomName\"]=" + Request.QueryString["roomName"]);
            //if (Request.QueryString["seatMapPattern"] != null)
            //    System.Diagnostics.Debug.WriteLine(">> Request.QueryString[\"seatMapPattern\"]=" + Request.QueryString["seatMapPattern"]);
        }

        public string GetCurrentPageName()
        {
            string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            string sRet = oInfo.Name;
            return sRet;
        }

        public string GetReferrerPageName()
        {
            string sPath = System.Web.HttpContext.Current.Request.UrlReferrer.AbsolutePath;
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            string sRet = oInfo.Name;
            return sRet;
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
            doBtnAdd_Click();
        }

        private void doBtnAdd_Click()
        {
            inEdit = false;

            hideAllPanel();
            clearErrorMessage();
            txtRoomName.Text = "";
            lblSeatPattern.Text = "";
            pnlAdd.Visible = true;

            ddlRoomtypename.DataSource = Business_Logic.RoomTypeLogic.getRoomTypeList();
            ddlRoomtypename.DataTextField = "RoomType_Name";
            ddlRoomtypename.DataValueField = "RoomType_ID";
            ddlRoomtypename.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            inEdit = false;

            emptyAddMsgError();
            Boolean error = false;
            error = errorAddChecking();

            if (error == false)
            {
                try
                {
                    Business_Logic.RoomLogic.insertRoom(txtRoomName.Text, Convert.ToInt32(Session["Var1"]), Convert.ToInt32(ddlRoomtypename.SelectedValue.ToString()), lblSeatPattern.Text);
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
            inEdit = false;

            hideAllPanel();
        }

        protected void gdvRoom_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> gdvRoom_RowCommand e.CommandName=" + e.CommandName);

            hideAllPanel();
            inEdit = true;

            if (e.CommandName == "EditComm")
            {
                try
                {
                    getChosenRoomDetails(e);              

                    // ddlRoomtypename.Items.FindByValue(theatreRoomType).Text
                    //ddlroomtype.SelectedIndex = r.RoomType_ID;
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

            if (e.CommandName == "NextComm")
            {
                System.Diagnostics.Debug.WriteLine(">> gdvRoom_RowCommand if(e.CommandName == \"" + e.CommandName + "\")");

                // should make seat data and save to dB
                getChosenRoomDetails(e);
                Response.Redirect("~/MakeSeats.aspx");
            }
        }

        private void getChosenRoomDetails(GridViewCommandEventArgs e)
        {
            int ee = Convert.ToInt32(e.CommandArgument);
            int rid = Convert.ToInt32(gdvRoom.Rows[ee].Cells[0].Text);

            Room r = Business_Logic.RoomLogic.getRoomByPK(rid);
            hfEditId.Value = r.Room_ID.ToString();
            theatreRoomID = r.Room_ID;
            txtrname.Text = r.Room_Name;
            lbl2ESeatPattern.Text = r.Seat_Pattern;

            ddlroomtype.DataSource = Business_Logic.RoomTypeLogic.getRoomTypeList();
            ddlroomtype.DataTextField = "RoomType_Name";
            ddlroomtype.DataValueField = "RoomType_ID";
            ddlroomtype.DataBind();
            ddlroomtype.Items.Insert(0, new ListItem("Please select"));

            updateSessionVars();

            System.Diagnostics.Debug.WriteLine(">> getChosenRoomDetails r.RoomType=" + r.RoomType + " r.RoomType_ID=" + r.RoomType_ID);
        }

        protected bool errorAddChecking()
        {
            Boolean ErrorBro = false;
            if (txtRoomName.Text == "")
            {
                lblname.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            if (lblSeatPattern.Text == "")
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
            if (lbl2ESeatPattern.Text == "")
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
            inEdit = true;

            emptyEditMsgError();
            Boolean error = false;
            error = errorEditChecking();

            if (error == false)
            {
                try
                {
                    Business_Logic.RoomLogic.updateRoom(Convert.ToInt32(hfEditId.Value), txtrname.Text, Convert.ToInt32(ddlroomtype.SelectedValue.ToString()), lbl2ESeatPattern.Text);
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
            inEdit = true;

            hideAllPanel();
        }

        protected void inEditBtnToDTSeatMap_Click(object sender, EventArgs e)
        {
            inEdit = true;

            System.Diagnostics.Debug.WriteLine(">> inEditBtnToDTSeatMap_Click()");

            updateSessionVars();

            String queryString = "~/DesignTheatreSeatMap.aspx";

            Response.Redirect(queryString);
        }

        protected void inAddBtnToDTSeatMap_Click(object sender, EventArgs e)
        {
            inEdit = false;

            System.Diagnostics.Debug.WriteLine(">> inAddBtnToDTSeatMap_Click()");

            updateSessionVars();

            String queryString = "~/DesignTheatreSeatMap.aspx";

            Response.Redirect(queryString);
        }
    }
}