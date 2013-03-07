<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="CompanyEdit.aspx.cs" Inherits="admin_CompanyEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
 <h1>
        Edit Company</h1>
        <p>
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <br />
    <table border="0" cellpadding="3" cellspacing="0" width="100%">
        <tr>
            <td style="width: 150px">
                Company Name:</td>
            <td>
                <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCompany" ErrorMessage="Company is Required."
                    ValidationGroup="Company"></asp:RequiredFieldValidator></td>
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
                <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Update" ValidationGroup="Company" /></td>
        </tr>
    </table>
</asp:Content>

