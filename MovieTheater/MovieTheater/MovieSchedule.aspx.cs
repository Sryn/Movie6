using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class MovieSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rbtnAll.Checked = true;

                var t = Business_Logic.RoomMovieLogic.getTodayTheater();
                if (t.Count > 0)
                {
                    ddlTheater.DataSource = t;
                    ddlTheater.DataTextField = "Theater_Name";
                    ddlTheater.DataValueField = "Theater_ID";
                    ddlTheater.DataBind();
                    ddlTheater.Visible = true;
                    tbxTheater.Visible = false;
                    btnSeach.Visible = true;
                }
                else
                {
                    ddlTheater.Visible = false;
                    tbxTheater.Visible = true;
                    btnSeach.Visible = false;
                }

                var m = Business_Logic.RoomMovieLogic.getTodayMovie();
                if (m.Count > 0)
                {
                    ddlMovie.DataSource = m;
                    ddlMovie.DataTextField = "Movie_Name";
                    ddlMovie.DataValueField = "Movie_ID";
                    ddlMovie.DataBind();
                    ddlMovie.Visible = true;
                    tbxMovie.Visible = false;
                    btnSeach.Visible = true;
                }
                else
                {
                    ddlMovie.Visible = false;
                    tbxMovie.Visible = true;
                    btnSeach.Visible = false;
                }
            }
        }

        protected void btnSeach_Click(object sender, EventArgs e)
        {
            if (rbtnAll.Checked)
            {
                gvwMovieSchedule.Columns[0].Visible = true;
                gvwMovieSchedule.DataSource = Business_Logic.RoomMovieLogic.getTodayRoomMovie();
                gvwMovieSchedule.DataBind();
                gvwMovieSchedule.Columns[0].Visible = false;
            }
            else if (rbtnTheater.Checked)
            {
                gvwMovieSchedule.Columns[0].Visible = true;
                gvwMovieSchedule.DataSource = Business_Logic.RoomMovieLogic.getTodayRoomMovieByTheater(Convert.ToInt32(ddlTheater.SelectedValue));
                gvwMovieSchedule.DataBind();
                gvwMovieSchedule.Columns[0].Visible = false;
            }
            else if (rbtnMovie.Checked)
            {
                gvwMovieSchedule.Columns[0].Visible = true;
                gvwMovieSchedule.DataSource = Business_Logic.RoomMovieLogic.getTodayRoomMovieByMovie(Convert.ToInt32(ddlMovie.SelectedValue));
                gvwMovieSchedule.DataBind();
                gvwMovieSchedule.Columns[0].Visible = false;
            }
        }

        protected void gvwMovieSchedule_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Take")
            {
                int ee = Convert.ToInt32(e.CommandArgument);
                int rmid = Convert.ToInt32(gvwMovieSchedule.Rows[ee].Cells[0].Text);
                Session["rmid"] = rmid;
                Response.Redirect("CustomerRegister.aspx");
            }
        }
    }
}