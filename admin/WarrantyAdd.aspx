<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="WarrantyAdd.aspx.cs" Inherits="admin_WarrantyAdd" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        </h1>
    <asp:Label ID="lblWarranty" runat="server" Text="Add Warranty"></asp:Label>
        <p>
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <br />
    <table border="0" cellpadding="3" cellspacing="0" width="100%">
        <tr>
            <td style="width: 150px">
                Warranty Name:</td>
            <td>
                <asp:TextBox ID="txtWatName" runat="server" Width="202px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtWatName"
                    ErrorMessage="Warranty Name is Required." ValidationGroup="Company"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px;>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 150px">
            </td>
            <td>
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" 
                    ValidationGroup="Company" /></td>
        </tr>
    </table>
</asp:Content>

