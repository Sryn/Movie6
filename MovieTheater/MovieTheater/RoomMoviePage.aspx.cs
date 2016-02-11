using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Movie m = new Movie();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlAdd.Visible = false;
                pnlEdit.Visible = false;
                theaterddl.DataSource = Business_Logic.TheaterLogic.getTheaterList();
                theaterddl.DataTextField = "Theater_Name";
                theaterddl.DataValueField = "Theater_ID";
                theaterddl.DataBind();
                roomddl.DataSource = Business_Logic.RoomLogic.getRoomListByTheater(Convert.ToInt32(theaterddl.SelectedValue));
                roomddl.DataTextField = "Room_Name";
                roomddl.DataValueField = "Room_ID";
                roomddl.DataBind();               
            }
        }

        protected void theaterddl_SelectedIndexChanged2(object sender, EventArgs e)
        {
            roomddl.DataSource = Business_Logic.RoomLogic.getRoomListByTheater(Convert.ToInt32(theaterddl.SelectedValue));
            roomddl.DataTextField = "Room_Name";
            roomddl.DataValueField = "Room_ID";
            roomddl.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                refreshgridview();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void addroommoviebtn_Click(object sender, EventArgs e)
        {
            Calendar2.Visible = false;
            pnlEdit.Visible = false;
            pnlAdd.Visible = true;
            movieddl.DataSource = Business_Logic.MovieLogic.getMovieList();
            movieddl.DataTextField = "Movie_Name";
            movieddl.DataValueField = "Movie_ID";
            movieddl.DataBind();
            m = Business_Logic.MovieLogic.getMovieByPK(Convert.ToInt32(movieddl.SelectedValue));
            Label7.Text = Convert.ToString(m.Movie_ID);
            Label9.Text = m.Movie_Name;
            Label11.Text = Convert.ToString(m.Duration);
            Label13.Text = m.Description;
            Label15.Text = Convert.ToString(m.Ratings);

            TimeSpan st = TimeSpan.Parse(starttimeddl.SelectedValue);
            int dur = Convert.ToInt32(Label11.Text);
            int hf = dur / 30;
            int left = hf / 2;
            int right = hf % 2 + 1;
            TimeSpan final = new TimeSpan(st.Hours + left, st.Minutes + right * 30, 0);

            addetlb.Text = final.ToString(@"hh\:mm");
        }
        protected void movieddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            m = Business_Logic.MovieLogic.getMovieByPK(Convert.ToInt32(movieddl.SelectedValue));
            Label7.Text = Convert.ToString(m.Movie_ID);
            Label9.Text = m.Movie_Name;
            Label11.Text = Convert.ToString(m.Duration);
            Label13.Text = m.Description;
            Label15.Text = Convert.ToString(m.Ratings);
            TimeSpan st = TimeSpan.Parse(starttimeddl.SelectedValue);
            int dur = Convert.ToInt32(Label11.Text);
            int hf = dur / 30;
            int left = hf / 2;
            int right = hf % 2 + 1;
            TimeSpan final = new TimeSpan(st.Hours + left, st.Minutes + right * 30, 0);

            addetlb.Text = final.ToString(@"hh\:mm");
        }



        protected void roommoviegdv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rmid = Convert.ToInt32(roommoviegdv.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
            RoomMovie rm = Business_Logic.RoomMovieLogic.getRoomMovieByPK(rmid);
            if (e.CommandName == "EditComm")
            {              
                if (rm.Publish == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('This roommovie has already been published.');", true);
                }
                else
                {
                    Calendar1.Visible = false;
                    pnlAdd.Visible = false;
                    pnlEdit.Visible = true;
                    rmidtbx.Text = roommoviegdv.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                    rntbx.Text = roommoviegdv.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
                    mntbx.Text = roommoviegdv.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text;
                    pricetbx.Text = Convert.ToString(rm.Price);
                    updatetbx.Text = Convert.ToString(rm.Update_Datetime);
                    String tm = (TimeSpan.Parse(roommoviegdv.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text)).ToString(@"hh\:mm");
                    editstddl.SelectedValue = tm;

                    TimeSpan st = TimeSpan.Parse(editstddl.SelectedValue);
                    RoomMovie rm1 = Business_Logic.RoomMovieLogic.getRoomMovieByPK(Convert.ToInt32(rmidtbx.Text));
                    Movie m = Business_Logic.MovieLogic.getMovieByPK(rm1.Movie_ID);
                    int dur = m.Duration;
                    int hf = dur / 30;
                    int left = hf / 2;
                    int right = hf % 2 + 1;
                    TimeSpan final = new TimeSpan(st.Hours + left, st.Minutes + right * 30, 0);
                    editetlb.Text = final.ToString(@"hh\:mm");
                }
            }
            if (e.CommandName == "DeleteComm")
            {
                if (rm.Publish == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('This roommovie has already been published.');", true);
                }
                else
                {               
                    Business_Logic.RoomMovieLogic.deleteRoomMovie(rmid);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Delete succeeded.');", true);
                    refreshgridview();
                }  
            }
            if (e.CommandName == "Publish")
            {
                if (rm.Publish == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('This roommovie has already been published.');", true);
                }
                else
                {    
                    Business_Logic.RoomMovieLogic.publishRoomMovie(rmid);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Publish succeeded.');", true);
                    refreshgridview();
                }
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            TimeSpan st = TimeSpan.Parse(starttimeddl.SelectedValue);          

            if (Calendar1.SelectedDate.Year == 1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Date is not selected yet.');", true);
            }
            else if (Business_Logic.RoomMovieLogic.confirmRoomMovieByDateAndRoom(Convert.ToInt32(roomddl.SelectedValue), Calendar1.SelectedDate, TimeSpan.Parse(starttimeddl.SelectedValue), TimeSpan.Parse(addetlb.Text)))
            {
                int rid = Convert.ToInt32(roomddl.SelectedValue);
                Room r = Business_Logic.RoomLogic.getRoomByPK(rid);
                RoomType rt = Business_Logic.RoomTypeLogic.getRoomTypeByPK(r.RoomType_ID);
                Business_Logic.RoomMovieLogic.insertRoomMovie(rid, Calendar1.SelectedDate, TimeSpan.Parse(starttimeddl.SelectedValue), TimeSpan.Parse(addetlb.Text), Convert.ToInt32(Label7.Text), rt.Price);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Room movie added successfully.');", true);
                pnlAdd.Visible = false;
                refreshgridview();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Time conflict with other roommovie.');", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlEdit.Visible = false;
        }

        protected void addcancelbtn_Click(object sender, EventArgs e)
        {
            pnlAdd.Visible = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Calendar2.SelectedDate.Year == 1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Date is not selected yet.');", true);
            }
            else if (Business_Logic.RoomMovieLogic.confirmRoomMovieByDateAndRoom(Convert.ToInt32(rmidtbx.Text), Calendar2.SelectedDate, TimeSpan.Parse(editstddl.SelectedValue), TimeSpan.Parse(editetlb.Text)))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Time conflict with other roommovie.');", true);
            }
            else
            {
                int rmid = Convert.ToInt32(rmidtbx.Text);
                Business_Logic.RoomMovieLogic.updateRoomMovie(rmid, Calendar2.SelectedDate, TimeSpan.Parse(editstddl.SelectedValue), TimeSpan.Parse(editetlb.Text));
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Room movie updated successfully.');", true);
                pnlEdit.Visible = false;
                refreshgridview();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            calendartbx.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }


        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            editcalendartbx.Text = Calendar2.SelectedDate.ToShortDateString();
            Calendar2.Visible = false;
        }

        protected void editimagebutton_Click(object sender, ImageClickEventArgs e)
        {
            Calendar2.Visible = true;
        }

        protected void starttimeddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimeSpan st =TimeSpan.Parse(starttimeddl.SelectedValue);
            int dur = Convert.ToInt32(Label11.Text);
            int hf = dur/30;
            int left = hf/2;
            int right = hf % 2 + 1 ;
            TimeSpan final = new TimeSpan(st.Hours+left,st.Minutes+right*30,0);

            addetlb.Text = Convert.ToString(final);
        }

        protected void editstddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimeSpan st = TimeSpan.Parse(editstddl.SelectedValue);
            RoomMovie rm = Business_Logic.RoomMovieLogic.getRoomMovieByPK(Convert.ToInt32(rmidtbx.Text));
            Movie m = Business_Logic.MovieLogic.getMovieByPK(rm.Movie_ID);
            int dur = m.Duration;
            int hf = dur / 30;
            int left = hf / 2;
            int right = hf % 2 + 1;
            TimeSpan final = new TimeSpan(st.Hours + left, st.Minutes + right * 30, 0);

            editetlb.Text = final.ToString(@"hh\:mm");
        }

        protected void refreshgridview()
        {
            roommoviegdv.DataSource = Business_Logic.RoomMovieLogic.getRoomMovieByDateandRoom(Convert.ToInt32(roomddl.SelectedValue), Calendar1.SelectedDate);
            roommoviegdv.DataBind();
        }

    }
}