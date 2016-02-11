<%@ Page Title="" Language="C#" MasterPageFile="~/Cust.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MovieTheater.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headCust" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyCust" runat="server">
    <div class="titleCenter">Customer Login</div>
    <table>
        <tr>
            <td><asp:Label ID="lblLoginID" runat="server" Text="Login ID"></asp:Label></td>
            <td>:&nbsp;</td>
            <td>
                <asp:TextBox ID="tbxLoginID" runat="server" CssClass="tbxStyle" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label></td>
            <td>:&nbsp;</td>
            <td>
                <asp:TextBox ID="tbxPassword" runat="server" CssClass="tbxStyle" Width="200px" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr><td colspan="3"><asp:Label ID="lblErrLog" runat="server" CssClass="errStyle"></asp:Label></td></tr>
        <tr>
            <td colspan="3" style="padding-top: 15px;">
                <asp:Button ID="btnSubmit" runat="server" CssClass="btnStyle" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnClose" runat="server" CssClass="btnStyle" Text="Close" OnClick="btnClose_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
