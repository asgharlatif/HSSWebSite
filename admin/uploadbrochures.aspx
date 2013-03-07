<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="uploadbrochures.aspx.cs" Inherits="admin_uploadbrochures" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
<link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">

<h1>
        Upload <asp:Label ID="lblDocumentype" runat="server"></asp:Label> against Product Number
        <asp:Label ID="lblProductId" runat="server" Text=""></asp:Label></h1>
    <p>
        <asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label>
    </p>


       <table id="tblCustomer" runat="server" border="0" cellpadding="3" cellspacing="0" width="100%">
        <tr>
            <td style="width: 150px;">
                Document Name</td>
            <td>
                <asp:DropDownList ID="ddlBrochureName" runat="server" Height="19px" 
                    Width="214px" Enabled="false">
                   
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="ddlBrochureName" ErrorMessage="Required field." 
                    ValidationGroup="Customer" ForeColor="#660033"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Language</td>
            <td>
                <asp:DropDownList ID="ddlLanguage" runat="server" Height="19px" 
                    Width="214px" Enabled="false">
                   
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="ddlLanguage" ErrorMessage="Required field." 
                    ValidationGroup="Customer" ForeColor="#660033"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Operating System</td>
            <td>
                <asp:DropDownList ID="ddlOS" runat="server" Height="19px" 
                    Width="214px" Enabled="false">
                   
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="ddlOS" ErrorMessage="Required field." 
                    ValidationGroup="Customer" ForeColor="#660033"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                 
                 <asp:Label runat="server" ID="DocDriverType" Text="(PDF,DOC,DOCX,XLS,XLSX,TXT)" />
                 </td>
            <td>
                <asp:FileUpload ID="flfPDF" runat="server" Width="290px" />

                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="flfPDF" ErrorMessage="Required field." 
                    ValidationGroup="Customer" ForeColor="#660033"></asp:RequiredFieldValidator>

                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="flfPDF" ErrorMessage="You must select a .pdf, .doc,.docx, .xls,.xlsx file to upload." 
                    ValidationExpression="^.+\.((doc)|(DOC)|(docx)|(DOCX)|(pdf)|(PDF)|(xls)|(XLS)(xlsx)|(XLSX)|(TXT)|(txt))$" ValidationGroup="Customer"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Thumb Nail (Image)</td>
            <td>
                <asp:FileUpload ID="flfThumbNail" runat="server" Width="290px" />
                
                    
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="flfThumbNail" ErrorMessage="You must select a .jpg, .png, .gif file to upload." 
                    ValidationExpression="^.+\.((jpg)|(JPG)|(png)|(PNG)|(gif)|(GIF))$" ValidationGroup="Customer"></asp:RegularExpressionValidator>

            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Description</td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" 
                    Width="479px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnAdd" runat="server"  Text="Add" ValidationGroup="Customer" 
                    onclick="btnAdd_Click" Width="100px" />
            </td>
        </tr>
    </table>

</asp:Content>

