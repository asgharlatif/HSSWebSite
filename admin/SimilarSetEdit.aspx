<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="SimilarSetEdit.aspx.cs" Inherits="admin_SimilarSetEdit" Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">

<h1>
        Edit Set Name (<asp:Label ID="lblSetName" runat="server" Text="Label"></asp:Label>)</h1>
    
        <p>
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <br />

    <table border="0" cellpadding="3" cellspacing="0" width="100%">
        <tr>
            <td style="width: 150px">
                Set Name:</td>
            <td>
                <asp:TextBox ID="txtSetName" runat="server" Width="413px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSetName"
                    ErrorMessage="Set Name is Required." ValidationGroup="SameSet"></asp:RequiredFieldValidator></td>
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
                <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit" 
                    ValidationGroup="SameSet" Width="82px" /></td>
        </tr>
    </table>
</asp:Content>

