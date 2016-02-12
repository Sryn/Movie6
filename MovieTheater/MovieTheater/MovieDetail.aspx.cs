using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class MovieDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int mov = Convert.ToInt32(Session["mov"]);
                Movie mo = Business_Logic.MovieLogic.getMovieByPK(mov);
                lblTitle.Text = mo.Movie_Name;
                lblName.Text = mo.Movie_Name;
                lblDuration.Text = mo.Duration.ToString();
                if (mo.PictureURL != "" && mo.PictureURL != null)
                    imgMovie.ImageUrl = "movImage/" + mo.PictureURL;
                else
                    imgMovie.ImageUrl = "movImage/nopicture.png";
                hlinkImdb.NavigateUrl = mo.IMDB_Link;
                //lblImdb.Text = mo.IMDB_Link;
                hlinkImdb.Text = mo.IMDB_Link;
                lblDescription.Text = mo.Description;
                lblLanguage.Text = mo.Language;
                lblSubtitle.Text = mo.Subtitle;
                lblRatings.Text = mo.Ratings.ToString();

                pnlSchedule.Controls.Clear();

                List<Theater> tlist = Business_Logic.RoomMovieLogic.getThByMovie(mov);

                foreach (Theater t in tlist)
                {
                    HtmlGenericControl div = new HtmlGenericControl("div");
                    div.Attributes.Add("id", "tea" + t.Theater_ID);
                    div.InnerText = t.Theater_Name;
                    pnlSchedule.Controls.Add(div);

                    List<DateTime> rmDate = Business_Logic.RoomMovieLogic.getRMDateByTheaterMovie(t.Theater_ID, mov);
                    foreach (DateTime rm in rmDate)
                    {
                        HtmlGenericControl div1 = new HtmlGenericControl("div");
                        String str = "- ";
                        if (rm.Date.Day == DateTime.Today.Day &&
                            rm.Date.Month == DateTime.Today.Month &&
                            rm.Date.Year == DateTime.Today.Year)
                            str += "Today ";
                        else
                            str += rm.Date.ToString("dd MMM yyyy") + " ";
                        pnlSchedule.Controls.Add(div1);

                        List<TimeSpan> tsList = Business_Logic.RoomMovieLogic.getRMTimeByTheaterMovieDate(t.Theater_ID, mov, rm);
                        TimeSpan lastTime = tsList[tsList.Count - 1];
                        foreach (TimeSpan ts in tsList)
                        {
                            str += ts.ToString(@"hh\:mm");
                            if (ts != lastTime)
                                str += ", ";
                        }
                        div1.InnerText = str;
                        pnlSchedule.Controls.Add(div1);
                    }
                }
            }
        }
    }
}