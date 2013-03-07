<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerEdit.aspx.cs" Inherits="admin_CustomerEdit" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        Edit Customer</h1>
    <p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Customer" />
        <asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label>&nbsp;</p>
    <br />
    <table id="tblCustomer" runat="server" border="0" cellpadding="3" cellspacing="0"
        width="100%">
        <tr>
            <td style="width: 150px;">
                Name:</td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                    Display="None" ErrorMessage="Name Required" ValidationGroup="Customer"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Address:</td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" Height="150" TextMode="MultiLine" Width="300"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAddress"
                    Display="None" ErrorMessage="Address Required" ValidationGroup="Customer"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px;">
                City:</td>
            <td>
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCity"
                    Display="None" ErrorMessage="City Required" ValidationGroup="Customer"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Subscribe to NewsLetter?:</td>
            <td>
                <asp:RadioButtonList ID="rblNewsLetter" runat="server">
                    <asp:ListItem Value="True">Yes</asp:ListItem>
                    <asp:ListItem Value="False">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit" ValidationGroup="Customer" /></td>
        </tr>
    </table>
</asp:Content>

