using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTheater
{
    public partial class Confirm : System.Web.UI.Page
    {
        protected int roomMovieID
        {
            get { return (int)ViewState["roomMovieID"]; }
            set { ViewState["roomMovieID"] = value; }
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

        protected int customerID
        {
            get { return Convert.ToInt32(ViewState["customerID"]); }
            set { ViewState["customerID"] = value; }
        }

        protected Customer customer
        {
            get { return ViewState["customer"] as Customer; }
            set { ViewState["customer"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Booking book = new Booking();
            //Business_Logic.BookingLogic.getBookingByPK();
            if (!IsPostBack)
            {
                bool showExtraFields = false; // set this to false for deployment

                //Session["listChosenSeatMovies"] = new List<SeatMovie>();

                updateExtraFieldsVisibility(showExtraFields);

                getMovieScheduleDetails();
                getCustomerDetails();
                showPricing();
            }
        }

        private void showPricing()
        {
            //throw new NotImplementedException();
            if (Session["totalPrice"] != null)
            {
                Double price = Convert.ToDouble(Session["totalPrice"]);
                lblTotalPrice.Text = price.ToString("C2");
            }

            Double oneTktPrice = Double.MinValue;

            try
            {
                oneTktPrice = Business_Logic.RoomMovieLogic.getTicketPrice(roomMovieID);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(">>> ERROR: getCustomerDetails() error=" + ex.Message);
            }

            if (oneTktPrice != Double.MinValue)
            {
                if (Session["listChosenSeatMovies"] != null)
                {
                    List<SeatMovie> seatMovieList = Session["listChosenSeatMovies"] as List<SeatMovie>;
                    int numTkts = seatMovieList.Count;

                    lblCalculation.Text = oneTktPrice.ToString("C2") + " * " + numTkts.ToString();
                }
            }
        }

        private void getCustomerDetails()
        {
            System.Diagnostics.Debug.WriteLine(">> getCustomerDetails()");
            //throw new NotImplementedException();

            if (Session["uid"] != null)
            {
                //Customer aCustomer = null;
                customerID = Convert.ToInt32(Session["uid"]);
                lblCustomerID.Text = customerID.ToString();

                //try
                //{
                //    aCustomer = Business_Logic.CustomerLogic.getCustomerByPK(customerID);
                //}
                //catch (Exception ex)
                //{
                //    System.Diagnostics.Debug.WriteLine(">>> ERROR: getCustomerDetails() error=" + ex.Message);
                //}

                //if (aCustomer != null)
                //{
                //    customer = aCustomer;
                //    //lblCustomerID.Text = customer.Customer_ID.ToString();
                //    lblCustomerName.Text = customer.Customer_Name;
                //}
            }

            if (Session["uname"] != null)
            {
                lblCustomerName.Text = Session["uname"] as String;
            }
        }

        private void getMovieScheduleDetails()
        {
            System.Diagnostics.Debug.WriteLine(">> getMovieScheduleDetails()");
            //throw new NotImplementedException();

            if (Session["rmid"] != null)
            {
                roomMovieID = Convert.ToInt32(Session["rmid"]);
                lblRoomMovieID.Text = roomMovieID.ToString();

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

            List<Seat> seatList = null;

            lblTheatreName.Text = theatreName;
            lblMovieScheduleDate.Text = roomMovieDate.ToShortDateString();
            lblMovieScheduleTime.Text = roomMovieStartTime.ToString(@"hh\:mm") + " - " + roomMovieEndTime.ToString(@"hh\:mm");
            lblRoomID.Text = roomID.ToString();

            seatList = getChosenSeatList();

            try
            {
                lblMovieName.Text = Business_Logic.MovieLogic.getMovieByPK(movieID).Movie_Name;
                lblRoomName.Text = Business_Logic.RoomLogic.getRoomByPK(roomID).Room_Name;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(">> populateFields() error=" + ex.Message);
            }
        }

        private List<Seat> getChosenSeatList()
        {
            int seatID;
            Seat aSeat = null;
            List<Seat> seatList = new List<Seat>();

            if (Session["listChosenSeatMovies"] != null)
            {
                List<SeatMovie> seatMovieList = Session["listChosenSeatMovies"] as List<SeatMovie>;

                bool showComma = false;
                lblListOfChosenSeats.Text = "";

                foreach (SeatMovie aSeatMovie in seatMovieList)
                {
                    if (showComma)
                        lblListOfChosenSeats.Text += ", ";

                    showComma = true;

                    seatID = aSeatMovie.Seat_ID;

                    try
                    {
                        aSeat = Business_Logic.SeatLogic.getSeatByPK(seatID);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(">> getChosenSeatList() error=" + ex.Message);
                    }

                    if (aSeat != null)
                    {
                        seatList.Add(aSeat);
                        lblListOfChosenSeats.Text += aSeat.Seat_Name;
                    }
                }
            }

            return seatList;
        }

        private void updateExtraFieldsVisibility(bool showExtraFields)
        {
            System.Diagnostics.Debug.WriteLine(">> updateExtraFieldsVisibility(" + showExtraFields.ToString() + ")");
            //throw new NotImplementedException();

            lblRoomID.Visible = showExtraFields;
            lblRoomMovieID.Visible = showExtraFields;
            lblCustomerID.Visible = showExtraFields;
        }


        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    lbl1.Visible = true;
        //    Button1.Visible = false;
        //}

        protected void btnPrevStep_Click(object sender, EventArgs e)
        {
            // free all held seats

            freeHeldSeats();

            Session.Remove("listChosenSeatMovies");

            Response.Redirect("~/SeatSelection.aspx");
        }

        private void freeHeldSeats()
        {
            //throw new NotImplementedException();

            List<SeatMovie> seatMovieList = Session["listChosenSeatMovies"] as List<SeatMovie>;

            foreach (SeatMovie aSeatMovie in seatMovieList)
            {
                try
                {
                    Business_Logic.RoomMovieLogic.FreeSeat(aSeatMovie.SeatMovie_ID);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(">> freeHeldSeats() error=" + ex.Message);
                }
            }
        }

        protected void btnNextStep_Click(object sender, EventArgs e)
        {

        }
    }
}