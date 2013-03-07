<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="UserAdd.aspx.cs" Inherits="admin_UserAdd" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
 <h1>
        Add User</h1>
    <p>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <br />
    <table border="0" cellpadding="3" cellspacing="0" width="100%">
        <tr>
            <td style="width: 150px">
                Login Id:</td>
            <td>
                <asp:TextBox ID="txtLoginId" runat="server" Width="202px">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLoginId"
                    ErrorMessage="Login Id Required" ValidationGroup="User"></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td style="width: 150px">
                Password:</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" Width="202px" TextMode="Password">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="Password Required" ValidationGroup="User"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px">
                Confirm Password:</td>
            <td>
                <asp:TextBox ID="txtConfirmPassword" runat="server" Width="202px" TextMode="Password">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtConfirmPassword"
                    ErrorMessage="Confirm Password Required" ValidationGroup="User"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                    ControlToValidate="txtConfirmPassword" ErrorMessage="Password doesn't match"
                    ValidationGroup="User"></asp:CompareValidator></td>
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
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" ValidationGroup="User" /></td>
        </tr>
    </table>
 </asp:Content>

