<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.master" AutoEventWireup="true" CodeBehind="MoviePage.aspx.cs" Inherits="MovieTheater.MoviePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headStaff" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyStaff" runat="server">
    <div class="titleCenter">Movie List</div>
    <asp:Button ID="btnAdd" CssClass="btnStyle" runat="server" Text="Add New Movie" OnClick="btnAdd_Click" />
    <div style="height: 10px;"></div>
    <asp:GridView ID="gvwMovie" runat="server" AutoGenerateColumns="False" DataSourceID="" DataKeyNames="Movie_ID" AllowPaging="True" OnRowCommand="gvwMovie_RowCommand" Font-Size="14pt" Width="960px">
        <Columns>
            <asp:BoundField DataField="Movie_ID" HeaderText="Movie_ID" SortExpression="Movie_ID" InsertVisible="False" ReadOnly="True"/>
            <asp:BoundField DataField="Movie_Name" HeaderText="Movie Name" SortExpression="Movie_Name">
                <ItemStyle CssClass="gridItemStyle"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Duration" HeaderText="Duration" SortExpression="Duration">
                <ItemStyle Width="100px" CssClass="gridItemStyle"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language">
                <ItemStyle Width="100px" CssClass="gridItemStyle"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Subtitle" HeaderText="Subtitle" SortExpression="Subtitle">
                <ItemStyle Width="100px" CssClass="gridItemStyle"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Ratings" HeaderText="Ratings" SortExpression="Ratings">
                <ItemStyle Width="100px" CssClass="gridItemStyle"></ItemStyle>
            </asp:BoundField>
            <asp:ButtonField ButtonType="Image" CommandName="EditComm" ImageUrl="~/Images/edit1.png">
                <ItemStyle Width="16px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
            </asp:ButtonField>
            <asp:ButtonField ButtonType="Image" CommandName="DeleteComm" ImageUrl="~/Images/delete.png">
                <ItemStyle Width="16px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
            </asp:ButtonField>
        </Columns>
        <PagerStyle HorizontalAlign="Left" />
    </asp:GridView>

    <asp:Panel ID="pnlAdd" runat="server" Visible="false">
        <div style="height: 20px;"></div>
        <div class="subTitleLeft">Add New Movie</div>
        <table>
            <tr>
                <td>Movie Name</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="tbxAddName" runat="server" CssClass="tbxStyle" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblEAName" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Duration</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="tbxAddDuration" runat="server" CssClass="tbxStyle" Width="50px"></asp:TextBox>
                    &nbsp;minutes
                    <asp:Label ID="lblEADuration" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;">Description</td>
                <td style="vertical-align: top;">:&nbsp;</td>
                <td>
                    <asp:TextBox ID="tbxAddDescription" runat="server" CssClass="tbxStyle" Width="400px" TextMode="MultiLine" Rows="5"></asp:TextBox>
                    <asp:Label ID="lblEADescription" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Language</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="tbxAddLanguage" runat="server" CssClass="tbxStyle" Width="200px"></asp:TextBox>
                    <asp:Label ID="lblEALanguage" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Subtitle</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="tbxAddSubtitle" runat="server" CssClass="tbxStyle" Width="200px"></asp:TextBox>
                    <asp:Label ID="lblEASubtitle" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Ratings</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="tbxAddRatings" runat="server" CssClass="tbxStyle" Width="50px"></asp:TextBox>
                    <asp:Label ID="lblEARatings" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Picture</td>
                <td>:&nbsp;</td>
                <td><asp:FileUpload ID="fuAddPicture" runat="server" /></td>
            </tr>
            <tr>
                <td>IMDB Link</td>
                <td>:&nbsp;</td>
                <td><asp:TextBox ID="tbxAddImdb" runat="server" CssClass="tbxStyle" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3" style="padding-top: 15px;">
                    <asp:Button ID="btnSubmit" CssClass="btnStyle" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnClose" CssClass="btnStyle" runat="server" Text="Close" OnClick="btnClose_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlEdit" runat="server" Visible="false">
        <div style="height: 20px;"></div>
        <div class="subTitleLeft">Edit Movie</div>
        <asp:HiddenField ID="hfEditId" runat="server" />
        <table>
            <tr>
                <td>Movie Name</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="tbxEditName" runat="server" CssClass="tbxStyle" Width="300px"></asp:TextBox>
                    <asp:Label ID="lblEEName" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Duration</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="tbxEditDuration" runat="server" CssClass="tbxStyle" Width="50px"></asp:TextBox>
                    &nbsp;minutes
                    <asp:Label ID="lblEEDuration" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;">Description</td>
                <td style="vertical-align: top;">:&nbsp;</td>
                <td>
                    <asp:TextBox ID="tbxEditDescription" runat="server" CssClass="tbxStyle" Width="400px" TextMode="MultiLine" Rows="5"></asp:TextBox>
                    <asp:Label ID="lblEEDescription" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Language</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="tbxEditLanguage" runat="server" CssClass="tbxStyle" Width="200px"></asp:TextBox>
                    <asp:Label ID="lblEELanguage" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Subtitle</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="tbxEditSubtitle" runat="server" CssClass="tbxStyle" Width="200px"></asp:TextBox>
                    <asp:Label ID="lblEESubtitle" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Ratings</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="tbxEditRatings" runat="server" CssClass="tbxStyle" Width="50px"></asp:TextBox>
                    <asp:Label ID="lblEERatings" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Picture</td>
                <td>:&nbsp;</td>
                <td><asp:FileUpload ID="fuEditPicture" runat="server" /></td>
            </tr>
            <tr>
                <td>IMDB Link</td>
                <td>:&nbsp;</td>
                <td><asp:TextBox ID="tbxEditImdb" runat="server" CssClass="tbxStyle" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3" style="padding-top: 15px;">
                    <asp:Button ID="btnUpdate" CssClass="btnStyle" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnCancel" CssClass="btnStyle" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>
