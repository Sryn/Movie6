<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.master" AutoEventWireup="true" CodeBehind="RoomMoviePage.aspx.cs" Inherits="MovieTheater.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headStaff" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="bodyStaff">
    <div class="titleCenter">Movie Theater List</div>

    <table>
        <tr>
            <td style="width:100px;">Theater</td>
            <td> : </td>
            <td>
                <asp:DropDownList ID="theaterddl" runat="server" OnSelectedIndexChanged="theaterddl_SelectedIndexChanged2" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Room</td>
            <td> : </td>
            <td>
                <asp:DropDownList ID="roomddl" runat="server" Width="100px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Date</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="calendartbx" runat="server" Enabled="False" ></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="32px" ImageUrl="~/Images/calendar.png" Width="29px" OnClick="ImageButton1_Click" />
                <asp:Calendar ID="Calendar1" Visible="false" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="searchbtn" runat="server" OnClick="Button1_Click" Text="Search" CssClass="btnStyle" />
            </td>
        </tr>
    </table>

    <div style="height:20px;"></div>
    <asp:Button ID="addroommoviebtn" runat="server" OnClick="addroommoviebtn_Click" Text="Add a room movie" CssClass="btnStyle" />
    <asp:GridView ID="roommoviegdv" runat="server" AutoGenerateColumns="False" DataKeyNames="RoomMovie_ID" OnRowCommand="roommoviegdv_RowCommand">
        <Columns>
            <asp:BoundField DataField="RoomMovie_ID" HeaderText="RoomMovie_ID" InsertVisible="False" ReadOnly="True" SortExpression="RoomMovie_ID" />
            <asp:BoundField DataField="Room.Room_Name" HeaderText="Room Name" SortExpression="Room.Room_Name" />
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
            <asp:BoundField DataField="StartTime" HeaderText="StartTime" SortExpression="StartTime" />
            <asp:BoundField DataField="EndTime" HeaderText="EndTime" SortExpression="EndTime" />
            <asp:BoundField DataField="Movie.Movie_Name" HeaderText="Movie Name" SortExpression="Movie.Movie_Name" />
            <asp:CheckBoxField DataField="Publish" HeaderText="Published" SortExpression="Publish" />
            <asp:ButtonField ButtonType="Image" CommandName="EditComm" ImageUrl="~/Images/edit1.png">
                <ItemStyle Width="16px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
            </asp:ButtonField>
            <asp:ButtonField ButtonType="Image" CommandName="DeleteComm" ImageUrl="~/Images/delete.png">
                <ItemStyle Width="16px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
            </asp:ButtonField>
            <asp:ButtonField Text="Publish" CommandName="Publish" />
        </Columns>
    </asp:GridView>


    <asp:Panel ID="pnlAdd" runat="server" CssClass="subTitleLeft">
        <asp:Label ID="movienamelb" runat="server" Text="Movie name:" CssClass="tbxStyle"></asp:Label>
        &nbsp;&nbsp;
        <asp:DropDownList ID="movieddl" runat="server" OnSelectedIndexChanged="movieddl_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
        <br />
         <fieldset>
             <legend>Movie info</legend>
             <asp:Label ID="Label6" runat="server" CssClass="tbxStyle" Text="Movie ID:" Width="80px"></asp:Label>
             &nbsp;&nbsp;
             <asp:Label ID="Label7" runat="server" CssClass="tbxStyle" Text="Label"></asp:Label>
             <BR>   
                 <asp:Label ID="Label8" runat="server" CssClass="tbxStyle" Text="Movie Name" Width="80px"></asp:Label>
                 &nbsp;&nbsp;
                 <asp:Label ID="Label9" runat="server" CssClass="tbxStyle" Text="Label"></asp:Label>
                 <br />
                 <asp:Label ID="Label10" runat="server" CssClass="tbxStyle" Text="Duration:" Width="80px"></asp:Label>
                 &nbsp;&nbsp;
                 <asp:Label ID="Label11" runat="server" CssClass="tbxStyle" Text="Label"></asp:Label>
                 <br />
                 <asp:Label ID="Label12" runat="server" CssClass="tbxStyle" Text="Description:" Width="80px"></asp:Label>
                 &nbsp;&nbsp;
                 <asp:Label ID="Label13" runat="server" CssClass="tbxStyle" Text="Label"></asp:Label>
                 <br />
                 <asp:Label ID="Label14" runat="server" CssClass="tbxStyle" Text="Rationgs:" Width="80px"></asp:Label>
                 &nbsp;&nbsp;
                 <asp:Label ID="Label15" runat="server" CssClass="tbxStyle" Text="Label"></asp:Label>
          </fieldset>
        <br />
        Start time:&nbsp;&nbsp;<asp:DropDownList ID="starttimeddl" runat="server" Width="80px" AutoPostBack="True" OnSelectedIndexChanged="starttimeddl_SelectedIndexChanged">
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
        &nbsp;&nbsp; End time:&nbsp;<asp:Label ID="addetlb" runat="server"></asp:Label>
        <br />
        <br />
        &nbsp;<asp:Button ID="Button1" runat="server" Text="Confirm" OnClick="Button1_Click1" CssClass="btnStyle" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="addcancelbtn" runat="server" CssClass="btnStyle" OnClick="addcancelbtn_Click" Text="Cancel" />
        <br />
    </asp:Panel>



    <br />
    <asp:Panel ID="pnlEdit" runat="server" CssClass="subTitleLeft">
         <fieldset>
             <legend>Edit Roommovie</legend>

             <asp:Label ID="Label19" runat="server" CssClass="tbxStyle" Text="Roommovie ID:" Width="100px"></asp:Label>
             &nbsp;&nbsp;<asp:TextBox ID="rmidtbx" runat="server" Enabled="False"></asp:TextBox>
             <br />
             <asp:Label ID="Label21" runat="server" CssClass="tbxStyle" Text="Room Name:" Width="100px"></asp:Label>
             &nbsp;&nbsp;<asp:TextBox ID="rntbx" runat="server" Enabled="False"></asp:TextBox>
