<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.master" AutoEventWireup="true" CodeBehind="RoomMoviePage.aspx.cs" Inherits="MovieTheater.RoomMoviePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headStaff" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="bodyStaff">
    <div class="titleCenter">Movie Show</div>

    <table>
        <tr>
            <td style="width: 100px;">Theater</td>
            <td>:&nbsp;</td>
            <td>
                <asp:DropDownList ID="theaterddl" runat="server" OnSelectedIndexChanged="theaterddl_SelectedIndexChanged2" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Room</td>
            <td>:</td>
            <td>
                <asp:DropDownList ID="roomddl" runat="server" Width="100px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top">Date</td>
            <td style="vertical-align: top">:</td>
            <td>
                <asp:TextBox ID="calendartbx" runat="server" Enabled="False"></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="24px" ImageUrl="~/Images/calendar.png" OnClick="ImageButton1_Click" />
                <div style="height: 10px;"></div>
                <asp:Calendar ID="Calendar1" Visible="false" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="searchbtn" runat="server" OnClick="Button1_Click" Text="Search" CssClass="btnStyle" />
            </td>
        </tr>
    </table>

    <asp:Panel ID="pnlGrid" runat="server">
        <div style="height: 20px;"></div>
        <asp:Button ID="addroommoviebtn" runat="server" OnClick="addroommoviebtn_Click" Text="Add New Movie Show" CssClass="btnStyle" />
        <div style="height: 10px;"></div>
        <asp:GridView ID="roommoviegdv" runat="server" AutoGenerateColumns="False" DataKeyNames="RoomMovie_ID" OnRowCommand="roommoviegdv_RowCommand">
            <Columns>
                <asp:BoundField DataField="RoomMovie_ID" HeaderText="RoomMovie_ID" InsertVisible="False" ReadOnly="True" SortExpression="RoomMovie_ID">
                    <HeaderStyle CssClass="gridItemStyle"></HeaderStyle>
                    <ItemStyle CssClass="gridItemStyle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Room.Room_Name" HeaderText="Room Name" SortExpression="Room.Room_Name">
                    <HeaderStyle CssClass="gridItemStyle"></HeaderStyle>
                    <ItemStyle CssClass="gridItemStyle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date">
                    <HeaderStyle CssClass="gridItemStyle"></HeaderStyle>
                    <ItemStyle CssClass="gridItemStyle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="StartTime" HeaderText="Start Time" SortExpression="StartTime">
                    <HeaderStyle CssClass="gridItemStyle"></HeaderStyle>
                    <ItemStyle CssClass="gridItemStyle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="EndTime" HeaderText="End Time" SortExpression="EndTime">
                    <HeaderStyle CssClass="gridItemStyle"></HeaderStyle>
                    <ItemStyle CssClass="gridItemStyle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Movie.Movie_Name" HeaderText="Movie Name" SortExpression="Movie.Movie_Name">
                    <HeaderStyle CssClass="gridItemStyle"></HeaderStyle>
                    <ItemStyle CssClass="gridItemStyle"></ItemStyle>
                </asp:BoundField>
                <asp:CheckBoxField DataField="Publish" HeaderText="Published" SortExpression="Publish">
                    <HeaderStyle CssClass="gridItemStyle"></HeaderStyle>
                    <ItemStyle CssClass="gridItemStyle"></ItemStyle>
                </asp:CheckBoxField>
                <asp:ButtonField ButtonType="Image" CommandName="EditComm" ImageUrl="~/Images/edit1.png">
                    <ItemStyle Width="16px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:ButtonField>
                <asp:ButtonField ButtonType="Image" CommandName="DeleteComm" ImageUrl="~/Images/delete.png">
                    <ItemStyle Width="16px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:ButtonField>
                <asp:ButtonField Text="Publish" CommandName="Publish" />
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="pnlAdd" runat="server">
        <div style="height: 20px;"></div>
        <div class="subTitleLeft">Add New Movie Show</div>
        <table>
            <tr>
                <td>Movie Name</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:DropDownList ID="movieddl" runat="server" OnSelectedIndexChanged="movieddl_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>

        <fieldset>
            <legend>Movie Info</legend>
            <table>
                <tr>
                    <td style="width: 100px;">Movie ID</td>
                    <td>:&nbsp;</td>
                    <td>
                        <asp:Label ID="Label7" runat="server" CssClass="tbxStyle" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>Movie Name</td>
                    <td>:&nbsp;</td>
                    <td>
                        <asp:Label ID="Label9" runat="server" CssClass="tbxStyle" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>Duration</td>
                    <td>:&nbsp;</td>
                    <td>
                        <asp:Label ID="Label11" runat="server" CssClass="tbxStyle" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="vertical-align:top">Description</td>
                    <td style="vertical-align:top">:&nbsp;</td>
                    <td>
                        <asp:Label ID="Label13" runat="server" CssClass="tbxStyle" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>Ratings</td>
                    <td>:&nbsp;</td>
                    <td>
                        <asp:Label ID="Label15" runat="server" CssClass="tbxStyle" Text="Label"></asp:Label></td>
                </tr>
            </table>
        </fieldset>
        <div style="height: 10px;"></div>
        <table>
            <tr>
                <td>Start time :&nbsp;&nbsp;</td>
                <td>
                    <asp:DropDownList ID="starttimeddl" runat="server" Width="80px" AutoPostBack="True" OnSelectedIndexChanged="starttimeddl_SelectedIndexChanged">
                        <asp:ListItem Selected="True">10:00</asp:ListItem>
                        <asp:ListItem>10:30</asp:ListItem>
                        <asp:ListItem>11:00</asp:ListItem>
                        <asp:ListItem>11:30</asp:ListItem>
                        <asp:ListItem>12:00</asp:ListItem>
                        <asp:ListItem>12:30</asp:ListItem>
                        <asp:ListItem>13:00</asp:ListItem>
                        <asp:ListItem>13:30</asp:ListItem>
                        <asp:ListItem>14:00</asp:ListItem>
                        <asp:ListItem>14:30</asp:ListItem>
                        <asp:ListItem>15:00</asp:ListItem>
                        <asp:ListItem>15:30</asp:ListItem>
                        <asp:ListItem>16:00</asp:ListItem>
                        <asp:ListItem>16:30</asp:ListItem>
                        <asp:ListItem>17:00</asp:ListItem>
                        <asp:ListItem>17:30</asp:ListItem>
                        <asp:ListItem>18:00</asp:ListItem>
                        <asp:ListItem>18:30</asp:ListItem>
                        <asp:ListItem>19:00</asp:ListItem>
                        <asp:ListItem>19:30</asp:ListItem>
                        <asp:ListItem>20:00</asp:ListItem>
                        <asp:ListItem>20:30</asp:ListItem>
                        <asp:ListItem>21:00</asp:ListItem>
                        <asp:ListItem>21:30</asp:ListItem>
                        <asp:ListItem>22:00</asp:ListItem>
                        <asp:ListItem>22:30</asp:ListItem>
                        <asp:ListItem>23:00</asp:ListItem>
                        <asp:ListItem>23:30</asp:ListItem>
                        <asp:ListItem>24:00</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                </td>
                <td>End time :&nbsp;&nbsp;</td>
                <td>
                    <asp:Label ID="addetlb" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="Button1" runat="server" Text="Confirm" OnClick="Button1_Click1" CssClass="btnStyle" />
                    <asp:Button ID="addcancelbtn" runat="server" CssClass="btnStyle" OnClick="addcancelbtn_Click" Text="Cancel" />
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlEdit" runat="server">
        <div style="height: 20px;"></div>
        <div class="subTitleLeft">Edit Movie Show</div>
        <asp:HiddenField ID="hfMID" runat="server" />
        <asp:HiddenField ID="hfRID" runat="server" />
        <table>
            <tr>
                <td style="width:100px;">Room Name</td>
                <td>:&nbsp;</td>
                <td><asp:TextBox ID="rntbx" runat="server" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Date</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="editcalendartbx" runat="server" Enabled="False"></asp:TextBox>
                    <asp:ImageButton ID="editimagebutton" runat="server" Height="24px" ImageUrl="~/Images/calendar.png" OnClick="editimagebutton_Click" />
                    <asp:Calendar ID="Calendar2" runat="server" Height="49px" OnSelectionChanged="Calendar2_SelectionChanged" Width="83px" Visible="false"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>Start Time</td>
                <td>:&nbsp;</td>
                <td>
                    <asp:DropDownList ID="editstddl" runat="server" Width="80px" AutoPostBack="True" OnSelectedIndexChanged="editstddl_SelectedIndexChanged">
                        <asp:ListItem Selected="True">10:00</asp:ListItem>
                        <asp:ListItem>10:30</asp:ListItem>
                        <asp:ListItem>11:00</asp:ListItem>
                        <asp:ListItem>11:30</asp:ListItem>
                        <asp:ListItem>12:00</asp:ListItem>
                        <asp:ListItem>12:30</asp:ListItem>
                        <asp:ListItem>13:00</asp:ListItem>
                        <asp:ListItem>13:30</asp:ListItem>
                        <asp:ListItem>14:00</asp:ListItem>
                        <asp:ListItem>14:30</asp:ListItem>
                        <asp:ListItem>15:00</asp:ListItem>
                        <asp:ListItem>15:30</asp:ListItem>
                        <asp:ListItem>16:00</asp:ListItem>
                        <asp:ListItem>16:30</asp:ListItem>
                        <asp:ListItem>17:00</asp:ListItem>
                        <asp:ListItem>17:30</asp:ListItem>
                        <asp:ListItem>18:00</asp:ListItem>
                        <asp:ListItem>18:30</asp:ListItem>
                        <asp:ListItem>19:00</asp:ListItem>
                        <asp:ListItem>19:30</asp:ListItem>
                        <asp:ListItem>20:00</asp:ListItem>
                        <asp:ListItem>20:30</asp:ListItem>
                        <asp:ListItem>21:00</asp:ListItem>
                        <asp:ListItem>21:30</asp:ListItem>
                        <asp:ListItem>22:00</asp:ListItem>
                        <asp:ListItem>22:30</asp:ListItem>
                        <asp:ListItem>23:00</asp:ListItem>
                        <asp:ListItem>23:30</asp:ListItem>
                        <asp:ListItem>24:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>End Time</td>
                <td>:&nbsp;</td>
                <td><asp:Label ID="editetlb" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Movie name</td>
                <td>:&nbsp;</td>
                <td><asp:TextBox ID="mntbx" runat="server" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Price</td>
                <td>:&nbsp;</td>
                <td><asp:TextBox ID="pricetbx" runat="server" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="updatebtn" runat="server" CssClass="btnStyle" OnClick="btnUpdate_Click" Text="Update" />
                    <asp:Button ID="editcancelbtn" runat="server" CssClass="btnStyle" OnClick="btnCancel_Click" Text="Cancel" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
