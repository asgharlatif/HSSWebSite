<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="PermissionDenied.aspx.cs" Inherits="admin_PermissionDenied" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
 <h1>
        Permission Denied</h1>
    <p>
         <asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label>
     </p>
</asp:Content>

