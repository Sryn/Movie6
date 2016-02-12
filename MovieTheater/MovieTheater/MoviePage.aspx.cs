using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class MoviePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                refreshGridView();
            }
        }

        protected void refreshGridView()
        {
            try
            {
                gvwMovie.Columns[0].Visible = true;
                gvwMovie.DataSource = Business_Logic.MovieLogic.getMovieList();
                gvwMovie.DataBind();
                gvwMovie.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void hideAllPanel()
        {
            pnlAdd.Visible = false;
            pnlEdit.Visible = false;
        }

        protected void emptyAddMsgError()
        {
            lblEAName.Text = "";
            lblEADuration.Text = "";
            lblEADescription.Text = "";
            lblEALanguage.Text = "";
            lblEASubtitle.Text = "";
            lblEARatings.Text = "";
        }

        protected void emptyAddControl()
        {
            tbxAddName.Text = "";
            tbxAddDuration.Text = "";
            tbxAddDescription.Text = "";
            tbxAddLanguage.Text = "";
            tbxAddSubtitle.Text = "";
            tbxAddRatings.Text = "";
        }

        protected void emptyEditMsgError()
        {
            lblEEName.Text = "";
            lblEEDuration.Text = "";
            lblEEDescription.Text = "";
            lblEELanguage.Text = "";
            lblEESubtitle.Text = "";
            lblEERatings.Text = "";
        }

        protected void emptyEditControl()
        {
            tbxEditName.Text = "";
            tbxEditDuration.Text = "";
            tbxEditDescription.Text = "";
            tbxEditLanguage.Text = "";
            tbxEditSubtitle.Text = "";
            tbxEditRatings.Text = "";
        }

        protected bool addEmptyChecking()
        {
            Boolean ErrorBro = false;
            if (tbxAddName.Text == "")
            {
                lblEAName.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            if (tbxAddDuration.Text == "")
            {
                lblEADuration.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            if (tbxAddDescription.Text == "")
            {
                lblEADescription.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            if (tbxAddLanguage.Text == "")
            {
                lblEALanguage.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            if (tbxAddSubtitle.Text == "")
            {
                lblEASubtitle.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            if (tbxAddRatings.Text == "")
            {
                lblEARatings.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            return ErrorBro;
        }

        protected bool editEmptyChecking()
        {
            Boolean ErrorBro = false;
            if (tbxEditName.Text == "")
            {
                lblEEName.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            if (tbxEditDuration.Text == "")
            {
                lblEEDuration.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            if (tbxEditDescription.Text == "")
            {
                lblEEDescription.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            if (tbxEditLanguage.Text == "")
            {
                lblEELanguage.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            if (tbxEditSubtitle.Text == "")
            {
                lblEESubtitle.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            if (tbxEditRatings.Text == "")
            {
                lblEERatings.Text = "this field should not be blank!";
                ErrorBro = true;
            }
            return ErrorBro;
        }

        protected void gvwMovie_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hideAllPanel();

            if (e.CommandName == "EditComm")
            {
                emptyEditControl();
                emptyEditMsgError();

                try
                {
                    int ee = Convert.ToInt32(e.CommandArgument);
                    int mid = Convert.ToInt32(gvwMovie.Rows[ee].Cells[0].Text);
                    Movie mv = Business_Logic.MovieLogic.getMovieByPK(mid);
                    hfEditId.Value = mid.ToString();
                    tbxEditName.Text = mv.Movie_Name;
                    tbxEditDuration.Text = mv.Duration.ToString();
                    tbxEditDescription.Text = mv.Description;
                    tbxEditLanguage.Text = mv.Language;
                    tbxEditSubtitle.Text = mv.Subtitle;
                    tbxEditRatings.Text = mv.Ratings.ToString();
                    tbxEditImdb.Text = mv.IMDB_Link;
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
                    int mid = Convert.ToInt32(gvwMovie.Rows[ee].Cells[0].Text);
                    Business_Logic.MovieLogic.deleteMovie(mid);
                    refreshGridView();

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Delete Movie Success');", true);
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + ex.Message + "');", true);
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            hideAllPanel();

            emptyAddControl();
            emptyAddMsgError();

            pnlAdd.Visible = true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string saveDir = @"\movImage\";
            string appPath = Request.PhysicalApplicationPath;
            string fileName = "";
            if (fuAddPicture.HasFile)
            {
                string savePath = appPath + saveDir + Server.HtmlEncode(fuAddPicture.FileName);
                fileName = fuAddPicture.FileName;
                fuAddPicture.SaveAs(savePath);
            }

            emptyAddMsgError();

            //Empty Checking
            Boolean ErrorBro = false;
            ErrorBro = addEmptyChecking();

            // insert process
            if (ErrorBro == false)
            {
                try
                {
                    Business_Logic.MovieLogic.insertMovie(
                        tbxAddName.Text,
                        Convert.ToInt32(tbxAddDuration.Text),
                        tbxAddDescription.Text,
                        tbxAddLanguage.Text,
                        tbxAddSubtitle.Text,
                        Convert.ToDouble(tbxAddRatings.Text),
                        fileName, tbxAddImdb.Text);

                    refreshGridView();
                    hideAllPanel();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Add New Movie Success');", true);
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string saveDir = @"\movImage\";
            string appPath = Request.PhysicalApplicationPath;
            string fileName = "";
            if (fuEditPicture.HasFile)
            {
                string savePath = appPath + saveDir + Server.HtmlEncode(fuEditPicture.FileName);
                fileName = fuEditPicture.FileName;
                fuEditPicture.SaveAs(savePath);
            }

            emptyEditMsgError();

            //Empty Checking
            Boolean ErrorBro = false;
            ErrorBro = editEmptyChecking();

            // update process
            if (ErrorBro == false)
            {
                try
                {
                    Business_Logic.MovieLogic.updateMovie(
                        Convert.ToInt32(hfEditId.Value),
                        tbxEditName.Text,
                        Convert.ToInt32(tbxEditDuration.Text),
                        tbxEditDescription.Text,
                        tbxEditLanguage.Text,
                        tbxEditSubtitle.Text,
                        Convert.ToDouble(tbxEditRatings.Text),
                        fileName, tbxEditImdb.Text);
                    refreshGridView();
                    hideAllPanel();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Update Movie Information Success');", true);
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