<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="ProductKeyFeaturesAdd.aspx.cs" Inherits="admin_ProductKeyFeaturesAdd" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        Add Product Key Features</h1>
        <p>
            <asp:Label ID="lblMsg" runat="server" ForeColor="#FF0000"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ProductImage" />
        </p>
    <table id="tblProductKeyFeatures" runat="server" cellpadding="3" cellspacing="0"
        width="100%">
       
        <tr>
            <td style="width: 150px;">
                Product Name:</td>
            <td>
                <asp:Label ID="lblProductName" runat="server"></asp:Label></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Sort Order:
            </td>
            <td>
                <asp:TextBox ID="txtSortOrder" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSortOrder"
                    Display="None" ErrorMessage="Sort Order Format is Incorrect" ValidationExpression="^\d+(?:\.\d{0,2})?$"
                    ValidationGroup="ProductImage"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtSortOrder"
                    Display="None" ErrorMessage="Sort Order Missing" ValidationGroup="ProductImage"></asp:RequiredFieldValidator></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Image Upload:</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="FileUpload1"
                    Display="None" ErrorMessage="Invalid Picture Upload Image Format" ValidationExpression="(.*?)\.(jpg|Jpg|JPG|Jpeg|JPEG|jpeg|PNG|Png|png|Gif|GIF|gif)$"
                    ValidationGroup="ProductImage"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="FileUpload1"
                    Display="None" ErrorMessage="Image Required for Picture Upload Field" ValidationGroup="ProductImage"></asp:RequiredFieldValidator></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Title:</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" TextMode="SingleLine" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                    Display="None" ErrorMessage="Title Missing" ValidationGroup="ProductImage"></asp:RequiredFieldValidator></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Description:</td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" Height="200px" TextMode="MultiLine"
                    Width="99%"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
            </td>
            <td>
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" ValidationGroup="ProductImage"
                    Width="64px" /></td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>

