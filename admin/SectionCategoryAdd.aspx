<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="SectionCategoryAdd.aspx.cs" Inherits="admin_SectionCategoryAdd" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        Add Section Category</h1>
    <p>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <br />
    <table border="0" cellpadding="3" cellspacing="0" width="100%">
        <tr>
            <td style="width: 150px">
                Category Name:</td>
            <td>
                <asp:TextBox ID="txtCategory" runat="server" Width="202px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCategory"
                    ErrorMessage="Category is Required." ValidationGroup="SectionCategory"></asp:RequiredFieldValidator></td>
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
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" ValidationGroup="SectionCategory" /></td>
        </tr>
    </table>
</asp:Content>

