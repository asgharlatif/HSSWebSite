<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="ColorEdit.aspx.cs" Inherits="admin_ColorEdit" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        Edit Color</h1>
    <p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Color" />
        <asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label>&nbsp;</p>
    <table border="0" cellpadding="3" cellspacing="0" width="100%" runat="server" id="tblColor">
        <tr>
            <td style="width: 156px;">
                Title</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" Display="None"
                    ErrorMessage="Title Required" ValidationGroup="Color"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 156px;">
                Hexa Code</td>
            <td>
                <asp:TextBox ID="txtHexaCode" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHexaCode" Display="None"
                    ErrorMessage="Hexa Code Required" ValidationGroup="Color"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 156px">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" ValidationGroup="Color" /></td>
        </tr>
    </table>
</asp:Content>

