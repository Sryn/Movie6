<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.master" AutoEventWireup="true" CodeBehind="SeatTestV01.aspx.cs" Inherits="MovieTheater.SeatTestV01" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headStaff" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyStaff" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <table style="padding:0; border-spacing:0">
        <tr>
            <td>&nbsp;</td>
            <td colspan="5" style="align-content:center;">
                <table border="1"><tr><td style="width:200px; text-align:center">SCREEN</td></tr></table>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align:center;">1</td>
            <td style="text-align:center;">2</td>
            <td style="text-align:center;">3</td>
            <td style="text-align:center;">&nbsp;</td>
            <td style="text-align:center;">4</td>
            <td style="text-align:center;">5</td>
            <td style="text-align:center;">6</td>
        </tr>
        <tr>
            <td><asp:ImageButton ID="SeatA1" runat="server" ImageUrl="~/Images/ChairIconV06.png" OnClick="ImageButton_Click" Height="40px" Width="40" /></td>
            <td><asp:ImageButton ID="SeatA2" runat="server" ImageUrl="~/Images/ChairIconV06.png" OnClick="ImageButton_Click" Height="40px" Width="40" /></td>
            <td><asp:ImageButton ID="SeatA3" runat="server" ImageUrl="~/Images/ChairIconV06.png" OnClick="ImageButton_Click" Height="40px" Width="40" /></td>
            <td style="width:40px; text-align:center">A</td>
            <td><asp:ImageButton ID="SeatA4" runat="server" ImageUrl="~/Images/ChairIconV06.png" OnClick="ImageButton_Click" Height="40px" Width="40" /></td>
            <td><asp:ImageButton ID="SeatA5" runat="server" ImageUrl="~/Images/ChairIconV06.png" OnClick="ImageButton_Click" Height="40px" Width="40" /></td>
            <td><asp:ImageButton ID="SeatA6" runat="server" ImageUrl="~/Images/ChairIconV06.png" OnClick="ImageButton_Click" Height="40px" Width="40" /></td>
        </tr>
        <tr>
            <td><asp:ImageButton ID="SeatB1" runat="server" ImageUrl="~/Images/ChairIconV06.png" OnClick="ImageButton_Click" Height="40px" Width="40" /></td>
            <td><asp:ImageButton ID="SeatB2" runat="server" ImageUrl="~/Images/ChairIconV06.png" OnClick="ImageButton_Click" Height="40px" Width="40" /></td>
            <td><asp:ImageButton ID="SeatB3" runat="server" ImageUrl="~/Images/ChairIconV06.png" OnClick="ImageButton_Click" Height="40px" Width="40" /></td>
            <td style="width:40px; text-align:center">B</td>
            <td><asp:ImageButton ID="SeatB4" runat="server" ImageUrl="~/Images/ChairIconV06.png" OnClick="ImageButton_Click" Height="40px" Width="40" /></td>
            <td><asp:ImageButton ID="SeatB5" runat="server" ImageUrl="~/Images/ChairIconV06.png" OnClick="ImageButton_Click" Height="40px" Width="40" /></td>
            <td><asp:ImageButton ID="SeatB6" runat="server" ImageUrl="~/Images/ChairIconV06.png" OnClick="ImageButton_Click" Height="40px" Width="40" /></td>
        </tr>
        <tr>
            <td><asp:ImageButton ID="SeatC1" runat="server" ImageUrl="~/Images/ChairIconV06.png" OnClick="ImageButton_Click" Height="40px" Width="40" /></td>
            <td><asp:ImageButton ID="SeatC2" runat="server" ImageUrl="~/Images/ChairIconV06.png" OnClick="ImageButton_Click" Height="40px" Width="40" /></td>
            <td><asp:ImageButton ID="SeatC3" runat="server" ImageUrl="~/Images/ChairIconV06.png" OnClick="ImageButton_Click" Height="40px" Width="40" /></td>
            <td style="width:40px; text-align:center">C</td>
            <td><asp:ImageButton ID="SeatC4" runat="server" ImageUrl="~/Images/ChairIconV06.png" OnClick="ImageButton_Click" Height="40px" Width="40" /></td>
            <td><asp:ImageButton ID="SeatC5" runat="server" ImageUrl="~/Images/ChairIconV06.png" OnClick="ImageButton_Click" Height="40px" Width="40" /></td>
            <td><asp:ImageButton ID="SeatC6" runat="server" ImageUrl="~/Images/ChairIconV06.png" OnClick="ImageButton_Click" Height="40px" Width="40" /></td>
        </tr>
    </table>
</asp:Content>
