<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Cust.master" CodeBehind="Confirm.aspx.cs" Inherits="MovieTheater.Confirm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headCust" runat="server">

    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyCust" runat="server">

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>--%>    <%--<form id="form1" runat="server">--%>
<%--    <div>
    
    </div>
        <p>
            <asp:Label ID="lbl1" Visible="false" runat="server" Text="Payment Successful!!!"></asp:Label>
    </p>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="Booking_ID" DataSourceID="SqlDataSource1" Height="50px" Width="125px">
            <Fields>
                <asp:BoundField DataField="Booking_ID" HeaderText="Booking_ID" InsertVisible="False" ReadOnly="True" SortExpression="Booking_ID" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
            </Fields>
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MovieTheaterConnectionString2 %>" SelectCommand="SELECT [Booking_ID], [Amount] FROM [Booking]"></asp:SqlDataSource>
        <br />
        <asp:Button ID="Button1" Visible="true" runat="server" Text="Payment" OnClick="Button1_Click"/>--%>



    <%--  </form>--%> <%--   <form action="https://www.sandbox.paypal.com/cgi-bin/webscr " method="post">

    <input type="hidden" name="cmd" value="_xclick" />
    <input type="hidden" name="business" value="youremailaddress@yourdomain.com" />

    <input type="hidden" name="item_name" value="My painting" />
    <input type="hidden" name="amount" value="10.00" /> 
    <input type="submit" value="Buy!" />
     </form>--%>
    <table class="auto-style1">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTxtTheatreName" runat="server" Text="Theatre Name:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTheatreName" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTxtMovieName" runat="server" Text="Movie Name:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblRoomMovieID" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lblMovieName" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTxtMovieScheduleDate" runat="server" Text="Date:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblMovieScheduleDate" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTxtMovieScheduleTime" runat="server" Text="Time:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblMovieScheduleTime" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTxtRoomName" runat="server" Text="Theatre Room Name:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblRoomID" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lblRoomName" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTxtCustomerName" runat="server" Text="Customer Name:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblCustomerID" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lblCustomerName" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTxtListOfChosenSeats" runat="server" Text="Chosen Seats:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblListOfChosenSeats" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTxtCalculation" runat="server" Text="Price Calculation:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblCalculation" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTxtTotalPrice" runat="server" Text="Total Price:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTotalPrice" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;<asp:Button ID="btnPrevStep" runat="server" Text="< Previous Step" OnClick="btnPrevStep_Click" /></td>
            <td>&nbsp;<asp:Button ID="btnNextStep" runat="server" Text="Do Payment" OnClick="btnNextStep_Click" /></td>
        </tr>
    </table>
</asp:Content>

<%--
</body>
</html>--%>
