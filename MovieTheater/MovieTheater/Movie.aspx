<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.master" AutoEventWireup="true" CodeBehind="Movie.aspx.cs" Inherits="MovieTheater.Movie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headStaff" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyStaff" runat="server">
    <div class="titleCenter">Movie List</div>
    <asp:Button ID="btnAdd" CssClass="btnStyle" runat="server" Text="Add New Movie" OnClick="btnAdd_Click" />
    <div style="height: 10px;"></div>
    <asp:GridView ID="gvwMovie" runat="server" AutoGenerateColumns="False" DataSourceID="" DataKeyNames="Movie_ID" AllowPaging="True" OnRowCommand="gvwMovie_RowCommand" Font-Size="14pt" Width="960px">
        <Columns>
            <asp:BoundField DataField="Movie_ID" HeaderText="Movie_ID" SortExpression="Movie_ID" InsertVisible="False" ReadOnly="True" Visible="False" />
            <asp:BoundField DataField="Movie_Name" HeaderText="Movie Name" SortExpression="Movie_Name" ItemStyle-Width="400"></asp:BoundField>
            <asp:BoundField DataField="Duration" HeaderText="Duration" SortExpression="Duration" ItemStyle-Width="100">
                <ItemStyle Width="100px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language" ItemStyle-Width="100">
                <ItemStyle Width="100px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Subtitle" HeaderText="Subtitle" SortExpression="Subtitle" ItemStyle-Width="100">
                <ItemStyle Width="100px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Ratings" HeaderText="Ratings" SortExpression="Ratings" ItemStyle-Width="100">
                <ItemStyle Width="100px"></ItemStyle>
            </asp:BoundField>
            <asp:ButtonField ButtonType="Image" CommandName="EditComm" ImageUrl="~/Images/edit1.png" ItemStyle-Width="15">
                <ItemStyle Width="15px" HorizontalAlign="Center"></ItemStyle>
            </asp:ButtonField>
            <asp:ButtonField ButtonType="Image" CommandName="DeleteComm" ImageUrl="~/Images/delete.png" ItemStyle-Width="15">
                <ItemStyle Width="15px" HorizontalAlign="Center"></ItemStyle>
            </asp:ButtonField>
        </Columns>
        <PagerStyle HorizontalAlign="Left" />
    </asp:GridView>
    <asp:SqlDataSource ID="dsMovieList" runat="server" ConnectionString="<%$ ConnectionStrings:MovieTheaterConnectionString %>" SelectCommand="SELECT * FROM [Movie]"></asp:SqlDataSource>

    <asp:Panel ID="pnlAdd" runat="server" Visible="false">
        <div style="height: 20px;"></div>
        <div class="subTitleLeft">Add New Movie</div>
        <table>
            <tr>
                <td>Movie Name</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="tbxAddName" runat="server" CssClass="tbxStyle" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Duration</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="tbxAddDuration" runat="server" CssClass="tbxStyle" Width="50px"></asp:TextBox>
                    &nbsp;minutes
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;">Description</td>
                <td style="vertical-align: top;">:&nbsp;</td>
                <td>
                    <asp:TextBox ID="tbxAddDescription" runat="server" CssClass="tbxStyle" Width="400px" TextMode="MultiLine" Rows="5"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Language</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="tbxAddLanguage" runat="server" CssClass="tbxStyle" Width="200px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Subtitle</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="tbxAddSubtitle" runat="server" CssClass="tbxStyle" Width="200px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Ratings</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="tbxAddRatings" runat="server" CssClass="tbxStyle" Width="50px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="btnSubmit" CssClass="btnStyle" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnClose" CssClass="btnStyle" runat="server" Text="Close" OnClick="btnClose_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlEdit" runat="server" Visible="false">
        <div style="height: 20px;"></div>
        <div class="subTitleLeft">Edit New Movie</div>
        Movie Name :
        <asp:TextBox ID="tbxEditName" runat="server"></asp:TextBox>
    </asp:Panel>

</asp:Content>
