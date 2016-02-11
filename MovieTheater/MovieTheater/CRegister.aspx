<%@ Page Title="CRegister" Language="C#" MasterPageFile="~/Cust.master" AutoEventWireup="true" CodeBehind="CRegister.aspx.cs" Inherits="MovieTheater.CRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headCust" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyCust" runat="server">
    <div style="height: 20px;"></div>
    <div class="titleCenter">Customer Registration</div>
    <table>
        <tr>
            <td><asp:Label ID="lblCustomerName" runat="server" Text="Customer Name"></asp:Label></td>
            <td>:&nbsp;</td>
            <td>
                <asp:TextBox ID="tbxCustomerName" runat="server" CssClass="tbxStyle" Width="300px"></asp:TextBox>
                <asp:Label ID="lbltname" runat="server" CssClass="errStyle"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label></td>
            <td>:&nbsp;</td>
            <td>
                <asp:TextBox ID="tbxEmail" runat="server" CssClass="tbxStyle" Width="200px"></asp:TextBox>
                <asp:Label ID="lbltemail" runat="server" CssClass="errStyle"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblMobileno" runat="server" Text="Mobile No"></asp:Label></td>
            <td>:&nbsp;</td>
            <td>
                <asp:TextBox ID="tbxMobileno" runat="server" CssClass="tbxStyle" Width="150px"></asp:TextBox>
                <asp:Label ID="lbltmobileno" runat="server" CssClass="errStyle"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblLoginID" runat="server" Text="Login ID"></asp:Label></td>
            <td>:&nbsp;</td>
            <td>
                <asp:TextBox ID="tbxLoginID" runat="server" CssClass="tbxStyle" Width="200px"></asp:TextBox>
                <asp:Label ID="lbltloginid" runat="server" CssClass="errStyle"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label></td>
            <td>:&nbsp;</td>
            <td>
                <asp:TextBox ID="tbxPassword" runat="server" CssClass="tbxStyle" Width="200px"></asp:TextBox>
                <asp:Label ID="lbltpassword" runat="server" CssClass="errStyle"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="padding-top: 15px;">
                <asp:Button ID="btnSubmit" runat="server" CssClass="btnStyle" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnClose" runat="server" CssClass="btnStyle" Text="Close" OnClick="btnClose_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
