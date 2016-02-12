<%@ Page Title="MovieSchedule" Language="C#" MasterPageFile="~/Cust.master" AutoEventWireup="true" CodeBehind="MovieSchedule.aspx.cs" Inherits="MovieTheater.MovieSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headCust" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyCust" runat="server">
    <div class="titleCenter">Movie Show</div>
    Search By : 
    <table>
        <tr>
            <td colspan="3">
                <asp:RadioButton ID="rbtnAll" runat="server" GroupName="se" Text="Show All Movie Show" />
            </td>
        </tr>
        <tr>
            <td><asp:RadioButton ID="rbtnTheater" runat="server" GroupName="se" Text="Show by Theater" /></td>
            <td>:&nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlTheater" runat="server"></asp:DropDownList>
                <asp:TextBox ID="tbxTheater" runat="server" Text="No Theater Available" ForeColor="Red"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td><asp:RadioButton ID="rbtnMovie" runat="server" GroupName="se" Text="Show by Movie" /></td>
            <td>:&nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlMovie" runat="server"></asp:DropDownList>
                <asp:TextBox ID="tbxMovie" runat="server" Text="No Movie Available" ForeColor="Red"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="btnSeach" runat="server" OnClick="btnSeach_Click" Text="Search" CssClass="btnStyle" />
            </td>
        </tr>
    </table>

    <div style="height:20px;"></div>
    <asp:GridView ID="gvwMovieSchedule" runat="server" AutoGenerateColumns="False" DataKeyNames="RoomMovie_ID" OnRowCommand="gvwMovieSchedule_RowCommand" AllowPaging="True">
        <Columns>
            <asp:BoundField DataField="RoomMovie_ID" HeaderText="RoomMovie_ID" InsertVisible="False" ReadOnly="True" SortExpression="RoomMovie_ID" />
            <asp:BoundField DataField="Movie.Movie_Name" HeaderText="Movie Name" SortExpression="Movie.Movie_Name">
                <HeaderStyle CssClass="gridItemStyle"></HeaderStyle>
                <ItemStyle CssClass="gridItemStyle"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Room.Theater.Theater_Name" HeaderText="Theater Name" SortExpression="Room.Theater.Theater_Name">
                <HeaderStyle CssClass="gridItemStyle"></HeaderStyle>
                <ItemStyle CssClass="gridItemStyle"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Room.Room_Name" HeaderText="Room Name" SortExpression="Room.Room_Name">
                <HeaderStyle CssClass="gridItemStyle"></HeaderStyle>
                <ItemStyle CssClass="gridItemStyle"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date">
                <HeaderStyle CssClass="gridItemStyle"></HeaderStyle>
                <ItemStyle CssClass="gridItemStyle"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="StartTime" HeaderText="Start Time" SortExpression="StartTime">
                <HeaderStyle CssClass="gridItemStyle"></HeaderStyle>
                <ItemStyle CssClass="gridItemStyle"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="EndTime" HeaderText="End Time" SortExpression="EndTime">
                <HeaderStyle CssClass="gridItemStyle"></HeaderStyle>
                <ItemStyle CssClass="gridItemStyle"></ItemStyle>
            </asp:BoundField>
            <asp:ButtonField Text="Take" CommandName="Take" />
        </Columns>
    </asp:GridView>

</asp:Content>
