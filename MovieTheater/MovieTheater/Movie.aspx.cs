using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class Movie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var context = new MovieTheaterEntities();
                gvwMovie.DataSource = context.Movie.Where(s => s.Active_Indicator == true).ToList<Movie>();
                gvwMovie.DataBind();
            }
        }

        protected void hideAllPanel()
        {
            pnlAdd.Visible = false;
            pnlEdit.Visible = false;
        }

        protected void gvwMovie_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hideAllPanel();

            if (e.CommandName == "EditComm")
            {
                pnlEdit.Visible = true;
            }

            if (e.CommandName == "DeleteComm")
            {

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            hideAllPanel();
            tbxAddName.Text = "";
            tbxAddDuration.Text = "";
            tbxAddDescription.Text = "";
            tbxAddLanguage.Text = "";
            tbxAddSubtitle.Text = "";
            tbxAddRatings.Text = "";
            pnlAdd.Visible = true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (var context = new MovieTheaterEntities())
            {
                Movie mv = new Movie();
                mv.Movie_Name = tbxAddName.Text;
                mv.Duration = Convert.ToInt32(tbxAddDuration.Text);
                mv.PictureURL = null;
                mv.IMDB_Link = null;
                mv.Description = tbxAddDescription.Text;
                mv.Language = tbxAddLanguage.Text;
                mv.Subtitle = tbxAddSubtitle.Text;
                mv.Ratings = Convert.ToDouble(tbxAddRatings.Text);
                mv.Active_Indicator = true;
                mv.Update_Datetime = DateTime.Today;

                context.Movie.Add(mv);
                context.SaveChanges();
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            hideAllPanel();
        }

        
    }
}