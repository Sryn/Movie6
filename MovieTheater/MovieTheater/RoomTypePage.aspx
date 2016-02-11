<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.master" AutoEventWireup="true" CodeBehind="RoomTypePage.aspx.cs" Inherits="MovieTheater.RoomTypePageaspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headStaff" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyStaff" runat="server">
    <div class="titleCenter">Room Type List</div>
    <asp:Button ID="btnAdd" CssClass="btnStyle" runat="server" Text="Add New Room Type" OnClick="btnAdd_Click" />
    <div style="height: 10px;"></div>
    <asp:GridView ID="gdvRoomtpe" runat="server" AutoGenerateColumns="False" OnRowCommand="gdvRoomtpe_RowCommand" Width="960px">
        <Columns>
            <asp:BoundField DataField="RoomType_ID" HeaderText="RoomType ID"/>
            <asp:BoundField DataField="RoomType_Name" HeaderText="Room Type Name">
                <ItemStyle CssClass="gridItemStyle"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Price" HeaderText="Price">
                <ItemStyle Width="150px" CssClass="gridItemStyle"></ItemStyle>
            </asp:BoundField>
            <asp:ButtonField ButtonType="Image" CommandName="EditComm" ImageUrl="~/Images/edit1.png">
                <ItemStyle Width="16px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
            </asp:ButtonField>
            <asp:ButtonField ButtonType="Image" CommandName="DeleteComm" ImageUrl="~/Images/delete.png">
                <ItemStyle Width="16px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
            </asp:ButtonField>
        </Columns>
    </asp:GridView>

    <asp:Panel ID="pnlAdd" runat="server" Visible="false">
        <div style="height: 20px;"></div>
        <div class="subTitleLeft">Add New RoomType</div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblRoomtypename" runat="server" Text="RoomType Name"></asp:Label>
                </td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtRoomTypeName" runat="server" CssClass="tbxStyle" Width="300"></asp:TextBox>
                    <asp:Label ID="lblname" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Price"></asp:Label>
                </td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtprice" runat="server" CssClass="tbxStyle" Width="70"></asp:TextBox>
                    <asp:Label ID="lblprice" runat="server" CssClass="errStyle"></asp:Label>
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
        <div class="subTitleLeft">Edit New RoomType</div>
        <asp:HiddenField ID="hfEditId" runat="server" />
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" CssClass="tbxStyle" Text="RoomType Name"></asp:Label>
                </td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtRTName" runat="server" Width="150"></asp:TextBox>
                    <asp:Label ID="lbleditname" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" CssClass="tbxStyle" Text="Price"></asp:Label>
                </td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtroomtypeprice" runat="server" Width="70px"></asp:TextBox>
                    <asp:Label ID="lbleditprice" runat="server" CssClass="errStyle"></asp:Label>
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
