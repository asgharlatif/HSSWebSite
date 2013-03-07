<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="PageSectionAdd.aspx.cs" Inherits="PageSectionAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">

 <h1>
        <asp:Label ID="lblFormLabel" runat="server" >Add Main Page Section</asp:Label></h1>
        <p>
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <br />
    <table border="0" cellpadding="3" cellspacing="0" width="100%">
        <tr>
            <td style="width: 150px">
                Company:</td>
            <td>
                <asp:DropDownList ID="ddlCompany" runat="server" Width="202px"  
                    onselectedindexchanged="ddlCompany_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlCompany"
                    ErrorMessage="Please select a company." ValidationGroup="Category"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px">
                Page Part:</td>
            <td>
                <asp:DropDownList ID="ddlPagePartName" runat="server" Width="202px"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlPagePartName"
                    ErrorMessage="Please select part of page." ValidationGroup="Category"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px">
                Section Name:</td>
            <td>
                <asp:TextBox ID="txtSectionName" runat="server" Width="202px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSectionName"
                    ErrorMessage="Category is Required." ValidationGroup="Category"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px">
                Sorting Order:</td>
            <td>
                <asp:TextBox ID="txtSortingOrder" runat="server" Width="202px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSortingOrder"
                    ErrorMessage="Select sorting order." ValidationGroup="Category"></asp:RequiredFieldValidator></td>
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
                    ValidationGroup="Category" Width="73px" /></td>
        </tr>
    </table>

</asp:Content>

