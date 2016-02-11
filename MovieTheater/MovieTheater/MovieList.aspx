<%@ Page Title="" Language="C#" MasterPageFile="~/Cust.master" AutoEventWireup="true" CodeBehind="MovieList.aspx.cs" Inherits="MovieTheater.MovieList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headCust" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyCust" runat="server">
    <div class="titleCenter">Movie List</div>
    <asp:GridView ID="gvwMovieList" runat="server" AutoGenerateColumns="False" DataKeyNames="Movie_ID" DataSourceID="" OnRowCommand="gvwMovieList_RowCommand" Width="960px" AllowPaging="true">
        <Columns>
            <asp:BoundField DataField="Movie_ID" HeaderText="Movie_ID" InsertVisible="False" ReadOnly="True" SortExpression="Movie_ID" />
            <asp:BoundField DataField="Movie_Name" HeaderText="Movie Name" SortExpression="Movie_Name">
                <ItemStyle CssClass="gridItemStyle"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Duration" HeaderText="Duration" SortExpression="Duration">
                <ItemStyle Width="100px" CssClass="gridItemStyle"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Ratings" HeaderText="Ratings" SortExpression="Ratings">
                <ItemStyle Width="100px" CssClass="gridItemStyle"></ItemStyle>
            </asp:BoundField>
            <asp:ButtonField ButtonType="Image" CommandName="NextComm" ImageUrl="~/Images/next.png">
                <ItemStyle Width="16px" HorizontalAlign="Center"></ItemStyle>
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>
