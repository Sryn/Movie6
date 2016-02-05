<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.master" AutoEventWireup="true" CodeBehind="StaffTestPage.aspx.cs" Inherits="MovieTheater.StaffTestPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headStaff" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyStaff" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="MovieGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="Movie_ID" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="Movie_ID" HeaderText="Movie_ID" InsertVisible="False" ReadOnly="True" SortExpression="Movie_ID" />
            <asp:BoundField DataField="Movie_Name" HeaderText="Movie_Name" SortExpression="Movie_Name" />
            <asp:BoundField DataField="Duration" HeaderText="Duration" SortExpression="Duration" />
            <asp:BoundField DataField="PictureURL" HeaderText="PictureURL" SortExpression="PictureURL" />
            <asp:BoundField DataField="IMDB_Link" HeaderText="IMDB_Link" SortExpression="IMDB_Link" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language" />
            <asp:BoundField DataField="Subtitle" HeaderText="Subtitle" SortExpression="Subtitle" />
            <asp:BoundField DataField="Ratings" HeaderText="Ratings" SortExpression="Ratings" />
            <asp:CheckBoxField DataField="Active_Indicator" HeaderText="Active_Indicator" SortExpression="Active_Indicator" />
            <asp:BoundField DataField="Update_Datetime" HeaderText="Update_Datetime" SortExpression="Update_Datetime" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MovieTheaterConnectionString %>" SelectCommand="SELECT * FROM [Movie]"></asp:SqlDataSource>
</asp:Content>
