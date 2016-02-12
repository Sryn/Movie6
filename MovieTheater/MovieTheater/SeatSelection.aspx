
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Cust.master" CodeBehind="SeatSelection.aspx.cs" Inherits="MovieTheater.SeatSelection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headCust" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyCust" runat="server">

<%--<!DOCTYPE html>--%>

<%--<html xmlns="http://www.w3.org/1999/xhtml">--%>
<%--<head runat="server">
    <title></title>
</head>
<body>--%>
   <%-- <form id="form1" runat="server">--%>
    
   <h2 > Booking Details </h2>
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
            &nbsp;</p>
 <%--</form>--%>
</asp:Content>

<%--   
</body>
</html>--%>
