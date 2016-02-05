using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class StaffTestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    MovieTheaterEntities context = new MovieTheaterEntities();
            //    MovieGridView.DataSource = context.Movie.Where(s => s.Active_Indicator == true).ToList<Movie>();
            //    MovieGridView.DataBind();
            //    Label1.Text = "Loaded";
            //}
        }
    }
}