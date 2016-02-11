<%@ Page Title="" Language="C#" MasterPageFile="~/Cust.master" AutoEventWireup="true" CodeBehind="MovieDetail.aspx.cs" Inherits="MovieTheater.MovieDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headCust" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyCust" runat="server">
    <div class="titleCenter">
        <asp:Label ID="lblTitle" runat="server" Text="James Bond"></asp:Label></div>
    <div style="float: left; width: 209px;">
        <asp:Image ID="imgMovie" runat="server" Width="182" />
    </div>
    <div style="float:left; width:750px;">
        <table>
            <tr>
                <td style="width:100px;">Movie Name</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:Label ID="lblName" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Duration</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:Label ID="lblDuration" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="vertical-align: top;">Description</td>
                <td style="vertical-align: top;">:&nbsp;</td>
                <td style="vertical-align: top;">
                    <asp:Label ID="lblDescription" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Language</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:Label ID="lblLanguage" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Subtitle</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:Label ID="lblSubtitle" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Ratings</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:Label ID="lblRatings" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>IMDB</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:HyperLink ID="hlinkImdb" runat="server" Target="_blank">
                        
                    </asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>
    <div style="clear:both; height:20px;"></div>
    <div style="font-size:16px; font-weight:600;">Movie Schedule : </div>
    <asp:Panel ID="pnlSchedule" runat="server">

    </asp:Panel>
</asp:Content>
