<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.master" AutoEventWireup="true" CodeBehind="RoomPage.aspx.cs" Inherits="MovieTheater.RoomPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headStaff" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyStaff" runat="server">

    <div class="titleCenter">Room List</div>
    <div style="float: left; width: 120px;">Theater Name</div>
    <div>:
        <asp:Label ID="lblTheaterNameTitle" runat="server" Text="Room Name"></asp:Label></div>
    <div style="height: 10px;"></div>
    <asp:Button ID="btnAdd" CssClass="btnStyle" runat="server" Text="Add New Room" OnClick="btnAdd_Click" />
    <div style="height: 10px;"></div>
    <asp:GridView ID="gdvRoom" runat="server" AutoGenerateColumns="False" OnRowCommand="gdvRoom_RowCommand" Width="960px" AllowPaging="false">
        <Columns>
            <asp:BoundField DataField="Room_ID" HeaderText="Room ID"/>
            <asp:BoundField DataField="Room_Name" HeaderText="Room Name">
                <ItemStyle CssClass="gridItemStyle"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Theater.Theater_Name" HeaderText="Theater Name">
                <ItemStyle Width="200px" CssClass="gridItemStyle"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="RoomType.RoomType_Name" HeaderText="RoomType Name">
                <ItemStyle Width="200px" CssClass="gridItemStyle"></ItemStyle>
            </asp:BoundField>
            <asp:ButtonField ButtonType="Image" CommandName="EditComm" ImageUrl="~/Images/edit1.png">
                <ItemStyle Width="16px" HorizontalAlign="Center"></ItemStyle>
            </asp:ButtonField>
            <asp:ButtonField ButtonType="Image" CommandName="DeleteComm" ImageUrl="~/Images/delete.png">
                <ItemStyle Width="16px" HorizontalAlign="Center"></ItemStyle>
            </asp:ButtonField>
            <asp:ButtonField ButtonType="Image" CommandName="NextComm" ImageUrl="~/Images/next.png">
                <ItemStyle Width="16px" HorizontalAlign="Center"></ItemStyle>
            </asp:ButtonField>
        </Columns>
    </asp:GridView>

    <asp:Panel ID="pnlAdd" runat="server" Visible="false">
        <div style="height: 20px;"></div>
        <div class="subTitleLeft">Add New Room</div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblRoomName" runat="server" Text="Room Name"></asp:Label>
                </td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtRoomName" runat="server" CssClass="tbxStyle" Width="200px"></asp:TextBox>
                    <asp:Label ID="lblname" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblRoomtype" runat="server" Text="RoomType Name"></asp:Label>
                </td>
                <td>:&nbsp;</td>
                <td>
                    <asp:DropDownList ID="ddlRoomtypename" runat="server" DataTextField="RoomType.RoomType_Name" DataValueField="RoomType.RoomType_ID" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="lblSeatPattern" runat="server" Text="Seat Pattern"></asp:Label></td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="tbxSeatPattern" runat="server" Width="200"></asp:TextBox>
                    <asp:Label ID="lbltsPattern" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="padding-top: 15px;">
                    <asp:Button ID="btnSubmit" runat="server" CssClass="btnStyle" OnClick="btnSubmit_Click" Text="Submit" />
                    <asp:Button ID="btnClose" runat="server" CssClass="btnStyle" Text="Close" OnClick="btnClose_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlEdit" runat="server" Visible="false">
        <div style="height: 20px;"></div>
        <div class="subTitleLeft">Edit New Room</div>
        <asp:HiddenField ID="hfEditId" runat="server" />
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Room Name"></asp:Label>
                </td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtrname" runat="server" CssClass="tbxStyle" Width="200px"></asp:TextBox>
                    <asp:Label ID="lbleditname" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="RoomType Name"></asp:Label>
                </td>
                <td>:&nbsp;</td>
                <td>
                    <asp:DropDownList ID="ddlroomtype" runat="server" DataTextField="RoomType.RoomType_Name" DataValueField="RoomType.RoomType_ID" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="lblESeatPattern" runat="server" Text="Seat Pattern"></asp:Label></td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="tbxESeatPattern" runat="server" Width="200"></asp:TextBox>
                    <asp:Label ID="lbltSeatPattern" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="padding-top: 15px;">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="btnStyle" OnClick="btnUpdate_Click" Text="Update" />
                    <asp:Button ID="btnCancel" runat="server" CssClass="btnStyle" Text="Cancel" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
