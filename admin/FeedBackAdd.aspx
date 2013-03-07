<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="FeedBackAdd.aspx.cs" Inherits="admin_FeedBackAdd" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        Add Feedback</h1>
    <p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="FeedBack" />
        <asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label>&nbsp;</p>
    <br />
    <table id="tblCustomer" runat="server" border="0" cellpadding="3" cellspacing="0"
        width="100%">
        <tr>
            <td style="width: 150px;">
                Name:</td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                    Display="None" ErrorMessage="Name Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Email:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                    Display="None" ErrorMessage="Email Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                    Display="None" ErrorMessage="Invalid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ValidationGroup="FeedBack"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Phone:</td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPhone"
                    Display="None" ErrorMessage="Phone Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                City:</td>
            <td>
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCity"
                    Display="None" ErrorMessage="City Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Occupation:</td>
            <td>
                <asp:TextBox ID="txtOccupation" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtOccupation"
                    Display="None" ErrorMessage="Occupation Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Company:</td>
            <td>
                <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCompany"
                    Display="None" ErrorMessage="Company Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Age:</td>
            <td>
                <asp:DropDownList ID="ddlAge" runat="server">
                    <asp:ListItem Value="">please select one</asp:ListItem>
                    <asp:ListItem Value="<18"><18</asp:ListItem>
                    <asp:ListItem Value="18-25">18-25</asp:ListItem>
                    <asp:ListItem Value="26-30">26-30</asp:ListItem>
                    <asp:ListItem Value="31-40">31-40</asp:ListItem>
                    <asp:ListItem Value="41-50">41-50</asp:ListItem>
                    <asp:ListItem Value=">50">>50</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlAge"
                    Display="None" ErrorMessage="Age Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Comments:</td>
            <td>
                <asp:TextBox ID="txtComments" runat="server" Width="300" Height="150" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtComments"
                    Display="None" ErrorMessage="Comments Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" ValidationGroup="FeedBack" /></td>
        </tr>
    </table>
</asp:Content>

