<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.master" AutoEventWireup="true" CodeBehind="MakeSeats.aspx.cs" Inherits="MovieTheater.MakeSeats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headStaff" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyStaff" runat="server">
    <table class="auto-style1">
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
                <asp:Label ID="lblTxtTheatreRoomName" runat="server" Text="Theatre Room Name:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTheatreRoomName" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTxtTheatreRoomID" runat="server" Text="Theatre Room ID:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTheatreRoomID" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTxtRowCount" runat="server" Text="Number of Seat Rows:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblRowCount" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTxtSeatColCount" runat="server" Text="Number of Seat Columns:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblSeatColCount" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTxtTotalSeats" runat="server" Text="Total Number of Seats to Create:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTotalSeats" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
<%--        <tr>
            <td>
                <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>--%>
        <tr>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
            <td>
                <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" />
                <asp:Button ID="btnDeactivateRoomSeats" runat="server" Text="Deactivate All Room Seats" Visible="False" Enabled="False" OnClick="btnDeactivateRoomSeats_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
