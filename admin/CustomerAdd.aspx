<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerAdd.aspx.cs" Inherits="admin_CustomerAdd" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        Add Customer</h1>
    <p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Customer" />
        <asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label>&nbsp;</p>
    <br />
    <table id="tblCustomer" runat="server" border="0" cellpadding="3" cellspacing="0" width="100%">
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
                Email:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                    Display="None" ErrorMessage="Email Required" ValidationGroup="Customer"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                    Display="None" ErrorMessage="Invalid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ValidationGroup="Customer"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Password:</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword"
                    Display="None" ErrorMessage="Password Required" ValidationGroup="Customer"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                    ControlToValidate="txtConfirmPassword" Display="None" ErrorMessage="Password doesn't match"
                    ValidationGroup="Customer"></asp:CompareValidator></td>
        </tr>
        <tr>
            <td style="width: 150px">
                Confirm Password:</td>
            <td>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtConfirmPassword"
                    Display="None" ErrorMessage="Confirm Password Required" ValidationGroup="Customer"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Address:</td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Width="300" Height="150"></asp:TextBox>
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
                    <asp:ListItem Value="True" Selected="True">Yes</asp:ListItem>
                    <asp:ListItem Value="False">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" ValidationGroup="Customer" /></td>
        </tr>
    </table>
</asp:Content>

