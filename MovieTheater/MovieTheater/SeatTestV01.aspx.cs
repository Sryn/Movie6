using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class SeatTestV01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void SeatA1_Click(object sender, ImageClickEventArgs e)
        //{
        //    SeatA1.BackColor = System.Drawing.Color.Red;
        //}

        protected void ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgBtn = sender as ImageButton;
            //Button button = sender as Button;
            if (imgBtn != null)
            {
                //get the id here
                Label1.Text = imgBtn.ID;
                imgBtn.BackColor = System.Drawing.Color.Red;
            }
        }

    }
}