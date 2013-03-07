<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="DownloadAdd.aspx.cs" Inherits="admin_DownloadAdd" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        Add Download</h1>
    <p>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <br />
    <table border="0" cellpadding="3" cellspacing="0" width="100%">
        <tr>
            <td style="width: 150px">
                Category:</td>
            <td>
                <asp:DropDownList ID="ddlCategory" runat="server" Width="202px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCategory"
                    ErrorMessage="Category is Required." ValidationGroup="Download"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px">
                Title:</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="202px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitle"
                    ErrorMessage="Title is Required." ValidationGroup="Download"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px">
                Upload:</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" Width="202px"></asp:FileUpload>
             </td>
        </tr>
        <tr>
            <td style="width: 150px">
                External Link:</td>
            <td>
                <asp:TextBox ID="txtExternalLink" runat="server" Width="202px"></asp:TextBox>
            </td>
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
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" ValidationGroup="Download" /></td>
        </tr>
    </table>
</asp:Content>

