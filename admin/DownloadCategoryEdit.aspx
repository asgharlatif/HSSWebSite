<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="DownloadCategoryEdit.aspx.cs" Inherits="admin_DownloadCategoryEdit" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        Edit Download Category</h1>
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
                    ErrorMessage="Category is Required." ValidationGroup="DownloadCategory"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="">
                Image:</td>
            <td style="">
                <asp:Image ID="Image1" runat="server"></asp:Image>
                <asp:Label ID="lblImage" runat="server" Visible="false"></asp:Label>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="FileUpload1"
                    ErrorMessage="Invalid Image Format" ValidationExpression="(.*?)\.(jpg|Jpg|JPG|Jpeg|JPEG|jpeg|PNG|Png|png|Gif|GIF|gif)$"
                    ValidationGroup="DownloadCategory"></asp:RegularExpressionValidator>
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
                <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit" ValidationGroup="DownloadCategory" /></td>
        </tr>
    </table>
</asp:Content>

