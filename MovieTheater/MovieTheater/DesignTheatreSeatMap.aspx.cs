using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class PanelTestPage : System.Web.UI.Page
    {
        const int maxRowCount = 26, maxSeatColCount = 50;
        int earlierPrivSeatColCount;
        Boolean boolAlreadyRecreated = false;

        //int rowCount = 0, seatColCount = 0;
        //List<int> newAisles = new List<int>();

        // a Property that manages a counter stored in ViewState
        protected int numOfChkBxs
        {
            get { return (int)ViewState["numOfChkBxs"]; }
            set { ViewState["numOfChkBxs"] = value; }
        }

        protected int rowCount
        {
            get { return (int)ViewState["rowCount"]; }
            set { ViewState["rowCount"] = value; }
        }

        protected int seatColCount
        {
            get { return (int)ViewState["seatColCount"]; }
            set { ViewState["seatColCount"] = value; }
        }

        protected List<int> aisles
        {
            get { return (List<int>)ViewState["Aisles"]; }
            set { ViewState["Aisles"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> Page_Load");

            //int rowCount, seatColCount;
            //List<int> aisles = new List<int>();

            if (!IsPostBack)
            {
                System.Diagnostics.Debug.WriteLine(">> if(!IsPostBack)");

                numOfChkBxs = 0;
                aisles = new List<int>();
                rowCount = 0;
                seatColCount = 0;
            }
            else
            {
                recreateChkBxs();
            }

            //rowCount = 26;
            //seatColCount = 16;
            //rowCount = rowCount;
            //seatColCount = seatColCount;

            //aisles.Add(1); // left-most
            //aisles.Add(5);
            //aisles.Add(13);
            //aisles.Add(seatColCount + 1); // right-most

            this.Panel2.Controls.Add(makeGridOfSeats(rowCount, seatColCount, aisles));

            //showGMohanCode();

            rowCount = Convert.ToInt32(lblRowCount.Text);
            seatColCount = Convert.ToInt32(lblSeatColCount.Text);

            updateLblTotalSeats();

            checkCheckBoxes();

            //showAisleCheckBoxes();

            //showNewAisles(); // disabled after production

        }

        private void recreateChkBxs()
        {
            System.Diagnostics.Debug.WriteLine(">> recreateChkBxs() numOfChkBxs=" + numOfChkBxs);

            showAisleCheckBoxes(numOfChkBxs);
        }

        private void updateLblTotalSeats()
        {
            lblTotalSeats.Text = (rowCount * seatColCount).ToString();
        }

        // disabled after production
        //private void showNewAisles()
        //{
        //    System.Diagnostics.Debug.WriteLine(">> showNewAisles");

        //    if (aisles != null)
        //    {
        //        tempLabel.Text = "";

        //        foreach (int i in aisles)
        //        {
        //            System.Diagnostics.Debug.WriteLine(">> showNewAisles i=" + i);
        //            tempLabel.Text += i.ToString() + " ";
        //        }
        //    }
        //}

        private void showAisleCheckBoxes(int privSeatColCount)
        {
            System.Diagnostics.Debug.WriteLine(">> showAisleCheckBoxes(" + privSeatColCount + ")");

            int i;

            Table tblAisleChkBoxes;
            TableRow tblRowAisleNumbers = null;
            TableRow tblRowAisleChkBoxes = null;
            TableCell tblCellAislePresentBlank;
            TableCell tblCellAislePresentText;
            TableCell tblCellAisleNumber;
            TableCell tblCellAisleChkBox;
            CheckBox aisleChkBox;

//            if ((privSeatColCount > 0) && (privSeatColCount == numOfChkBxs) && (pnlAisleCheckBoxes.Controls.Count == 0))
            if ((privSeatColCount > 0) && (privSeatColCount == numOfChkBxs) && (!boolAlreadyRecreated))
            {
                boolAlreadyRecreated = true;

                System.Diagnostics.Debug.WriteLine(">> showAisleCheckBoxes() privSeatColCount=" + privSeatColCount + " numOfChkBxs=" + numOfChkBxs);

                earlierPrivSeatColCount = privSeatColCount;

                tblAisleChkBoxes = prepareTblAisleChkBoxes();

                getTableRows(tblAisleChkBoxes, ref tblRowAisleNumbers, ref tblRowAisleChkBoxes);

                for (i = 1; i <= privSeatColCount; i++)
                {
                    System.Diagnostics.Debug.WriteLine(">> showAisleCheckBoxes() privSeatColCount=" + privSeatColCount + " i=" + i);

                    tblCellAisleNumber = new TableCell();
                    tblCellAisleChkBox = new TableCell();
                    aisleChkBox = new CheckBox();

                    tblCellAisleNumber.Text = i.ToString();

                    //aisleChkBox.ViewStateMode = System.Web.UI.ViewStateMode.Disabled;
                    aisleChkBox.ID = "Aisle_" + i.ToString();

                    if ((aisles != null) && (aisles.Contains(i)))
                    {
                        System.Diagnostics.Debug.WriteLine(">> showAisleCheckBoxes() privSeatColCount=" + privSeatColCount + " i=" + i + " newAisles.count=" + aisles.Count);

                        //tempLabel.Text += "sACB_" + i.ToString() + " "; // disabled after production

                        // aisle has been marked before
                        aisleChkBox.Checked = true;

                        tblCellAislePresentBlank = new TableCell();
                        tblCellAislePresentText = new TableCell();

                        tblCellAislePresentText.Text = "Aisle";
                        tblCellAislePresentText.CssClass = "tblCellAislePresentClass";

                        tblRowAisleNumbers.Cells.Add(tblCellAislePresentBlank);
                        tblRowAisleChkBoxes.Cells.Add(tblCellAislePresentText);
                    }

                    tblCellAisleChkBox.Controls.Add(aisleChkBox);

                    tblRowAisleNumbers.Cells.Add(tblCellAisleNumber);
                    tblRowAisleChkBoxes.Cells.Add(tblCellAisleChkBox);
                }

                tblAisleChkBoxes.Rows.Add(tblRowAisleNumbers);
                tblAisleChkBoxes.Rows.Add(tblRowAisleChkBoxes);

                pnlAisleCheckBoxes.Controls.Add(tblAisleChkBoxes);
            }
            else if ((privSeatColCount > numOfChkBxs) && (earlierPrivSeatColCount != privSeatColCount))
            {
                System.Diagnostics.Debug.WriteLine(">> showAisleCheckBoxes() else if (privSeatColCount(" + privSeatColCount + ") > numOfChkBxs(" + numOfChkBxs + ")), pnlAisleCheckBoxes.Controls.Count=" + pnlAisleCheckBoxes.Controls.Count);

                tblAisleChkBoxes = pnlAisleCheckBoxes.FindControl("tblAisleChkBoxes") as Table;
                Boolean boolRecreate = false;

                if (tblAisleChkBoxes == null)
                {
                    tblAisleChkBoxes = prepareTblAisleChkBoxes();
                    boolRecreate = true;
                }

                getTableRows(tblAisleChkBoxes, ref tblRowAisleNumbers, ref tblRowAisleChkBoxes);
                
                // add more CheckBoxes
                if ((tblRowAisleNumbers != null) && (tblRowAisleChkBoxes != null))
                {
                    int tempInt;

                    if (boolRecreate)
                    {
                        tempInt = 1;
                    } else {
                        tempInt = numOfChkBxs + 1;
                    }

                    for (i = tempInt; i <= privSeatColCount; i++)
                    {
                        // add one at a time
                        tblCellAisleNumber = new TableCell();
                        tblCellAisleChkBox = new TableCell();
                        aisleChkBox = new CheckBox();

                        tblCellAisleNumber.Text = i.ToString();

                        aisleChkBox.ID = "Aisle_" + i.ToString();

                        tblCellAisleChkBox.Controls.Add(aisleChkBox);

                        tblRowAisleNumbers.Cells.Add(tblCellAisleNumber);
                        tblRowAisleChkBoxes.Cells.Add(tblCellAisleChkBox);

                        if (i > numOfChkBxs)
                            numOfChkBxs++;
                    }

                    tblAisleChkBoxes.Rows.Add(tblRowAisleNumbers);
                    tblAisleChkBoxes.Rows.Add(tblRowAisleChkBoxes);

                    pnlAisleCheckBoxes.Controls.Add(tblAisleChkBoxes);
                }
            }
            else if ((privSeatColCount < numOfChkBxs) && (earlierPrivSeatColCount != privSeatColCount))
            {
                System.Diagnostics.Debug.WriteLine(">> showAisleCheckBoxes() else if (privSeatColCount(" + privSeatColCount + ") < numOfChkBxs(" + numOfChkBxs + "))");

                tblAisleChkBoxes = pnlAisleCheckBoxes.FindControl("tblAisleChkBoxes") as Table;
                //tblRowAisleNumbers = tblAisleChkBoxes.FindControl("tblRowAisleNumbers") as TableRow;
                //tblRowAisleChkBoxes = tblAisleChkBoxes.FindControl("tblRowAisleChkBoxes") as TableRow;

                getTableRows(tblAisleChkBoxes, ref tblRowAisleNumbers, ref tblRowAisleChkBoxes);

                // delete extra CheckBoxes

                for (i = numOfChkBxs; i > privSeatColCount; i--)
                {
                    // delete one at a time
                    tblRowAisleNumbers.Cells.RemoveAt(i - 1);
                    tblRowAisleChkBoxes.Cells.RemoveAt(i - 1);

                    numOfChkBxs--;
                }
            }
        }

        private static void getTableRows(Table tblAisleChkBoxes, ref TableRow tblRowAisleNumbers, ref TableRow tblRowAisleChkBoxes)
        {
            IEnumerator myEnumerator = tblAisleChkBoxes.Rows.GetEnumerator();

            if (tblAisleChkBoxes.Rows.IsSynchronized == false)
            {
                lock (tblAisleChkBoxes.Rows.SyncRoot)
                {
                    while (myEnumerator.MoveNext())
                    {
                        TableRow aTblRow = (TableRow)myEnumerator.Current;

                        if (aTblRow.ID == "tblRowAisleNumbers")
                        {
                            tblRowAisleNumbers = aTblRow;
                        }
                        else if (aTblRow.ID == "tblRowAisleChkBoxes")
                        {
                            tblRowAisleChkBoxes = aTblRow;
                        }
                    }
                }
            }
        }

        private Table prepareTblAisleChkBoxes()
        {
            System.Diagnostics.Debug.WriteLine(">> prepareTblAisleChkBoxes()");

            Table tblAisleChkBoxes = new Table();
            TableRow tblRowAisleNumbers = new TableRow();
            TableRow tblRowAisleChkBoxes = new TableRow();

            //tblAisleChkBoxes.HorizontalAlign = HorizontalAlign.Center;
            tblAisleChkBoxes.CssClass = "tblChkBoxesClass";
            tblAisleChkBoxes.ID = "tblAisleChkBoxes";

            tblRowAisleNumbers = new TableRow();
            tblRowAisleChkBoxes = new TableRow();

            tblRowAisleNumbers.CssClass = "tblRowAisleNumbersClass";
            tblRowAisleNumbers.ID = "tblRowAisleNumbers";

            tblRowAisleChkBoxes.CssClass = "tblRowAisleChkBoxesClass";
            tblRowAisleChkBoxes.ID = "tblRowAisleChkBoxes";

            tblAisleChkBoxes.Rows.Add(tblRowAisleNumbers);
            tblAisleChkBoxes.Rows.Add(tblRowAisleChkBoxes);

            return tblAisleChkBoxes;
        }

        private void showGMohanCode()
        {
            String aString
                = "<table>"
                + "<tbody>"
                + "<tr>"
                + "<td colspan=2 align=center valign=middle >"
                + "Ganesh Mohan"
                + "</td>"
                + "</tr>"
                + "<tr>"
                + "<td>"
                + "<input id='Text1' type='text' value='Ganesh Mohan' />"
                + "</td>"
                + "<td>"
                + "<a href=https://ganeshmohan.wordpress.com>"
                + "Hi This is Ganesh"
                + "</a>"
                + "</td>"
                + "</tr>"
                + "</tbody>"
                + "</table>"
                + "";

            Panel1.Controls.Add(new LiteralControl(aString));
        }

        private Table makeGridOfSeats(int rowCount, int seatColCount, List<int> aisles)
        {
            Table tbl = new Table();
            String imgBtnID = "";
            TableRow tblRow;
            TableCell tblCell;
            ImageButton anImgBtn;
            int i, j;

            tbl.CssClass = "tblClass";

            tbl.Rows.Add(getSeatsHeaderRow(seatColCount, aisles)); // for the bottom

            for (i = 1; i <= rowCount; i++)
            {
                tblRow = new TableRow();

                for (j = 1; j <= seatColCount; j++)
                {
                    tblCell = new TableCell();

                    foreach (int aisleNo in aisles)
                    {
                        if (aisleNo == j)
                        {
                            // aisle letters
                            tblCell.CssClass = "aisleCellClass";
                            tblCell.Text = getRowLetter(i);
                            tblRow.Cells.Add(tblCell);
                            tblCell = new TableCell();
                        }
                    }

                    // for seats
                    imgBtnID = getImgBtnID(i, j);
                    anImgBtn = getImageButton(imgBtnID);
                    tblCell.CssClass = "seatCellClass";
                    tblCell.Controls.Add(anImgBtn);

                    tblRow.Cells.Add(tblCell);

                    if ((j == seatColCount) && (aisles.Contains(seatColCount + 1)))
                    {
                        // add right-most row letter column
                        tblCell = new TableCell();
                        tblCell.CssClass = "aisleCellClass";
                        tblCell.Text = getRowLetter(i);
                        tblRow.Cells.Add(tblCell);
                    }
                }

                tbl.Rows.AddAt(0, tblRow);
            }

            tbl.Rows.AddAt(0, getSeatsHeaderRow(seatColCount, aisles)); // for the top

            if((rowCount > 0) && (seatColCount > 1))
                tbl.Rows.AddAt(0, getScreenRow(seatColCount + aisles.Count));

            return tbl;
        }

        private TableRow getScreenRow(int totalNumOfCols)
        {
            TableRow tblRow = new TableRow();
            TableCell tblCell;
            int i, screenSpan = totalNumOfCols;

            if (totalNumOfCols > 3)
            {
                for (i = 0; i < 2; i++)
                {
                    tblCell = new TableCell();
                    tblCell.Text = "&nbsp;";
                    tblRow.Controls.Add(tblCell);
                }

                screenSpan = totalNumOfCols - 2;
            }

            tblCell = new TableCell();
            tblCell.ColumnSpan = screenSpan;
            tblCell.Text = "Screen";
            tblCell.HorizontalAlign = HorizontalAlign.Center;
            tblCell.BorderColor = System.Drawing.Color.Black;
            tblCell.BorderStyle = BorderStyle.Dashed;
            tblCell.BorderWidth = 1;
            if(tblRow.Controls.Count>0)
                tblRow.Controls.AddAt(1, tblCell);
            else
                tblRow.Controls.Add(tblCell);

            return tblRow;
        }

        protected TableRow getSeatsHeaderRow(int seatColCount, List<int> aisles)
        {
            TableRow tblRow = new TableRow();
            TableCell tblCell;

            tblRow.CssClass = "tblHeaderRowClass";

            for (int i = 1; i <= seatColCount; i++)
            {
                tblCell = new TableCell();

                foreach (int aisleNo in aisles)
                {
                    if (aisleNo == i)
                    {
                        // add blank cell
                        tblCell.Text = "&nbsp;";
                        tblRow.Cells.Add(tblCell);
                        tblCell = new TableCell();
                    }

                }

                tblCell.Text = i.ToString();
                tblRow.Cells.Add(tblCell);

            }

            return tblRow;
        }

        protected String getRowLetter(int row)
        {
            String rowLetter = "", bigAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (row <= bigAlphabet.Length)
            {
                rowLetter = bigAlphabet[row - 1].ToString();
            }
            else
            {
                rowLetter = "NameError_" + row.ToString() + "_";
            }

            return rowLetter;
        }

        protected String getImgBtnID(int row, int column) {
            String imgBtnID = "";

            imgBtnID = getRowLetter(row);
            imgBtnID += column.ToString();

            return imgBtnID;
        }

        // disabled after production
//        protected void imgBtn_Click(object sender, ImageClickEventArgs e)
//        {
//            ImageButton imgBtn = sender as ImageButton;

//            //Button button = sender as Button;
//            if (imgBtn != null)
//            {
//                //get the id here
////                Label1.Text = imgBtn.ID;
//                imgBtn.BackColor = System.Drawing.Color.Red;

//                ClientScript.RegisterClientScriptBlock(this.GetType(), "img",
//                "<script type = 'text/javascript'>alert('" + imgBtn.ID.ToString() + " Clicked');</script>");
//            }
//        }

        protected ImageButton getImageButton(String imgBtnID)
        {
            //Image Button
            ImageButton img = new ImageButton();
            img.CssClass = "seatImgBtnClass";
            img.ID = imgBtnID;
            img.AlternateText = "ImageButton " + imgBtnID;
            img.ToolTip = imgBtnID;
            img.ImageUrl = "~/Images/ChairIconV06.png";
            //img.Click += new ImageClickEventHandler(imgBtn_Click); // disabled after production
            img.Enabled = false; // to prevent any postback to server as its not needed here in theatre design

            return img;
        }

        protected void btnDecreaseRowCount_Click(object sender, EventArgs e)
        {
            int rowCount;
            rowCount = Convert.ToInt32(lblRowCount.Text);

            if (rowCount > 0)
            {
                rowCount--;
                //rowCount = rowCount;
                lblRowCount.Text = rowCount.ToString();
            }

            checkCheckBoxes();
            showAisleCheckBoxes(seatColCount);
            //showNewAisles(); // disabled after production
            updateLblTotalSeats();
        }

        protected void btnIncreaseRowCount_Click(object sender, EventArgs e)
        {
            int rowCount;
            rowCount = Convert.ToInt32(lblRowCount.Text);

            if (rowCount < maxRowCount)
            {
                rowCount++;
                //rowCount = rowCount;
                lblRowCount.Text = rowCount.ToString();
            }

            checkCheckBoxes();
            showAisleCheckBoxes(seatColCount);
            //showNewAisles(); // disabled after production
            updateLblTotalSeats();
        }

        protected void btnDecreaseSeatCount_Click(object sender, EventArgs e)
        {
            int seatColCount;
            seatColCount = Convert.ToInt32(lblSeatColCount.Text);

            if (seatColCount > 0)
            {
                seatColCount--;
                //seatColCount = seatColCount;
                lblSeatColCount.Text = seatColCount.ToString();
            }

            checkCheckBoxes();
            showAisleCheckBoxes(seatColCount);
            //showNewAisles(); // disabled after production
            updateLblTotalSeats();
        }

        protected void btnIncreaseSeatCount_Click(object sender, EventArgs e)
        {
            int seatColCount;
            seatColCount = Convert.ToInt32(lblSeatColCount.Text);

            if (seatColCount < maxSeatColCount)
            {
                seatColCount++;
                //seatColCount = seatColCount;
                lblSeatColCount.Text = seatColCount.ToString();
            }

            checkCheckBoxes();
            showAisleCheckBoxes(seatColCount);
            //showNewAisles(); // disabled after production
            updateLblTotalSeats();
        }

        protected void btnUpdateAisleCheckboxes_Click(object sender, EventArgs e)
        {
            int aisleChkBoxCount;
            aisleChkBoxCount = seatColCount;
            List<int> tempAisle = new List<int>();
            CheckBox tempAisleChkBox;
            String chkBoxID = "";

            System.Diagnostics.Debug.WriteLine(">> btnUpdateAisleCheckboxes_Click() aisleChkBoxCount=" + aisleChkBoxCount);

            for (int i = 1; i <= aisleChkBoxCount; i++)
            {
                chkBoxID = "Aisle_" + i.ToString();
//                chkBoxID = "bodyContent_bodyCust_Aisle_" + i.ToString(); // didn't work either

                System.Diagnostics.Debug.WriteLine(">> btnUpdateAisleCheckboxes_Click() for " + chkBoxID);

                tempAisleChkBox = (CheckBox) pnlAisleCheckBoxes.FindControl(chkBoxID);

//                System.Diagnostics.Debug.WriteLine(">> btnUpdateAisleCheckboxes_Click() for " + chkBoxID + " " + tempAisleChkBox.ToString()); // nullPointerException

                if ((tempAisleChkBox != null) && (tempAisleChkBox.Checked))
                {
                    // not entering here due to null

                    System.Diagnostics.Debug.WriteLine(">> btnUpdateAisleCheckboxes_Click() for " + chkBoxID + " Checked");

                    //tempLabel.Text += " bUAC1_" + i.ToString(); // disabled after production

                    tempAisle.Add(i);
                }
            }

            if(aisles != null)
                aisles.Clear();

            foreach (int i in tempAisle)
            {
                System.Diagnostics.Debug.WriteLine(">> btnUpdateAisleCheckboxes_Click() tempAisle i=" + i);

                //tempLabel.Text += " bUAC2_" + i.ToString(); // disabled after production

                aisles.Add(i);
            }
            showAisleCheckBoxes(seatColCount);
            //showNewAisles();
//            updateLblTotalSeats();
        }

        private void checkCheckBoxes()
        {
            int aisleChkBoxCount = seatColCount;
            String chkBoxID = "";
            CheckBox tempChkBox;
            List<int> tempList = new List<int>();

            System.Diagnostics.Debug.WriteLine(">> checkCheckBoxes() aisleChkBoxCount=" + aisleChkBoxCount);

            for (int i = 1; i <= aisleChkBoxCount; i++)
            {
                chkBoxID = "Aisle_" + i.ToString();
                tempChkBox = pnlAisleCheckBoxes.FindControl(chkBoxID) as CheckBox;
                if ((tempChkBox != null) && (tempChkBox.Checked))
                {
                    System.Diagnostics.Debug.WriteLine(">> checkCheckBoxes() for " + chkBoxID + " Checked");
                    tempList.Add(i);
                }
            }

            aisles.Clear();

            foreach (int j in tempList)
            {
                System.Diagnostics.Debug.WriteLine(">> checkCheckBoxes() foreach " + j);
                aisles.Add(j);
            }

//            showAisleCheckBoxes();
            //showNewAisles(); // disabled after production
        }

    }
}