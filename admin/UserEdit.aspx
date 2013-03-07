<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="UserEdit.aspx.cs" Inherits="admin_UserEdit" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
<h1>
        Edit User</h1>
    <p>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <br />
    <table border="0" cellpadding="3" cellspacing="0" width="100%">
        <tr>
            <td style="width: 150px">
                Login Id:</td>
            <td>
                <asp:Label ID="lblLoginId" runat="server" Width="202px">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 150px">
                Permissions:</td>
            <td>
                <asp:CheckBoxList ID="chkSecurityPageSections" runat="server">
                </asp:CheckBoxList></td>
        </tr>
        <tr>
            <td style="width: 150px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 150px">
            </td>
            <td>
                <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit" ValidationGroup="User" /></td>
        </tr>
    </table>
</asp:Content>

