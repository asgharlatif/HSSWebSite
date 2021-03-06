﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="ProductGroupAdd.aspx.cs" Inherits="admin_ProductGroupAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>

        
        <asp:Label ID="lblFormLabel" runat="server" >Add Product Group</asp:Label>
        </h1>
        <p>
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <br />
    <table border="0" cellpadding="3" cellspacing="0" width="100%">
        <tr>
            <td style="width: 150px">
                Select
                Company:</td>
            <td>
                <asp:DropDownList ID="ddlCompany" runat="server" Width="202px" 
                    AutoPostBack="True" onselectedindexchanged="ddlCompany_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCompany"
                    ErrorMessage="Please select a company." ValidationGroup="Category"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px">
                Select Category:</td>
            <td>
                <asp:DropDownList ID="ddlCategory" runat="server" Width="202px" 
                    onselectedindexchanged="ddlCategory_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCategory"
                    ErrorMessage="Please select a category" ValidationGroup="Category"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px">
                Select Sub Category</td>
            <td>
                <asp:DropDownList ID="ddlSubCategory" runat="server" Width="202px" 
                    onselectedindexchanged="ddlSubCategory_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlSubCategory"
                    ErrorMessage="Please select a sub category" ValidationGroup="Category"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 150px">
                Product Group Name:</td>
            <td>
                <asp:TextBox ID="txtProductGroupName" runat="server" Width="202px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProductGroupName"
                    ErrorMessage="Product Group Name is Required." ValidationGroup="Category"></asp:RequiredFieldValidator></td>
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
                    ValidationGroup="Category" Width="75px" /></td>
        </tr>
    </table>
</asp:Content>

