<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="NewsEdit.aspx.cs" Inherits="admin_NewsEdit" Title="" Theme="Admin" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
<link rel="stylesheet" type="text/css" href="js/jquery-ui-1.8.custom.css"/>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/ui.core.js" type="text/javascript"></script>
    <script src="js/ui.datepicker.js" type="text/javascript"></script>
    <script type="text/javascript">
      $(document).ready(function(){
        $("#ctl00_CPAdminBody_txtStartDate").datepicker();
      });
       $(document).ready(function(){
        $("#ctl00_CPAdminBody_txtEndDate").datepicker();
      });
    </script>

    <h1>
        Edit News</h1>
    <p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="News" />
        <asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label>&nbsp;
    </p>
    <br />
    <table id="tblColor" runat="server" border="0" cellpadding="3" cellspacing="0" width="100%">
        <tr>
            <td style="width: 150px;">
                Type</td>
            <td>
                <asp:DropDownList ID="ddlType" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlType"
                    Display="None" ErrorMessage="Type Required" ValidationGroup="News"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Title</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                    Display="None" ErrorMessage="Title Required" ValidationGroup="News"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Start Date</td>
            <td>
                <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtStartDate"
                    Display="None" ErrorMessage="Start Date Required" ValidationGroup="News"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Short Description</td>
            <td>
                <asp:TextBox ID="txtShortDescription" runat="server" Height="100px" TextMode="MultiLine"
                    Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Long Description</td>
            <td>
                <ftb:freetextbox id="txtLongDescription" runat="server"></ftb:freetextbox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtLongDescription"
                    Display="None" ErrorMessage="Long Description Required" ValidationGroup="News"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Main Image:</td>
            <td>
                <asp:Image ID="Image1" runat="server" />
                <asp:Label ID="lblImage" runat="server" Visible="false"></asp:Label>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="FileUpload1"
                    Display="None" ErrorMessage="Invalid Image Format" ValidationExpression="(.*?)\.(jpg|Jpg|JPG|Jpeg|JPEG|jpeg|PNG|Png|png|Gif|GIF|gif)$"
                    ValidationGroup="News"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>&nbsp;
                </td>
            <td>
                <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit" ValidationGroup="News" /></td>
        </tr>
    </table>
</asp:Content>

