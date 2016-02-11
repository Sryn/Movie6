<%@ Page Title="MovieSchedule" Language="C#" MasterPageFile="~/Cust.master" AutoEventWireup="true" CodeBehind="MovieSchedule.aspx.cs" Inherits="MovieTheater.MovieSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headCust" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyCust" runat="server">
    <div class="titleCenter">Movie Show</div>
    Search By : 
    <table>
        <tr>
            <td><asp:RadioButton ID="rbtnTheater" runat="server" GroupName="se" Text="Theater" /></td>
            <td>:</td>
            <td></td>
        </tr>
    </table>
        
    
    <asp:DropDownList ID="ddlTheater" runat="server"></asp:DropDownList>
    
        <asp:RadioButton ID="rbtnMovie" runat="server" GroupName="se" Text="Movie" />
    
</asp:Content>
