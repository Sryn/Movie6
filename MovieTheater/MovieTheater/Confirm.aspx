<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Cust.master" CodeBehind="Confirm.aspx.cs" Inherits="MovieTheater.Confirm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headCust" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyCust" runat="server">

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>--%>    <%--<form id="form1" runat="server">--%>
    <div>
    
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
        <asp:Button ID="Button1" Visible="true" runat="server" Text="Payment" OnClick="Button1_Click"/>



    <%--  </form>--%> <%--   <form action="https://www.sandbox.paypal.com/cgi-bin/webscr " method="post">

    <input type="hidden" name="cmd" value="_xclick" />
    <input type="hidden" name="business" value="youremailaddress@yourdomain.com" />

    <input type="hidden" name="item_name" value="My painting" />
    <input type="hidden" name="amount" value="10.00" /> 
    <input type="submit" value="Buy!" />
     </form>--%>&nbsp; 
</asp:Content>

<%--
</body>
</html>--%>
