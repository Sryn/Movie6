<%@ Page Title="" Language="C#" MasterPageFile="Staff.master" AutoEventWireup="true" CodeBehind="DesignTheatreSeatMap.aspx.cs" Inherits="MovieTheater.PanelTestPage" %>
<%@ PreviousPageType VirtualPath="~/RoomPage.aspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headStaff" runat="server">
    <style type="text/css" class="divClass">
        .panelClass{
            /*margin-left: 50%;*/
            /*transform: translate(25%);*/
        }
        .tblClass{
            border: 1px solid black;
        }
        .tblHeaderRowClass{
            text-align:center;
        }
        .seatCellClass{

        }
        .seatImgBtnClass{
            width:40px;
            height:40px;
        }
        .aisleCellClass{
            width:40px;
            text-align:center;
        }
        .lblTextClass {

        }
        .btnClass {
            width:50px;
        }
        .labelShowClass {
            border: 1px solid black;
            width:50px;
            text-align: right;
        }
        .tblRowAisleNumbersClass{
            text-align:center;
        }
        .tblRowAisleChkBoxesClass{

        }
        .tblChkBoxesClass{

        }
        .tblCellAislePresentClass{

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyStaff" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <table>
            <tr>
                <td>&nbsp;<asp:Button ID="btnRoomUpdate" runat="server" Text="<  Go back to update room" OnClick="btnRoomUpdate_Click" /></td>
                <td>&nbsp;<asp:Button ID="btnUpdateCancel" runat="server" Text="Cancel Update and go back" OnClick="btnUpdateCancel_Click" /></td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;<asp:Label ID="lblTxtTheatreName" runat="server" Text="Theatre Name:"></asp:Label></td>
                <td>&nbsp;<asp:Label ID="lblTheatreName" runat="server" Text="theatreName"></asp:Label></td>
            </tr>
            <tr>
                <td>&nbsp;<asp:Label ID="lblTxtTheatreRoomName" runat="server" Text="Theatre Room Name:"></asp:Label></td>
                <td>&nbsp;<asp:Label ID="lblTheatreRoomName" runat="server" Text="theatreRoomName"></asp:Label></td>
            </tr>
            <tr>
                <td>&nbsp;<asp:Label ID="lblTxtTheatreRoomType" runat="server" Text="Theatre Room Type:"></asp:Label></td>
                <td>&nbsp;
                    <asp:Label ID="lblTheatreRoomType" runat="server" Text="theatreRoomType" Visible="False"></asp:Label>
                    <asp:Label ID="lblTheatreRoomTypeText" runat="server" Text="theatreRoomTypeText"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;<asp:Label ID="lblTxtSeatMapPattern" runat="server" Text="Seat Map Pattern:"></asp:Label></td>
                <td>&nbsp;<asp:Label ID="lblSeatMapPattern" runat="server" Text="seatMapPattern"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text="rowCount" Visible="False" Enabled="True"></asp:Label></td>
                <td><asp:Label ID="Label4" runat="server" Text="Label" Visible="False" Enabled="True"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label2" runat="server" Text="seatColCount" Visible="False" Enabled="True"></asp:Label></td>
                <td><asp:Label ID="Label5" runat="server" Text="Label" Visible="False" Enabled="True"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label3" runat="server" Text="aisles" Visible="False" Enabled="True"></asp:Label></td>
                <td><asp:Label ID="Label6" runat="server" Text="Label" Visible="False" Enabled="True"></asp:Label></td>
            </tr>
        </table>
        <table>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="lblTextClass"><asp:Label ID="lblTextRowCount" runat="server" Text="No. of Rows:"></asp:Label></td>
                <td class="labelShowClass"><asp:Label ID="lblRowCount" runat="server" Text="0"></asp:Label></td>
                <td class="btnClass"><asp:Button ID="btnDecreaseRowCount" Width="50px" runat="server" Text=" - " OnClick="btnDecreaseRowCount_Click" /></td>
                <td class="btnClass"><asp:Button ID="btnIncreaseRowCount" Width="50px" runat="server" Text=" + " OnClick="btnIncreaseRowCount_Click" /></td>
            </tr>
            <tr>
                <td class="lblTextClass"><asp:Label ID="lblTestSeatColCount" runat="server" Text="No. of Seat Columns:"></asp:Label></td>
                <td class="labelShowClass"><asp:Label ID="lblSeatColCount" runat="server" Text="0"></asp:Label></td>
                <td class="btnClass"><asp:Button ID="btnDecreaseSeatCount" Width="50px" runat="server" Text=" - " OnClick="btnDecreaseSeatCount_Click" /></td>
                <td class="btnClass"><asp:Button ID="btnIncreaseSeatCount" Width="50px" runat="server" Text=" + " OnClick="btnIncreaseSeatCount_Click" /></td>
            </tr>
            <tr>
                <td class="lblTextClass"><asp:Label ID="lblTextTotalSeats" runat="server" Text="Total No. of Seats:"></asp:Label></td>
                <td class="labelShowClass"><asp:Label ID="lblTotalSeats" runat="server" Text="Label"></asp:Label></td>
                <td colspan="2">&nbsp</td>
            </tr>
            <tr>
                <td><asp:Label ID="lblTextAisles" runat="server" Text="Check below where aisles should be:"></asp:Label></td>
                <td><asp:Label ID="tempLabel" runat="server" Text=""></asp:Label></td>
                <td colspan="2"><asp:Button ID="btnUpdateAisleCheckboxes" runat="server" Text="Refresh Map" OnClick="btnUpdateAisleCheckboxes_Click" ToolTip="Please Click several times until map is done" /></td>
            </tr>
        </table>
        <asp:Panel ID="pnlAisleCheckBoxes" runat="server">
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" CssClass="panelClass"></asp:Panel>
</asp:Content>
