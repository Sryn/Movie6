<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.master" AutoEventWireup="true" CodeBehind="TheaterPage.aspx.cs" Inherits="MovieTheater.TheaterPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headStaff" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyStaff" runat="server">
    <div class="titleCenter">Theater List</div>
    <asp:Button ID="btnAdd" CssClass="btnStyle" runat="server" Text="Add New Theater" OnClick="btnAdd_Click" />


    <div style="height: 10px;"></div>

    <asp:GridView ID="gdvTheater" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnRowCommand="gdvTheater_RowCommand" Width="960px">
        <Columns>
            <asp:BoundField DataField="Theater_ID" HeaderText="Theater ID" />
            <asp:BoundField DataField="Theater_Name" HeaderText="Theater Name">
                <ItemStyle CssClass="gridItemStyle"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Theater_Address" HeaderText="Address">
                <ItemStyle Width="300px" CssClass="gridItemStyle"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Theater_Phone_No" HeaderText="Phone No">
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
        <div class="subTitleLeft">Add New Theater</div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblTheaterName" runat="server" Text="Theater Name"></asp:Label>
                </td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtTheaterName" runat="server" CssClass="tbxStyle" Width="300px"></asp:TextBox>
                    <asp:Label ID="lbltname" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;">
                    <asp:Label ID="lblTheaterAddress" runat="server" Text="Theater Address"></asp:Label>
                </td>
                <td style="vertical-align: top;">:&nbsp;</td>
                <td style="vertical-align: top;">
                    <asp:TextBox ID="txtTheaterAddress" runat="server" CssClass="tbxStyle" Width="400px" TextMode="MultiLine" Rows="5"></asp:TextBox>
                    <asp:Label ID="lbladdress" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Theater Phone No"></asp:Label>
                </td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtPhNo" runat="server" CssClass="tbxStyle" Width="150px"></asp:TextBox>
                    <asp:Label ID="lblphno" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>

            <tr>
                <td colspan="3" style="padding-top: 15px;">
                    <asp:Button ID="btnSubmit" CssClass="btnStyle" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                    <asp:Button ID="btnClose" CssClass="btnStyle" runat="server" Text="Close" OnClick="btnClose_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlEdit" runat="server" Visible="false">
        <div style="height: 20px;"></div>
        <div class="subTitleLeft">Edit New Theater</div>
        <asp:HiddenField ID="hfEditId" runat="server" />

        <table>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Theater Name" Width="200px"></asp:Label>
                </td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtname" runat="server" CssClass="tbxStyle" Width="150px"></asp:TextBox>
                    <asp:Label ID="lbleditname" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;">
                    <asp:Label ID="label" runat="server" Text="Theater Address"></asp:Label>
                </td>
                <td style="vertical-align: top;">:&nbsp;</td>
                <td style="vertical-align: top;">
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="tbxStyle" Width="200px" TextMode="MultiLine" Rows="5"></asp:TextBox>
                    <asp:Label ID="lbleditaddress" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Theater Phone No"></asp:Label>
                </td>
                <td>:&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtPhoneno" runat="server" CssClass="tbxStyle" Width="150px"></asp:TextBox>
                    <asp:Label ID="lbleditphno" runat="server" CssClass="errStyle"></asp:Label>
                </td>
            </tr>

            <tr>
                <td colspan="3" style="padding-top: 15px;">
                    <asp:Button ID="btnUpdate" CssClass="btnStyle" runat="server" OnClick="btnUpdate_Click" Text="Update" />
                    <asp:Button ID="btnCancel" CssClass="btnStyle" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
