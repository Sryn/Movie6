using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class genChkBoxTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> In Page_Load");

            Table tbl = new Table();
            TableRow tblRow1 = new TableRow();
            TableRow tblRow2 = new TableRow();
            TableRow tblRow3 = new TableRow();

            TableCell tblCell1_1 = new TableCell();
            Label lbl1_1 = new Label();
            lbl1_1.Text = "lbl1_1";
            tblCell1_1.Controls.Add(lbl1_1);

            TableCell tblCell1_2 = new TableCell();
            TextBox tbx1_2 = new TextBox();
//            Label lbl1_2 = new Label();
            tbx1_2.ID = "tbx1_2";
            tbx1_2.Width = 300;
            tbx1_2.Text = "tbx1_2";
            tblCell1_2.Controls.Add(tbx1_2);

            tblRow1.Controls.Add(tblCell1_1);
            tblRow1.Controls.Add(tblCell1_2);

            TableCell tblCell2_1 = new TableCell();
            CheckBox cbx2_1 = new CheckBox();
            cbx2_1.ID = "cbx2_1";
            cbx2_1.Text = "cbx2_1";
            tblCell2_1.Controls.Add(cbx2_1);

            TableCell tblCell2_2 = new TableCell();
            CheckBox cbx2_2 = new CheckBox();
            cbx2_2.ID = "cbx2_2";
            cbx2_2.Text = "cbx2_2";
            tblCell2_2.Controls.Add(cbx2_2);

            tblRow2.Controls.Add(tblCell2_1);
            tblRow2.Controls.Add(tblCell2_2);

            TableCell tblCell3_1 = new TableCell();
            tblCell3_1.Text = "Blank Cell";

            TableCell tblCell3_2 = new TableCell();
            Button btnTest = new Button();
            btnTest.ID = "btnTest";
            btnTest.Text = "Test";
            btnTest.Click += new EventHandler(btn_Click);
            tblCell3_2.Controls.Add(btnTest);

            tblRow3.Controls.Add(tblCell3_1);
            tblRow3.Controls.Add(tblCell3_2);

            tbl.Controls.Add(tblRow1);
            tbl.Controls.Add(tblRow2);
            tbl.Controls.Add(tblRow3);

            Panel1.Controls.Add(tbl);

            if (!IsPostBack)
            {
                System.Diagnostics.Debug.WriteLine(">> In Page_Load if(!IsPostBack)");
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            //Need to know which btn was clicked
            Button btn = sender as Button;
            TextBox tempTbx;
            String myStringVariable = String.Empty;
            tempTbx = getTbx(Panel1, "tbx1_2");
            System.Diagnostics.Debug.WriteLine(">> In btn_Click");

            if (btn != null)
            {
                System.Diagnostics.Debug.WriteLine(">> In btn_Click btn.id=" + btn.ID);

                if (tempTbx != null)
                {
                    tempTbx.Text = btn.ID;
                    tempTbx.Text += " cbx2_1=" + getCbxResult(Panel1, "cbx2_1");
                    tempTbx.Text += " cbx2_2=" + getCbxResult(Panel1, "cbx2_2");
                }
                else
                {
                    myStringVariable = "tbx1_2 not found";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                }
//                int id = Convert.ToInt32(btn.CommandArgument);
                //etc
            }
            else
            {
                //throw exception, etc
                myStringVariable = "button not found";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }
        }

        private TextBox getTbx(Panel pnlID, string tbxID)
        {
            //            throw new NotImplementedException();

            TextBox tempTbx = pnlID.FindControl(tbxID) as TextBox;

            if (tempTbx != null)
            {
                return tempTbx;
            }
            else
            {
                return null;
            }
        }

        private String getCbxResult(Panel pnlID, String cbxID)
        {
            CheckBox tempCbx = pnlID.FindControl(cbxID) as CheckBox;

            if (tempCbx != null)
            {
                return tempCbx.Checked.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}