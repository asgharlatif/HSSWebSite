<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="admin_ChangePassword" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        Change Password</h1>
    <div class="status_messages">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ChangePassword" />
        <asp:Label ID="lblChangePassword" runat="server"></asp:Label>
    </div>
    <table id="fieldtable" border="0" cellpadding="3" cellspacing="0" width="100%">
        <tr>
            <td style="width: 120px">
                Old Password:</td>
            <td>
                <asp:TextBox ID="txtoldpassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtoldpassword"
                    Display="None" ErrorMessage="Old password is required" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                New Password:</td>
            <td>
                <asp:TextBox ID="txtnewpasword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtnewpasword"
                    Display="None" ErrorMessage="New password is required" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                Confirm New Password:</td>
            <td>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPassword"
                    Display="None" ErrorMessage="Please confirm password" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtnewpasword"
                    ControlToValidate="txtConfirmPassword" Display="None" ErrorMessage="Password doesn't match"
                    ValidationGroup="ChangePassword"></asp:CompareValidator></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="btnChangePassword" runat="server" OnClick="btnChangePassword_Click"
                    Text="Change Password" ValidationGroup="ChangePassword" />&nbsp;<input id="Button2"
                        class="FormButtons" onclick="history.back()" type="button" value="Cancel" /></td>
        </tr>
    </table>
</asp:Content>

