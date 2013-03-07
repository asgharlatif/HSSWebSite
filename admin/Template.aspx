<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="Template.aspx.cs" Inherits="Template" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
<link rel="stylesheet" type="text/css" href="../App_Themes/Admin/StyleSheet.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">

<h1>Page Title</h1>


<table width="100%" border="0" cellspacing="0" cellpadding="3">
  <tr>
    <td style="width:150px;">Title</td>
    <td><asp:TextBox ID="txtTitle" runat=server></asp:TextBox></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td><asp:Button ID="Button1" runat="server" Text="Button" /></td>
  </tr>
</table>
</asp:Content>