<%@ Page Title="" Language="C#" MasterPageFile="~/Cust.master" AutoEventWireup="true" CodeBehind="PanelTestPage.aspx.cs" Inherits="MovieTheater.PanelTestPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headCust" runat="server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="bodyCust" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <table>
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
