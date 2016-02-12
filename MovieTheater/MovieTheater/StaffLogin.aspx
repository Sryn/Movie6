<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="StaffLogin.aspx.cs" Inherits="MovieTheater.StaffLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    Username : <asp:TextBox ID="tbxUsername" runat="server"></asp:TextBox><br />
    Password : <asp:TextBox ID="tbxPassword" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
</asp:Content>
