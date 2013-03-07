<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="FAQsAdd.aspx.cs" Inherits="admin_FAQsAdd" Title="" Theme="Admin" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        Add Questions</h1>
    <br />
    <p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="FAQs" />
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <table border="0" cellpadding="3" cellspacing="0" width="100%">
        <tr>
            <td style="width: 150px">
                Select Section:</td>
            <td>
                <asp:DropDownList ID="ddlSection" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlSection"
                    Display="None" ErrorMessage="Select a section." ValidationGroup="FAQs"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px">
                Question:</td>
            <td>
                <asp:TextBox ID="txtQuestion" runat="server" Height="100px" TextMode="MultiLine"
                    Width="350px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtQuestion"
                    Display="None" ErrorMessage="Question Required." ValidationGroup="FAQs"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px">
                Answer:</td>
            <td>
                <ftb:freetextbox id="txtAnswer" runat="server"></ftb:freetextbox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAnswer"
                    Display="None" ErrorMessage="Answer Required." ValidationGroup="FAQs"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px">
                Sort:</td>
            <td>
                <asp:TextBox ID="txtSortOrder" runat="server" Width="300px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSortOrder"
                    Display="None" ErrorMessage="Sort Order Format is Incorrect" ValidationExpression="^\d+(?:\.\d{0,2})?$"
                    ValidationGroup="FAQs"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSortOrder"
                    Display="None" ErrorMessage="Sort Required" ValidationGroup="FAQs"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px">
            </td>
            <td>
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" ValidationGroup="FAQs" /></td>
        </tr>
    </table>
</asp:Content>