&nbsp;<br />
             <asp:Label ID="Label23" runat="server" CssClass="tbxStyle" Text="Date:" Width="100px"></asp:Label>
             &nbsp;&nbsp;<asp:TextBox ID="editcalendartbx" runat="server" Enabled="False" ></asp:TextBox>
             &nbsp;<asp:ImageButton ID="editimagebutton" runat="server" Height="27px" ImageUrl="~/Images/calendar.png" OnClick="editimagebutton_Click" Width="32px" />
             &nbsp;<asp:Calendar ID="Calendar2" runat="server" Height="49px" OnSelectionChanged="Calendar2_SelectionChanged" Width="83px" Visible="false"></asp:Calendar>
             &nbsp;<br />
             <asp:Label ID="Label25" runat="server" CssClass="tbxStyle" Text="StartTime:" Width="100px"></asp:Label>
             &nbsp;&nbsp;<asp:DropDownList ID="editstddl" runat="server" Width="80px" AutoPostBack="True" OnSelectedIndexChanged="editstddl_SelectedIndexChanged">
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
             &nbsp;<br />
             <asp:Label ID="Label26" runat="server" CssClass="tbxStyle" Text="EndTime:" Width="100px"></asp:Label>
             &nbsp;
             <asp:Label ID="editetlb" runat="server"></asp:Label>
             <br />
             <asp:Label ID="Label27" runat="server" CssClass="tbxStyle" Text="Movie Name:" Width="100px"></asp:Label>
             &nbsp;
             <asp:TextBox ID="mntbx" runat="server" Enabled="False"></asp:TextBox>
             <br />
             <asp:Label ID="Label28" runat="server" CssClass="tbxStyle" Text="Price:" Width="100px"></asp:Label>
             &nbsp;
             <asp:TextBox ID="pricetbx" runat="server" Enabled="False"></asp:TextBox>
             &nbsp;
             <br />
             <asp:Label ID="Label30" runat="server" CssClass="tbxStyle" Text="UpdateTime:" Width="100px"></asp:Label>
             &nbsp;
             <asp:TextBox ID="updatetbx" runat="server" Enabled="False"></asp:TextBox>
             <br />
             <br />
             <asp:Button ID="updatebtn" runat="server" CssClass="btnStyle" OnClick="btnUpdate_Click" Text="Update" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="editcancelbtn" runat="server" CssClass="btnStyle" OnClick="btnCancel_Click" Text="Cancel" />

         </fieldset>

    </asp:Panel>



</asp:Content>

