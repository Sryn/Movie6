using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class MovieList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    gvwMovieList.Columns[0].Visible = true;
                    gvwMovieList.DataSource = Business_Logic.MovieLogic.getMovieList();
                    gvwMovieList.DataBind();
                    gvwMovieList.Columns[0].Visible = false;
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + ex.Message + "');", true);
                }
            }
        }

        protected void gvwMovieList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "NextComm")
            {
                try
                {
                    int ee = Convert.ToInt32(e.CommandArgument);
                    Session["mov"] = gvwMovieList.Rows[ee].Cells[0].Text;
                    Response.Redirect("MovieDetail.aspx");
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + ex.Message + "');", true);
                }
            }
        }
    }
}