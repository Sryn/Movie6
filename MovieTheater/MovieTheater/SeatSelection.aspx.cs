using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class SeatSelection : System.Web.UI.Page
    {
        System.Drawing.Color seatColourFree = System.Drawing.Color.White;
        System.Drawing.Color seatColourBooked = System.Drawing.Color.Red;
        System.Drawing.Color seatColourOnHold = System.Drawing.Color.Yellow;
        System.Drawing.Color seatColourChosen = System.Drawing.Color.LightGreen;

        protected int roomMovieID
        {
            get { return (int)ViewState["roomMovieID"]; }
            set { ViewState["roomMovieID"] = value; }
            //get { return (int)Session["roomMovieID"]; }
            //set { Session["roomMovieID"] = value; }
        }

        protected int movieID
        {
            get { return (int)ViewState["movieID"]; }
            set { ViewState["movieID"] = value; }
        }

        protected int roomID
        {
            get { return (int)ViewState["roomID"]; }
            set { ViewState["roomID"] = value; }
        }

        protected DateTime roomMovieDate
        {
            get { return (DateTime)ViewState["roomMovieDate"]; }
            set { ViewState["roomMovieDate"] = value; }
        }

        protected TimeSpan roomMovieStartTime
        {
            get { return (TimeSpan)ViewState["roomMovieStartTime"]; }
            set { ViewState["roomMovieStartTime"] = value; }
        }

        protected TimeSpan roomMovieEndTime
        {
            get { return (TimeSpan)ViewState["roomMovieEndTime"]; }
            set { ViewState["roomMovieEndTime"] = value; }
        }

        protected String theatreName
        {
            get { return ViewState["theatreName"] as String; }
            set { ViewState["theatreName"] = value; }
        }

        protected String seatMapPattern
        {
            get { return ViewState["seatMapPattern"] as String; }
            set { ViewState["seatMapPattern"] = value; }
        }

        protected List<SeatMovie> listChosenSeatMovies
        {
            get { return Session["listChosenSeatMovies"] as List<SeatMovie>; }
            set { Session["listChosenSeatMovies"] = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> SeatSelection IsPostBack=" + IsPostBack);

            //MovieName.Text = Session["movName"].ToString();
            //string mnamstr = Session["movName"].ToString();
            //TheatreName.Text = Session["theatre"].ToString();
            //string thtstr = Session["theatre"].ToString(); 
            //Date.Text = Session["date"].ToString();            
            //Time.Text = Session["time"].ToString();

            if (!IsPostBack)
            {
                bool showExtraFields = false; // set this to false for deployment

                //Session["listChosenSeatMovies"] = new List<SeatMovie>();
                listChosenSeatMovies = new List<SeatMovie>();

                updateExtraFieldsVisibility(showExtraFields);

                getMovieScheduleDetails();
            }

            pnlSeatMap.Controls.Add(makeSeatGridFromPattern(seatMapPattern));
           
        }

        private void getMovieScheduleDetails()
        {
            System.Diagnostics.Debug.WriteLine(">> getMovieScheduleDetails()");
            //throw new NotImplementedException();

            if (Session["rmid"] != null)
            {
                roomMovieID = Convert.ToInt32(Session["rmid"]);

                RoomMovie chosenRoomMovie = null;

                try
                {
                    chosenRoomMovie = Business_Logic.RoomMovieLogic.getRoomMovieByPK(roomMovieID);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(">> getMovieScheduleDetails() error=" + ex.Message);
                }

                if (chosenRoomMovie != null)
                {
                    movieID = chosenRoomMovie.Movie_ID;
                    roomID = chosenRoomMovie.Room_ID;
                    roomMovieDate = chosenRoomMovie.Date;
                    roomMovieStartTime = chosenRoomMovie.StartTime;
                    roomMovieEndTime = chosenRoomMovie.EndTime;

                    try
                    {
                        seatMapPattern = Business_Logic.RoomLogic.getRoomByPK(roomID).Seat_Pattern;
                        theatreName = Business_Logic.RoomLogic.getRoomByPK(roomID).Theater.Theater_Name;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(">> ERROR: getMovieScheduleDetails() error=" + ex.Message);
                    }

                    populateFields();
                }
            }
        }

        private void populateFields()
        {
            System.Diagnostics.Debug.WriteLine(">> populateFields()");
            //throw new NotImplementedException();

            lblTheatreID.Text = roomMovieID.ToString();
            lblTheatreName.Text = theatreName;
            lblMovieID.Text = movieID.ToString();
            lblMovieScheduleDate.Text = roomMovieDate.ToShortDateString();
            lblMovieScheduleTime.Text = roomMovieStartTime.ToString(@"hh\:mm") + " - " + roomMovieEndTime.ToString(@"hh\:mm");
            lblRoomID.Text = roomID.ToString();
            lblSeatMapPattern.Text = seatMapPattern;

            try
            {
                lblMovieName.Text = Business_Logic.MovieLogic.getMovieByPK(movieID).Movie_Name;
                lblRoomName.Text = Business_Logic.RoomLogic.getRoomByPK(roomID).Room_Name;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(">> getMovieScheduleDetails() error=" + ex.Message);
            }
        }

        private void updateExtraFieldsVisibility(bool showExtraFields)
        {
            System.Diagnostics.Debug.WriteLine(">> updateExtraFieldsVisibility(" + showExtraFields.ToString() + ")");
            //throw new NotImplementedException();

            lblTheatreID.Visible = showExtraFields;
            lblMovieID.Visible = showExtraFields;
            lblRoomID.Visible = showExtraFields;
            lblTxtSeatMapPattern.Visible = showExtraFields;
            lblSeatMapPattern.Visible = showExtraFields;
            lblTxtChosenSeatID.Visible = showExtraFields;
            lblChosenSeatID.Visible = showExtraFields;
            lblTxtChosenSeatMovieID.Visible = showExtraFields;
            lblChosenSeatMovieID.Visible = showExtraFields;
        }

        private Table makeSeatGridFromPattern(string seatMapPattern)
        {
            System.Diagnostics.Debug.WriteLine(">> makeSeatGridFromPattern(\"" + seatMapPattern + "\")");
            //throw new NotImplementedException();

            Table gridTable = null;

            int rowCount, seatColCount;
            List<int> aisles;

            if (parseSeatMapPattern(seatMapPattern, out rowCount, out seatColCount, out aisles))
            {
                // successfully parsed seatMapPattern, now make table of seats grid
                gridTable = makeGridOfSeats(rowCount, seatColCount, aisles);
            }

            return gridTable;
        }

        private bool parseSeatMapPattern(string privSeatMapPattern, out int rowCount, out int seatColCount, out List<int> aisles)
        {
            System.Diagnostics.Debug.WriteLine(">> parseSeatMapPattern(\"" + privSeatMapPattern + "\")");
            //throw new NotImplementedException();

            string[] stringCommaSplit = privSeatMapPattern.Split(',');
            int arraySize = stringCommaSplit.Length;
            //int numOfChkBxs;
            int result = 0;
            bool success = false;

            rowCount = int.MinValue;
            seatColCount = int.MinValue;
            aisles = new List<int>();

            if (int.TryParse(stringCommaSplit[0].Trim(), out result))
            {
                rowCount = result;
                success = true;
            }

            result = 0;

            if (int.TryParse(stringCommaSplit[1].Trim(), out result))
            {
                seatColCount = result;
                //numOfChkBxs = result;
                success = true;
            }
            else
            {
                success = false;
            }

            if (arraySize > 2)
            {
                aisles.Clear();

                for (int i = 2; i < arraySize; i++)
                {
                    result = 0;
                    if (int.TryParse(stringCommaSplit[i].Trim(), out result))
                    {
                        if (result != 0)
                            aisles.Add(result);
                    }
                }
            }

            //showParseResults();
            return success;
        }

        private Table makeGridOfSeats(int rowCount, int seatColCount, List<int> aisles)
        {
            System.Diagnostics.Debug.WriteLine(">> makeGridOfSeats( rowCount=" + rowCount + " seatColCount=" + seatColCount + " aisles.Count=" + aisles.Count + ")");

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

            if ((rowCount > 0) && (seatColCount > 1))
                tbl.Rows.AddAt(0, getScreenRow(seatColCount + aisles.Count));

            return tbl;
        }

        protected TableRow getSeatsHeaderRow(int seatColCount, List<int> aisles)
        {
            System.Diagnostics.Debug.WriteLine(">> getSeatsHeaderRow( seatColCount=" + seatColCount + " aisles.Count=" + aisles.Count + ")");

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
                tblCell.HorizontalAlign = HorizontalAlign.Center;
                tblRow.Cells.Add(tblCell);

            }

            return tblRow;
        }

        protected String getRowLetter(int row)
        {
            System.Diagnostics.Debug.WriteLine(">> getRowLetter( row=" + row + ")");

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

        protected String getImgBtnID(int row, int column)
        {
            System.Diagnostics.Debug.WriteLine(">> getImgBtnID( row=" + row + " column=" + column + ")");

            String imgBtnID = "";

            imgBtnID = getRowLetter(row);
            imgBtnID += column.ToString();

            return imgBtnID;
        }

        protected ImageButton getImageButton(String imgBtnID)
        {
            System.Diagnostics.Debug.WriteLine(">> getImageButton( imgBtnID=" + imgBtnID + ")");

            int seatID, seatMovieID;
            bool imgBtnEnabled = false;
            System.Drawing.Color seatColour = seatColourOnHold;

            //Image Button
            ImageButton img = new ImageButton();
            img.CssClass = "seatImgBtnClass";
            img.ID = imgBtnID;
            img.AlternateText = "ImageButton " + imgBtnID;
            img.ToolTip = imgBtnID;
            img.ImageUrl = "~/Images/ChairIconV06.png";
            img.Click += new ImageClickEventHandler(imgBtn_Click);

            img.Width = 40;
            img.Height = 40;

            getImgBtnStatusFromSeatTable(imgBtnID, out imgBtnEnabled, out seatColour, out seatID);

            if (seatID > 0)
            {
                img.CommandName = seatID.ToString();

                // check this particular seat status in SeatMovie table
                seatMovieID = getImgBtnStatusFromSeatMovieTable(seatID, out imgBtnEnabled, out seatColour);

                if (seatMovieID > 0)
                    img.CommandArgument = seatMovieID.ToString();
            }

            img.Enabled = imgBtnEnabled;
            img.BackColor = seatColour;

            return img;
        }

        // returns any SeatMovie if it exists and is the only one, or the last in the list that is both unoccupied and not onHold (?)
        private int getImgBtnStatusFromSeatMovieTable(int seatID, out bool imgBtnEnabled, out System.Drawing.Color seatColour)
        {
            System.Diagnostics.Debug.WriteLine(">> getImgBtnStatusFromSeatMovieTable( seatID=" + seatID + " .. )");
            //throw new NotImplementedException();

            int rtnSeatMovieID = int.MinValue;
            imgBtnEnabled = true;
            seatColour = seatColourFree;
            List<SeatMovie> seatMovieList;
            List<SeatMovie> seatMovieListInner = new List<SeatMovie>();
            SeatMovie freeSeatMovie = null;

            try
            {
                seatMovieList = Business_Logic.RoomMovieLogic.getSeatMovieListByJustRoomMovie(roomMovieID);

                foreach (SeatMovie aSeatMovie in seatMovieList)
                {
                    if (aSeatMovie.Seat_ID == seatID)
                    {
                        seatMovieListInner.Add(aSeatMovie);
                    }
                }

                if (seatMovieListInner.Count > 0)
                {
                    // some seats are either booked or  back to unoccupied (free)
                    freeSeatMovie = seatMovieListInner.ElementAt(0);

                    if (seatMovieListInner.Count == 1)
                    {
                        // chk this particular seat
                        processSeatMovie(seatMovieListInner.ElementAt(0), out imgBtnEnabled, out seatColour);
                    }
                    else
                    {
                        foreach (SeatMovie aSeatMovie2 in seatMovieListInner)
                        {
                            processSeatMovie(aSeatMovie2, out imgBtnEnabled, out seatColour);

                            if (imgBtnEnabled == true && seatColour == seatColourFree)
                                freeSeatMovie = aSeatMovie2;
                        }
                    }

                    rtnSeatMovieID = freeSeatMovie.SeatMovie_ID;
                }
                else
                {
                    // this particular seat hasn't been 'touched' yet
                    imgBtnEnabled = true;
                    seatColour = seatColourFree;
                }

            } catch(Exception ex) {
                System.Diagnostics.Debug.WriteLine(">> ERROR: getImgBtnStatusFromSeatMovieTable ex.Message=" + ex.Message);
            }

            return rtnSeatMovieID;

        }

        private void processSeatMovie(SeatMovie seatMovie, out bool imgBtnEnabled, out System.Drawing.Color seatColour)
        {
            System.Diagnostics.Debug.WriteLine(">> processSeatMovie( seatMovieID=" + seatMovie.SeatMovie_ID + " .. )");
            //throw new NotImplementedException();

            imgBtnEnabled = true;
            seatColour = seatColourFree;

            if (seatMovie.Active_Indicator == true)
            {
                if (seatMovie.Occupied == true)
                {
                    // Booked
                    imgBtnEnabled = false;
                    seatColour = seatColourBooked;
                }
                else
                {
                    // Free
                    imgBtnEnabled = true;
                    seatColour = seatColourFree;
                }
            }
            else
            {
                if (seatMovie.Occupied == true)
                {
                    // OnHold
                    imgBtnEnabled = false;
                    seatColour = seatColourOnHold;
                }
                else
                {
                    // chosen
                    imgBtnEnabled = true;
                    //seatColour = seatColourChosen;
                    seatColour = seatColourFree; // ignore the chosen colour
                }

            }

        }

        private void getImgBtnStatusFromSeatTable(String imgBtnID, out bool imgBtnEnabled, out System.Drawing.Color seatColour, out int seatID)
        {
            System.Diagnostics.Debug.WriteLine(">> getImgBtnStatusFromSeatTable( imgBtnID=" + imgBtnID + " .. )");
            //throw new NotImplementedException();
            imgBtnEnabled = false;
            seatColour = seatColourOnHold;
            bool seatExistence = false;
            bool seatActiveInd = false;
            seatID = int.MinValue;

            int rowNum, colNum;

            if (getRowColFromString(imgBtnID, out rowNum, out colNum))
            {
                // got valid rowNum and colNum
                // get both existence & Active_Indicator of this seat in dbo.Seat using roomID, rowNum & colNum
                if (getSeatStatus(roomID, rowNum, colNum, out seatExistence, out seatActiveInd, out seatID))
                {
                    if (seatExistence && seatActiveInd)
                    {
                        // both true
                        imgBtnEnabled = true;
                        seatColour = seatColourFree;
                    }
                }
            }

        }

        private bool getSeatStatus(int roomID, int rowNum, int colNum, out bool seatExistence, out bool seatActiveInd, out int seatID)
        {
            System.Diagnostics.Debug.WriteLine(">> getSeatStatus( roomID=" + roomID + " rowNum=" + rowNum + " colNum=" + colNum + ")");
            //throw new NotImplementedException();

            bool rtnBool = false;
            seatExistence = false;
            seatActiveInd = false;
            seatID = int.MinValue;

            try
            {
                Seat aSeat = Business_Logic.SeatLogic.getSeatByRoomID_row_col(roomID, rowNum, colNum);

                if (aSeat != null)
                {
                    seatExistence = true;
                    seatActiveInd = aSeat.Active_Indicator;

                    // return a valid seatID only if both the seat exists and active=true
                    if (seatActiveInd)
                        seatID = aSeat.Seat_ID;

                    rtnBool = true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(">> ERROR: getSeatStatus ex.Message=" + ex.Message);
            }

            return rtnBool;
        }

        private bool getRowColFromString(string imgBtnID, out int rowNum, out int colNum)
        {
            System.Diagnostics.Debug.WriteLine(">> getRowColFromString( imgBtnID=" + imgBtnID + " .. )");
            //throw new NotImplementedException();

            const String bigAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            rowNum = int.MinValue;
            colNum = int.MinValue;
            int result;
            bool rtnBool = false;

            char strRow = imgBtnID[0];
            rowNum = bigAlphabet.IndexOf(strRow) + 1;

            if (rowNum > 0)
                rtnBool = true;

            if (int.TryParse(imgBtnID.Substring(1), out result))
            {
                colNum = result;
                rtnBool = true;
            }
            else
            {
                rtnBool = false;
            }

            return rtnBool;
        }

        private TableRow getScreenRow(int totalNumOfCols)
        {
            System.Diagnostics.Debug.WriteLine(">> getScreenRow( totalNumOfCols=" + totalNumOfCols + ")");

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
            if (tblRow.Controls.Count > 0)
                tblRow.Controls.AddAt(1, tblCell);
            else
                tblRow.Controls.Add(tblCell);

            return tblRow;
        }

        protected void imgBtn_Click(object sender, ImageClickEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> imgBtn_Click( sender=" + sender.ToString() + ", e="+e.ToString()+")");

            ImageButton imgBtn = sender as ImageButton;

            //Button button = sender as Button;
            if (imgBtn != null)
            {
                //get the id here
                //                Label1.Text = imgBtn.ID;

                lblChosenSeatID.Text = imgBtn.CommandName;
                lblChosenSeatMovieID.Text = imgBtn.CommandArgument;

                if (imgBtn.BackColor == seatColourFree)
                {
                    processFreeSeat(imgBtn);
                }
                else if (imgBtn.BackColor == seatColourChosen)
                {
                    processChosenSeat(imgBtn);
                }

                //imgBtn.BackColor = seatColourBooked;

                //ClientScript.RegisterClientScriptBlock(this.GetType(), "img",
                //"<script type = 'text/javascript'>alert('" + imgBtn.ID.ToString() + " Clicked');</script>");
            }
        }

        private void processChosenSeat(ImageButton imgBtn)
        {
            System.Diagnostics.Debug.WriteLine(">> processChosenSeat( imgBtn.ID=" + imgBtn.ID + ")");
            //throw new NotImplementedException();

            imgBtn.BackColor = seatColourFree;

            removeSeatFromChosenList(imgBtn);
        }

        private void removeSeatFromChosenList(ImageButton imgBtn)
        {
            System.Diagnostics.Debug.WriteLine(">> removeSeatFromChosenList( imgBtn.ID=" + imgBtn.ID + ")");
            //throw new NotImplementedException();
            //int seatID = int.MinValue;
            //Seat aSeat = null;

            int seatMovieID = int.MinValue;
            SeatMovie aSeatMovie = null;


            if (imgBtn.CommandArgument != string.Empty)
            {
                System.Diagnostics.Debug.WriteLine(">> removeSeatFromChosenList( imgBtn.ID=" + imgBtn.ID + ") if (imgBtn.CommandArgument != string.Empty)");
                // SeatMovieID maybe available
                if (int.TryParse(imgBtn.CommandArgument, out seatMovieID))
                {
                    System.Diagnostics.Debug.WriteLine(">> removeSeatFromChosenList( imgBtn.ID=" + imgBtn.ID + ") if (int.TryParse(imgBtn.CommandArgument, out seatMovieID))");
                    try
                    {
                        aSeatMovie = Business_Logic.RoomMovieLogic.getSeatMovieByPK(seatMovieID);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(">> ERROR: removeSeatFromChosenList ex.Message=" + ex.Message);
                    }

                    if(aSeatMovie != null) {
                        System.Diagnostics.Debug.WriteLine(">> removeSeatFromChosenList( imgBtn.ID=" + imgBtn.ID + ") if(aSeatMovie != null)");

                        int foundIdx = int.MinValue;

                        foreach (SeatMovie aSeatMovie2 in listChosenSeatMovies)
                        {
                            if (aSeatMovie.SeatMovie_ID == aSeatMovie2.SeatMovie_ID)
                            {
                                System.Diagnostics.Debug.WriteLine(">> removeSeatFromChosenList( imgBtn.ID=" + imgBtn.ID + ") if (aSeatMovie.SeatMovie_ID == aSeatMovie2.SeatMovie_ID)");
                                foundIdx = listChosenSeatMovies.IndexOf(aSeatMovie2);
                                break;
                            }
                        }

                        if (foundIdx != int.MinValue)
                        {
                            System.Diagnostics.Debug.WriteLine(">> removeSeatFromChosenList( imgBtn.ID=" + imgBtn.ID + ") if (foundIdx != 0)");
                            listChosenSeatMovies.RemoveAt(foundIdx);
                            updateLblChosenSeats();
                        }

                        //if (listChosenSeatMovies.Contains(aSeatMovie))
                        //{
                        //    System.Diagnostics.Debug.WriteLine(">> removeSeatFromChosenList( imgBtn.ID=" + imgBtn.ID + ") if(aSeatMovie != null && listChosenSeatMovies.Contains(aSeatMovie))");
                        //    if (listChosenSeatMovies.Remove(aSeatMovie))
                        //    {
                        //        System.Diagnostics.Debug.WriteLine(">> removeSeatFromChosenList( imgBtn.ID=" + imgBtn.ID + ") if (listChosenSeatMovies.Remove(aSeatMovie))");
                        //        updateLblChosenSeats();
                        //    }
                        //}
                        //else
                        //{
                        //    System.Diagnostics.Debug.WriteLine(">> removeSeatFromChosenList( imgBtn.ID=" + imgBtn.ID + ") if(aSeatMovie != null && listChosenSeatMovies.Contains(aSeatMovie)) else");
                        //    // not yet in list, therefore just update lblChosenSeats
                        //    updateLblChosenSeats();
                        //}
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(">> removeSeatFromChosenList ERROR: Cannot Parse imgBtn.CommandArgument=" + imgBtn.CommandArgument);
                }

            }
            //else if (imgBtn.CommandName != null)  // this shouldn't be the case because every SeatMovie item in listChosenSeatMovies should have by now a SeatMovie instance 
            //{                                     // and that instance SeatMovieID should have been saved to imgBtn.CommandArgument
            //    // SeatID maybe available
            //    if (int.TryParse(imgBtn.CommandName, out seatID))
            //    {
                    
            //    }
            //    else
            //    {
            //        System.Diagnostics.Debug.WriteLine(">> removeSeatFromChosenList ERROR: Cannot Parse imgBtn.CommandName=" + imgBtn.CommandName);
            //    }
            //}
            else
            {
                // ERROR?! cannot get either a SeatMovie or a Seat instance associated with this imgBtn
                System.Diagnostics.Debug.WriteLine(">> removeSeatFromChosenList ERROR: cannot get either a SeatMovie instance associated with this imgBtn.ID=" + imgBtn.ID);
            }

        }

        private void processFreeSeat(ImageButton imgBtn)
        {
            System.Diagnostics.Debug.WriteLine(">> processFreeSeat( imgBtn.ID=" + imgBtn.ID + ")");
            //throw new NotImplementedException();

            imgBtn.BackColor = seatColourChosen;

            addSeatToChosenList(imgBtn);
        }

        private void addSeatToChosenList(ImageButton imgBtn)
        {
            System.Diagnostics.Debug.WriteLine(">> addSeatToChosenList( imgBtn.ID=" + imgBtn.ID + ")");
            //throw new NotImplementedException();
            SeatMovie aSeatMovie = null;
            int aSeatMovieID = int.MinValue, seatID;

            if (imgBtn.CommandArgument == string.Empty)
            {
                System.Diagnostics.Debug.WriteLine(">> addSeatToChosenList( imgBtn.ID=" + imgBtn.ID + ") if (imgBtn.CommandArgument == string.Empty)");
                // no SeatMovie instance for this RoomMovie hasn't been made before
                // therefore make new SeatMovie

                if (int.TryParse(imgBtn.CommandName, out seatID))
                {
                    System.Diagnostics.Debug.WriteLine(">> addSeatToChosenList( imgBtn.ID=" + imgBtn.ID + ") if (int.TryParse(imgBtn.CommandName, out seatID))");
                    aSeatMovie = new SeatMovie();

                    aSeatMovie.Seat_ID = seatID;
                    aSeatMovie.RoomMovie_ID = roomMovieID;
                    aSeatMovie.Occupied = false;
                    aSeatMovie.Active_Indicator = true;
                    aSeatMovie.Update_Datetime = DateTime.Now;

                    try
                    {
                        aSeatMovieID = Business_Logic.RoomMovieLogic.insertNewSeatMovie(aSeatMovie);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(">> ERROR: addSeatToChosenList ex.Message=" + ex.Message);
                    }

                    if (aSeatMovieID > 0)
                    {
                        System.Diagnostics.Debug.WriteLine(">> addSeatToChosenList( imgBtn.ID=" + imgBtn.ID + ") if (aSeatMovieID > 0)");
                        // successful insertion into SeatMovie
                        aSeatMovie.SeatMovie_ID = aSeatMovieID;
                        imgBtn.CommandArgument = aSeatMovieID.ToString();
                        lblChosenSeatMovieID.Text = imgBtn.CommandArgument;

                        if (!listChosenSeatMovies.Contains(aSeatMovie))
                        {
                            System.Diagnostics.Debug.WriteLine(">> addSeatToChosenList( imgBtn.ID=" + imgBtn.ID + ") if (!listChosenSeatMovies.Contains(aSeatMovie))");
                            listChosenSeatMovies.Add(aSeatMovie);
                            updateLblChosenSeats();
                        }
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(">> addSeatToChosenList( imgBtn.ID=" + imgBtn.ID + ") if (int.TryParse(imgBtn.CommandName, out seatID)) else");
                    // ERROR?!
                    // all free seats should have their own associated seatID
                    System.Diagnostics.Debug.WriteLine(">> addSeatToChosenList ERROR: Cannot Parse imgBtn.CommandName=" + imgBtn.CommandName);
                }
                
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(">> addSeatToChosenList( imgBtn.ID=" + imgBtn.ID + ") if (imgBtn.CommandArgument == null) else");
                // there exists a SeatMovie instance for this RoomMovie already
                if (int.TryParse(imgBtn.CommandArgument, out aSeatMovieID))
                {
                    System.Diagnostics.Debug.WriteLine(">> addSeatToChosenList( imgBtn.ID=" + imgBtn.ID + ") if (int.TryParse(imgBtn.CommandArgument, out aSeatMovieID))");
                    try
                    {
                        aSeatMovie = Business_Logic.RoomMovieLogic.getSeatMovieByPK(aSeatMovieID);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(">> ERROR: addSeatToChosenList ex.Message=" + ex.Message);
                    }

                    if (aSeatMovie != null)
                    {
                        System.Diagnostics.Debug.WriteLine(">> addSeatToChosenList( imgBtn.ID=" + imgBtn.ID + ") if (aSeatMovie != null)");
                        // found but have to check if it already exists in the list

                        if (!listChosenSeatMovies.Contains(aSeatMovie))
                        {
                            System.Diagnostics.Debug.WriteLine(">> addSeatToChosenList( imgBtn.ID=" + imgBtn.ID + ") if (!listChosenSeatMovies.Contains(aSeatMovie))");
                            listChosenSeatMovies.Add(aSeatMovie);
                            updateLblChosenSeats();
                        }
                    }
                }

            }
        }

        private void updateLblChosenSeats()
        {
            System.Diagnostics.Debug.WriteLine(">> updateLblChosenSeats()");
            //throw new NotImplementedException();

            lblListOfChosenSeats.Text = "";
            String seatName = String.Empty;
            bool showComma = false;

            foreach (SeatMovie aSeatMovie in listChosenSeatMovies)
            {
                try
                {
                    seatName = Business_Logic.SeatLogic.getSeatByPK(aSeatMovie.Seat_ID).Seat_Name;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(">> ERROR: updateLblChosenSeats ex.Message=" + ex.Message);
                }

                if (seatName != String.Empty)
                {
                    if (showComma)
                        lblListOfChosenSeats.Text += ", ";

                    showComma = true;
                    
                    lblListOfChosenSeats.Text += seatName;
                }
            }
        }

        protected void btnPrevStep_Click(object sender, EventArgs e)
        {
            // clear this specific page caches and then redirect back to MovieSchedule
            ViewState.Remove("roomMovieID");
            ViewState.Remove("movieID");
            ViewState.Remove("roomID");
            ViewState.Remove("roomMovieDate");
            ViewState.Remove("roomMovieStartTime");
            ViewState.Remove("roomMovieEndTime");
            ViewState.Remove("theatreName");
            ViewState.Remove("seatMapPattern");
            Session.Remove("listChosenSeatMovies");

            Response.Redirect("~/MovieSchedule.aspx");
        }

        protected void btnNextStep_Click(object sender, EventArgs e)
        {
            // check the current availability of each seat in chosenSeatList
            //   if all still available, proceed forward
            //     set all those seats to OnHold (occupied=true, active=false)
            //     convert all available data to booking specific data
            //     proceed to Confirm.aspx
            //   if at least one is now unavailable
            //     msg user
            //     clear offending seat from chosenSeatList
            //     and refresh this page

            List<SeatMovie> currentOccupiedFalseList = null;
            int chosenSeatMovieCount = listChosenSeatMovies.Count;
            bool placeOnHoldOK = false;
            String errorMsg = ">>> ERROR:";

            if(chosenSeatMovieCount > 0) {
                try{
                    currentOccupiedFalseList = Business_Logic.RoomMovieLogic.getSeatMovieListByRoomMovieAndOccupiedFalse(roomMovieID);
                } catch(Exception ex) {
                    System.Diagnostics.Debug.WriteLine(">> ERROR: btnNextStep_Click ex.Message=" + ex.Message);
                    errorMsg += " Cannot get any current unoccupied seats.";
                }

                if(currentOccupiedFalseList.Count > 0) {
                    foreach(SeatMovie aSeatMovie in currentOccupiedFalseList) {
                        foreach (SeatMovie aSeatMovie2 in listChosenSeatMovies)
                        {
                            if (aSeatMovie.SeatMovie_ID == aSeatMovie2.SeatMovie_ID)
                            {
                                chosenSeatMovieCount--;

                                if (chosenSeatMovieCount == 0)
                                    break;
                            }
                        }
                    }

                    if (chosenSeatMovieCount < 1)
                    {
                        // all still free
                        // now make all chosenSeatMovie OnHold
                        foreach (SeatMovie aSeatMovie3 in listChosenSeatMovies)
                        {
                            try
                            {
                                placeOnHoldOK = Business_Logic.RoomMovieLogic.OnHoldSeat(roomMovieID, aSeatMovie3.SeatMovie_ID);
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine(">> ERROR: btnNextStep_Click ex.Message=" + ex.Message);
                                errorMsg += " Cannot place at least one seat OnHold.";
                            }

                            if (!placeOnHoldOK)
                                break;
                        }

                        if (!placeOnHoldOK)
                        {
                            // free all seats in the list
                            foreach (SeatMovie aSeatMovie4 in listChosenSeatMovies)
                            {
                                try
                                {
                                    Business_Logic.RoomMovieLogic.FreeSeat(aSeatMovie4.SeatMovie_ID);
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine(">> ERROR: btnNextStep_Click ex.Message=" + ex.Message);
                                    errorMsg += " Cannot free up all chosen seats after error.";
                                }
                            }
                        }
                    }
                    else
                    {
                        // at least one is not free anymore
                    }

                } else {
                    // no current free seats, therefore ERROR
                }

                if (placeOnHoldOK)
                {
                    // prepare confirm data
                    // and then redirect
                    double oneTktPrice = double.MinValue, totalPrice;

                    try
                    {
                        oneTktPrice = Business_Logic.RoomMovieLogic.getTicketPrice(roomMovieID);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(">> ERROR: btnNextStep_Click ex.Message=" + ex.Message);
                        errorMsg += " Cannot get a valid ticket price.";
                    }

                    if (oneTktPrice != double.MinValue)
                    {
                        totalPrice = oneTktPrice * listChosenSeatMovies.Count;
                        Session["totalPrice"] = totalPrice;

                        Response.Redirect("~/Confirm.aspx");
                    }
                    else
                    {
                        Session["totalPrice"] = 0.0;

                        Response.Redirect("~/Confirm.aspx");
                    }
                }
            }
            else
            {
                errorMsg += " No seat has been selected.";
            }

            listChosenSeatMovies.Clear();
            updateLblChosenSeats();

            errorMsg += " Your seat selection has been cleared.";

            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + errorMsg + "');", true);

        }

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    int s = 1;
        //    List<int> seats = new List<int>();
        //    seats.Add(s);

        //}

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    List<int> seats = new List<int>();
        //    seats.Add(Convert.ToInt32( DropDownList1.SelectedItem.Text));
        //    DateTime datstr = Convert.ToDateTime(Session["date"].ToString());
        //    TimeSpan timstr =  TimeSpan.Parse(Session["time"].ToString());
        //    int id = Business_Logic.RoomMovieLogic.getRoomMovieId(datstr,timstr);
        //    int cid = Convert.ToInt32(Session["uid"].ToString());
            
        //    Business_Logic.BookingLogic.insertBooking(cid,id,seats);

        //    Response.Redirect("Confirm.aspx");
           
        //}

        //protected void TextBox1_TextChanged(object sender, EventArgs e)
        //{

        //}

        //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
    }
}