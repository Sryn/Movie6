using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class genChkBoxTest_wMstrPage : System.Web.UI.Page
    {
        int numOfCheckBoxes = 0;
        Panel pnlCbxs = new Panel();
        Panel pnlTbxs = new Panel();

        // a Property that manages a counter stored in ViewState
        protected int NumberOfControls
        {
            get { return (int)ViewState["NumControls"]; }
            set { ViewState["NumControls"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> In Page_Load");
            
            createElements();

            if (!IsPostBack)
            {
                System.Diagnostics.Debug.WriteLine(">> In Page_Load if(!IsPostBack)");

                //Initiate the counter of dynamically added controls
                this.NumberOfControls = 0;
            }
            //if (!Page.IsPostBack)
            else
            {
                //Controls must repeatedly be created on postback
                // Sryn: Cannot work without this, else they'll reset the values to blank
                // only way to add or delete while saving states is to recreate all
                // and then add or remove accordingly
                this.createControls(NumberOfControls);
            }
        }

        // This routine creates the controls and assigns a generic ID
        private void createControls(int count)
        {
            System.Diagnostics.Debug.WriteLine(">> In createControls(" + count + ")");

            // int count = this.NumberOfControls;
            int i;

            if ((count > 0) && (count == NumberOfControls))
            {
                // to prevent it adding more the second time it calls from the btnClick function
                //  when the count doesn't change from previous postback
                if (pnlTbxs.Controls.Count == 0)
                {
                    for (i = 0; i < count; i++)
                    {
                        TextBox tx = new TextBox();
                        tx.ID = "ControlID_" + i.ToString();
                        //Add the Controls to the container of your choice
                        //Page.Controls.Add(tx);
                        pnlTbxs.Controls.Add(tx);

                        //addSomeControl(i); // shouldn't do this as it'll reset the value
                    }
                }
            }
            else if (count > NumberOfControls)
            {
                for (i = NumberOfControls; i < count; i++)
                {
                    addSomeControl(i);
                }
            }
            else if (count < NumberOfControls)
            {
                for (i = NumberOfControls; i > count; i--)
                {
                    delSomeControl();
                }
            }
        }

        // example of dynamic addition of controls
        // note the use of the ViewState variable
        private void addSomeControl(int i)
        {
            TextBox tx = new TextBox();
//            tx.ID = "ControlID_" + NumberOfControls.ToString();
            tx.ID = "ControlID_" + i.ToString();

            //Page.Controls.Add(tx);
            pnlTbxs.Controls.Add(tx);
            this.NumberOfControls++;
        }

        private void delSomeControl()
        {
            int numOfTbxs = pnlTbxs.Controls.Count;
            pnlTbxs.Controls.RemoveAt(numOfTbxs - 1);
            this.NumberOfControls--;
        }

        private void createElements()
        {
            System.Diagnostics.Debug.WriteLine(">> In createElements() numOfCheckBoxes=" + numOfCheckBoxes);

            Table tbl = new Table();
            TableRow tblRow0 = new TableRow();
            TableRow tblRow1 = new TableRow();
            TableRow tblRow2 = new TableRow();
            TableRow tblRow3 = new TableRow();
            TableRow tblRow4 = new TableRow();
            TableRow tblRow5 = new TableRow();
            TableRow tblRow6 = new TableRow();

            TableCell tblCell0_1 = new TableCell();
            Label lbl0_1 = new Label();
            lbl0_1.Text = "Quantity of CheckBoxes to Create";
            tblCell0_1.Controls.Add(lbl0_1);

            TableCell tblCell0_2 = new TableCell();
            TextBox tbx0_2 = new TextBox();
            tbx0_2.ID = "tbx0_2";
            tbx0_2.Text = "tbx0_2";
            tblCell0_2.Controls.Add(tbx0_2);

            tblRow0.Controls.Add(tblCell0_1);
            tblRow0.Controls.Add(tblCell0_2);

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

            //            tblRow4 = createRowOfCbxs(numOfCheckBoxes, "cbx4_");
            //            if (tblRow4 != null)
            //if (numOfCheckBoxes > 0)
            //{
                //                tbl.Controls.Add(tblRow4);
            //    createRowOfCbxs(numOfCheckBoxes, "cbx4_");
            //}

            TableCell tblCell4_0 = new TableCell();
            tblCell4_0.ColumnSpan = 2;
            tblCell4_0.Controls.Add(pnlCbxs);

            tblRow4.Controls.Add(tblCell4_0);

            TableCell tblCell5_1 = new TableCell();
            tblCell5_1.Text = "&nbsp;";

            TableCell tblCell5_2 = new TableCell();
            Button btnUpdateCbxs = new Button();
            btnUpdateCbxs.ID = "btnUpdateCbxs";
            btnUpdateCbxs.Text = "Update CheckBoxes";
            btnUpdateCbxs.Click += new EventHandler(btn_Click);
            tblCell5_2.Controls.Add(btnUpdateCbxs);

            tblRow5.Controls.Add(tblCell5_1);
            tblRow5.Controls.Add(tblCell5_2);

            TableCell tblCell6_0 = new TableCell();
            tblCell6_0.ColumnSpan = 2;
            tblCell6_0.Controls.Add(pnlTbxs);

            tblRow6.Controls.Add(tblCell6_0);

            tbl.Controls.Add(tblRow0);
            tbl.Controls.Add(tblRow1);
            tbl.Controls.Add(tblRow2);
            tbl.Controls.Add(tblRow3);
            tbl.Controls.Add(tblRow4);
            tbl.Controls.Add(tblRow5);
            tbl.Controls.Add(tblRow6);

            Panel1.Controls.Add(tbl);
        }

        private void createRowOfCbxs(int numOfCbxs, string prefix)
        {
            System.Diagnostics.Debug.WriteLine(">> In createRowOfCbxs(" + numOfCbxs + ", " + prefix + ")");

            Table aTable = new Table();
            TableRow tblRow = new TableRow();
            TableCell tblCell;
            CheckBox cbx;

            if (numOfCbxs > 0 && tblRow != null)
            {
//                tblRow = new TableRow();

                for (int i = 1; i <= numOfCbxs; i++)
                {
                    tblCell = new TableCell();
                    cbx = new CheckBox();
                    cbx.ID = prefix + i.ToString();
                    cbx.Text = i.ToString();
                    tblCell.Controls.Add(cbx);
                    tblRow.Controls.Add(tblCell);

                    //if (numOfCbxs > NumberOfControls)
                    //    addSomeControl();
                    //else if (numOfCbxs < NumberOfControls)
                    //    delSomeControl();

                    createControls(numOfCbxs);
                }

                aTable.Controls.Add(tblRow);
                pnlCbxs.Controls.Add(aTable);
            }
        }

        private int getIntFrom(Panel pnlID, string tbxID)
        {
//            throw new NotImplementedException();
            System.Diagnostics.Debug.WriteLine(">> In getIntFrom(" + pnlID.ID + ", " + tbxID + ")");

            TextBox tempTbx = pnlID.FindControl(tbxID) as TextBox;

            if (tempTbx != null)
            {
                int result;

                if (int.TryParse(tempTbx.Text, out result))
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            String myStringVariable = String.Empty;

            System.Diagnostics.Debug.WriteLine(">> In btn_Click");

            if (btn != null)
            {
                System.Diagnostics.Debug.WriteLine(">> In btn_Click btn.id=" + btn.ID);

                switch (btn.ID)
                {
                    case "btnTest": processBtnTest(btn, Panel1, "tbx1_2", "tbx0_2"); break;
                    case "btnUpdateCbxs": processBtnUpdateCbxs(Panel1, "tbx0_2", "cbx4_", "tbx1_2"); break;
                    default:
                        myStringVariable = btn.ID + " cannot be processed";
                        doAlert(myStringVariable);
                        break;
                }               
            }
            else
            {
                myStringVariable = "button not found";
                doAlert(myStringVariable);
//                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }
        }

        private void doAlert(String myStringVariable)
        {
            System.Diagnostics.Debug.WriteLine(">> In doAlert(" + myStringVariable + ")");
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        private void processBtnUpdateCbxs(Panel pnlID, string numOfCbxsTbxID, String cbxPrefix, string outTbxID)
        {
            System.Diagnostics.Debug.WriteLine(">> In processBtnUpdateCbxs(..)");

            int numOfCbxs, i;
            String myStringVariable = string.Empty;
            TextBox numOfCbxsTbx = getTbx(pnlID, numOfCbxsTbxID);
            TextBox outTbx = getTbx(pnlID, outTbxID);
            CheckBox cbx;

            if (numOfCbxsTbx != null && outTbx != null)
            {
                numOfCbxs = getIntFrom(pnlID, numOfCbxsTbxID);

                if (numOfCbxs > 0)
                {
                    outTbx.Text = "";

                    for (i = 1; i <= numOfCbxs; i++)
                    {
                        cbx = pnlID.FindControl(cbxPrefix + i.ToString()) as CheckBox;

                        if (cbx != null)
                        {
                            outTbx.Text += ", " + cbx.ID + "=" + cbx.Checked.ToString();
                        }
                    }
                }
            }
            else
            {
                if (numOfCbxsTbx == null)
                    myStringVariable = numOfCbxsTbxID;

                if (outTbx == null)
                    myStringVariable = myStringVariable + " " + outTbxID ;

                myStringVariable = myStringVariable + " cannot be found";

//                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                doAlert(myStringVariable);
            }
        }

        private void processBtnTest(Button btn, Panel pnlID, String tbxID, String numOfCbxsTbxID)
        {
            System.Diagnostics.Debug.WriteLine(">> In processBtnTest(..)");

            String myStringVariable = string.Empty;
            TextBox tempTbx = getTbx(pnlID, tbxID);
            TextBox numOfCbxsTbx = getTbx(pnlID, numOfCbxsTbxID);

            if (tempTbx != null && numOfCbxsTbx != null)
            {
                numOfCheckBoxes = getIntFrom(Panel1, numOfCbxsTbxID);
                createRowOfCbxs(numOfCheckBoxes, "cbx4_");

                tempTbx.Text = numOfCheckBoxes.ToString();
                tempTbx.Text += " " + btn.ID;
                tempTbx.Text += " cbx2_1=" + getCbxResult(Panel1, "cbx2_1");
                tempTbx.Text += " cbx2_2=" + getCbxResult(Panel1, "cbx2_2");

            }
            else
            {
                if (tempTbx == null)
                    myStringVariable = tbxID;

                if (numOfCbxsTbx == null)
                    myStringVariable = myStringVariable + " " + numOfCbxsTbxID;

                myStringVariable = myStringVariable + " cannot be found";

//                myStringVariable = tbxID + " not found";
//                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                doAlert(myStringVariable);

            }
        }

        private TextBox getTbx(Panel pnlID, string tbxID)
        {
            //            throw new NotImplementedException();
            System.Diagnostics.Debug.WriteLine(">> In getTbx(" + pnlID.ID + ", " + tbxID + ")");

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
            System.Diagnostics.Debug.WriteLine(">> In getCbxResult(" + pnlID.ID + ", " + cbxID + ")");

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