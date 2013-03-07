<%@ Page AutoEventWireup="true" CodeFile="SubscriberEdit.aspx.cs" Inherits="admin_SubscriberEdit"
    Language="C#" MasterPageFile="~/admin/MasterPage.master" Theme="Admin" Title="" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="CPAdminHead">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" runat="Server" ContentPlaceHolderID="CPAdminBody">
    <h1>
        Edit Subscriber</h1>
    <p>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <br />
    <table border="0" cellpadding="3" cellspacing="0" width="100%">
        <tr>
            <td style="width: 150px">
                Group:</td>
            <td>
                <asp:DropDownList ID="ddlGroup" runat="server" Width="202px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlGroup"
                    ErrorMessage="Please select a group." ValidationGroup="Subscriber"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px">
                Email:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="202px">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Email Required" ValidationGroup="Subscriber"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Email is in incorrect format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
        </tr> 
        <tr>
            <td style="width: 150px">
                Name:</td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="202px">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtName"
                    ErrorMessage="Name Required" ValidationGroup="Subscriber"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px">
                Address:</td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" Width="300px" Height="150px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 150px">
                City:</td>
            <td>
                <asp:TextBox ID="txtCity" runat="server" Width="202px">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCity"
                    ErrorMessage="City Required" ValidationGroup="Subscriber"></asp:RequiredFieldValidator>
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
                <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit" ValidationGroup="Subscriber" /></td>
        </tr>
    </table>
</asp:Content>

