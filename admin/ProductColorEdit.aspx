<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="ProductColorEdit.aspx.cs" Inherits="admin_ProductColorEdit" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        Edit Product Color</h1>
    <p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Color" />
        <asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label>&nbsp;</p>
    <br />
    <table id="tblColor" runat="server" border="0" cellpadding="3" cellspacing="0" width="100%">
        <tr>
            <td style="width: 150px;">
                Product Title</td>
            <td>
                <asp:Label ID="lblProductTitle" runat="server"></asp:Label>
                <asp:Label ID="lblProductId" runat="server" Visible="false"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Color</td>
            <td>
                <asp:DropDownList ID="ddlColors" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlColors"
                    Display="None" ErrorMessage="Please select a color" ValidationGroup="Color"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Image</td>
            <td>
                <asp:Image ID="Image1" runat="server"/>
                <asp:Label ID="lblImage" runat="server" Visible="false"></asp:Label>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="FileUpload1"
                    Display="None" ErrorMessage="Only Gif,Jpeg and PNG Images are allowed" ValidationExpression="(.*?)\.(jpg|Jpg|JPG|Jpeg|JPEG|jpeg|PNG|Png|png|Gif|GIF|gif)$"
                    ValidationGroup="Color"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Sort Order</td>
            <td>
                <asp:TextBox ID="txtSortOrder" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSortOrder"
                    Display="None" ErrorMessage="Sort Order Required" ValidationGroup="Color"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                        ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtSortOrder"
                        Display="None" ErrorMessage="Sort Order format is incorrect" ValidationExpression="^\s*\d+(\.\d{1,4})?\s*$"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit" ValidationGroup="Color" /></td>
        </tr>
    </table>
</asp:Content>

