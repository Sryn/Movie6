using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class MakeSeats : System.Web.UI.Page
    {
//        int rowCount = 0, seatColCount = 0, theatreRoomID = 0;
//        String seatMapPattern = "";

        protected int rowCount
        {
            get { return (int)ViewState["rowCount"]; }
            set { ViewState["rowCount"] = value; }
        }

        protected int seatColCount
        {
            get { return (int)ViewState["seatColCount"]; }
            set { ViewState["seatColCount"] = value; }
        }

        protected int theatreRoomID
        {
            get { return (int)ViewState["theatreRoomID"]; }
            set { ViewState["theatreRoomID"] = value; }
        }

        protected String seatMapPattern
        {
            get { return (String)ViewState["seatMapPattern"]; }
            set { ViewState["seatMapPattern"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                System.Diagnostics.Debug.WriteLine(">> MakeSeats Page_Load IsPostBack=" + IsPostBack);
                updatePageDetails();
            }

            System.Diagnostics.Debug.WriteLine(">> MakeSeats Page_Load IsPostBack=" + IsPostBack);
            checkIfEnoughDetails();
        }

        private void checkIfEnoughDetails()
        {
            //throw new NotImplementedException();
            btnCreate.Enabled = false;

            if (rowCount > 0 && seatColCount > 0 && theatreRoomID > 0)
                btnCreate.Enabled = true;
        }

        private void updatePageDetails()
        {
            //throw new NotImplementedException();
            System.Diagnostics.Debug.WriteLine(">> updatePageDetails()");

            if (Session["name"] != null)
            {
                lblTheatreName.Text = Session["name"] as String;
            }

            if (Session["theatreRoomName"] != null)
            {
                lblTheatreRoomName.Text = Session["theatreRoomName"] as String;
            }

            if (Session["theatreRoomID"] != null)
            {
                //lblTheatreRoomID.Text = Session["theatreRoomID"] as String;
                //theatreRoomID = Convert.ToInt32(lblTheatreRoomID.Text);
                theatreRoomID = Convert.ToInt32(Session["theatreRoomID"]);
                lblTheatreRoomID.Text = theatreRoomID.ToString();
            }

            if (Session["seatMapPattern"] != null)
            {
                seatMapPattern = Session["seatMapPattern"] as String;
                parseSeatMapPattern(seatMapPattern);
                lblRowCount.Text = rowCount.ToString();
                lblSeatColCount.Text = seatColCount.ToString();
                lblTotalSeats.Text = (rowCount * seatColCount).ToString();
            }

            //if (Session["name"] != null)
            //{
            //    lblTheatreName.Text = Session["name"] as String;
            //}

        }

        private void parseSeatMapPattern(String privSeatMapPattern)
        {
            System.Diagnostics.Debug.WriteLine(">> parseSeatMapPattern(\"" + privSeatMapPattern + "\")");
            //throw new NotImplementedException();

            string[] stringCommaSplit = privSeatMapPattern.Split(',');
            int arraySize = stringCommaSplit.Length;

            int result = 0;

            if (int.TryParse(stringCommaSplit[0].Trim(), out result))
            {
                rowCount = result;
            }

            result = 0;

            if (int.TryParse(stringCommaSplit[1].Trim(), out result))
            {
                seatColCount = result;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> btnCancel_Click()");
            Response.Redirect("~/RoomPage.aspx");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> btnCreate_Click()");
            // should do the create seats db call here
            try
            {
                //Business_Logic.RoomLogic.insertRoom(txtRoomName.Text, Convert.ToInt32(Session["Var1"]), Convert.ToInt32(ddlRoomtypename.SelectedValue.ToString()), lblSeatPattern.Text);
                //DatagridviewRefresh();
                //hideAllPanel();
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Add New Room Success');", true);

                String errorMsg = "";

                if (Business_Logic.SeatLogic.createRoomSeats(theatreRoomID, rowCount, seatColCount, out errorMsg))
                {
                    // success
                    System.Diagnostics.Debug.WriteLine(">> btnCreate_Click() Success");
                    btnCreate.Enabled = false;
                    btnCancel.Text = "< Go Back";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + errorMsg + "');", true);
                }
                else
                {
                    // error
                    System.Diagnostics.Debug.WriteLine(">> btnCreate_Click() Error = " + errorMsg);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + errorMsg + "');", true);

                    int errorMsgCode;

                    if (Int32.TryParse(errorMsg.Substring(10, 2), out errorMsgCode) && errorMsgCode == 1)
                    {
                        // offer to deactivate previous room seats
                        System.Diagnostics.Debug.WriteLine(">> btnCreate_Click() errorMsgCode = " + errorMsgCode);
                        btnDeactivateRoomSeats.Visible = true;
                        btnDeactivateRoomSeats.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void btnDeactivateRoomSeats_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> btnDeactivateRoomSeats_Click()");

            try
            {
                String errorMsg = "";

                if (Business_Logic.SeatLogic.deactivateRoomSeats(theatreRoomID, out errorMsg))
                {
                    // success
                    btnDeactivateRoomSeats.Enabled = false;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + errorMsg + "');", true);
                }
                else
                {
                    // error
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + errorMsg + "');", true);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + ex.Message + "');", true);
            }

        }
    }
}