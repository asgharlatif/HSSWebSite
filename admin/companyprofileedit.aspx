<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="companyprofileedit.aspx.cs" Inherits="admin_companyprofileedit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
<link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
    <style type="text/css">
        .style1
        {
            text-align: right;
        }
        .style2
        {
            width: 100%;
        }
        .style3
        {
            width: 364px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
<h1>
        Manage Company Profile (<asp:Label ID="lblCompany" 
            runat="server" Text="."></asp:Label>
        )</h1>
        <p>
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <br />
    <table border="0" cellpadding="3" cellspacing="0" width="100%">
        <tr>
            <td style="width: 150px" class="style1">
                About Company</td>
            <td>
                <asp:TextBox ID="txtAboutCompany" runat="server" Height="128px" 
                    MaxLength="8000" TextMode="MultiLine" Width="694px"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtAboutCompany" ErrorMessage="Basic Company Introduction  is a required field"
                    ValidationGroup="Company"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 150px;" class="style1">
                Brand</td>
            <td>
                <asp:TextBox ID="txtBrand" runat="server" Height="26px" MaxLength="150" 
                    Width="694px"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtBrand" ErrorMessage="Brand Name  is a required field"
                    ValidationGroup="Company"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;" class="style1">
                Owner
            </td>
            <td>
                <asp:TextBox ID="txtOwner" runat="server" Height="26px" MaxLength="100" 
                    Width="694px"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtOwner" ErrorMessage="Owner Name  is a required field"
                    ValidationGroup="Company"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;" class="style1">
                Year Established</td>
            <td>
                <asp:TextBox ID="txtYearEstablished" runat="server" Height="26px" 
                    MaxLength="100" Width="694px"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtYearEstablished" ErrorMessage="Year Established  is a required field"
                    ValidationGroup="Company"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;" class="style1">
                Contact</td>
            <td>
                <asp:TextBox ID="txtContact" runat="server" Height="26px" MaxLength="100" 
                    Width="694px"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtContact" ErrorMessage="Contact detail  is a required field"
                    ValidationGroup="Company"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;" class="style1">
                Email</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Height="26px" MaxLength="200" 
                    Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtEmail" ErrorMessage="Email Address  is a required field"
                    ValidationGroup="Company"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                    runat="server" ControlToValidate="txtEmail"
                     Display="None" ErrorMessage="Invalid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                     ValidationGroup="Company"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;" class="style1">
                Tel1</td>
            <td>
                <asp:TextBox ID="txtTel1" runat="server" Height="26px" MaxLength="150" 
                    Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="txtTel1" ErrorMessage="Telephone Number  is a required field"
                    ValidationGroup="Company"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;" class="style1">
                Fax1</td>
            <td>
                <asp:TextBox ID="txtFax1" runat="server" Height="26px" MaxLength="150" 
                    Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="txtFax1" ErrorMessage="Fax Number  is a required field"
                    ValidationGroup="Company"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;" class="style1">
                URL</td>
            <td>
                <asp:TextBox ID="txtURL" runat="server" Height="26px" MaxLength="150" 
                    Width="694px"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="txtURL" ErrorMessage="URL address  is a required field"
                    ValidationGroup="Company"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;" class="style1">
                Zip Code</td>
            <td>
                <asp:TextBox ID="txtZipCode" runat="server" Height="26px" MaxLength="150" 
                    Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator10" runat="server" 
                    ControlToValidate="txtZipCode" ErrorMessage="Zip Code  is a required field"
                    ValidationGroup="Company"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;" class="style1">
                Address</td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" Height="26px" MaxLength="500" 
                    Width="694px"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator11" runat="server" 
                    ControlToValidate="txtAddress" ErrorMessage="Company Address  is a required field"
                    ValidationGroup="Company"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;" class="style1">
                Business Type</td>
            <td>
                <asp:TextBox ID="txtBusinessType" runat="server" Height="26px" MaxLength="250" 
                    Width="694px"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator12" runat="server" 
                    ControlToValidate="txtBusinessType" ErrorMessage="Business type  is a required field"
                    ValidationGroup="Company"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;" class="style1">
                Main Products</td>
            <td>
                <asp:TextBox ID="txtMainProduct" runat="server" Height="26px" MaxLength="2000" 
                    Width="694px"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator13" runat="server" 
                    ControlToValidate="txtMainProduct" ErrorMessage="Main Products  is a required field"
                    ValidationGroup="Company"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;" class="style1">
                Main Markets</td>
            <td>
                <asp:TextBox ID="txtMainMarket" runat="server" Height="26px" MaxLength="2000" 
                    Width="694px"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator14" runat="server" 
                    ControlToValidate="txtMainMarket" ErrorMessage="Main Market  is a required field"
                    ValidationGroup="Company"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;" class="style1">
                Approval / Certificate</td>
            <td>
                <asp:TextBox ID="txtApprovalCertificate" runat="server" Height="26px" 
                    MaxLength="500" Width="694px"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator15" runat="server" 
                    ControlToValidate="txtApprovalCertificate" ErrorMessage="Approval / Certificate  is a required field"
                    ValidationGroup="Company"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;" class="style1">
                Membership</td>
            <td>
                <asp:TextBox ID="txtMembership" runat="server" Height="26px" MaxLength="500" 
                    Width="694px"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator16" runat="server" 
                    ControlToValidate="txtMembership" ErrorMessage="Membership is a required field"
                    ValidationGroup="Company"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;" class="style1">
                &nbsp;</td>
            <td>
                <table class="style2">
                    <tr>
                        <td class="style3">
                            Company Logo:-</td>
                        <td>
                            <asp:Label ID="lblLogoName" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </td>
                        <td>
                            <asp:Image ID="Image1" runat="server" style="margin-left: 0px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 150px">
            </td>
            <td>
                <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Update" ValidationGroup="Company" /></td>
        </tr>
    </table>
</asp:Content>

