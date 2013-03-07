<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="CategoryEdit.aspx.cs" Inherits="admin_CategoryEdit" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        Edit Category</h1>
        <p>
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <br />
    <table border="0" cellpadding="3" cellspacing="0" width="100%">
        <tr>
            <td style="width: 150px">
                Company:</td>
            <td>
                <asp:DropDownList ID="ddlCompany" runat="server" Width="202px"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCompany"
                    ErrorMessage="Please select a company." ValidationGroup="Category"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px">
                Category Name:</td>
            <td>
                <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCategory" ErrorMessage="Category is Required."
                    ValidationGroup="Category"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px;">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 150px">
            </td>
            <td>
                <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Update" ValidationGroup="Category" /></td>
        </tr>
    </table>
</asp:Content>

