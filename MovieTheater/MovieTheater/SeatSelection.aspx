
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Cust.master" CodeBehind="SeatSelection.aspx.cs" Inherits="MovieTheater.SeatSelection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headCust" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyCust" runat="server">
<%--   <h2 > Booking Details </h2>
    <div>
    
        <asp:Label ID="MovieName" runat="server" Text="Movie"></asp:Label>
        <br>
        <asp:Label ID="TheatreName" runat="server" Text="Theatre"></asp:Label>
    <br>
   <asp:Label ID="Date" runat="server" Text="Date"></asp:Label>
    </div>

        <p>
            <asp:Label ID="Time" runat="server" Text="Time"></asp:Label>
        </p>
        <p>
            <asp:DropDownList ID="DropDownList1" runat="server" Height="145px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="46px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Confirm" />
        </p>
        <p>
            &nbsp;</p>--%>
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
                <asp:Label ID="lblTheatreID" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lblTheatreName" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTxtMovieName" runat="server" Text="Movie Name:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblMovieID" runat="server" Text="Label"></asp:Label>
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
            <td>
                <asp:Label ID="lblTxtSeatMapPattern" runat="server" Text="seatMapPattern:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblSeatMapPattern" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTxtChosenSeatID" runat="server" Text="Chosen SeatID:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblChosenSeatID" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTxtChosenSeatMovieID" runat="server" Text="Chosen SeatMovieID:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblChosenSeatMovieID" runat="server" Text=""></asp:Label>
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
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;<asp:Button ID="btnPrevStep" runat="server" Text="< Previous Step" OnClick="btnPrevStep_Click" /></td>
            <td>&nbsp;<asp:Button ID="btnNextStep" runat="server" Text="Next Step >" OnClick="btnNextStep_Click" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:Panel ID="pnlSeatMap" runat="server"></asp:Panel>
</asp:Content>
