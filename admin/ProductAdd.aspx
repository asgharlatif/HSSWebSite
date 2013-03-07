<%@ Page Language="C#"  MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="ProductAdd.aspx.cs" Inherits="admin_ProductAdd" Title="" Theme="Admin" ValidateRequest="false" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>


<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
    <style type="text/css">
        .style1
        {
            width: 150px;
            height: 96px;
        }
        .style2
        {
            height: 96px;
        }
        .style3
        {
            background-color: #999999;
        }
        .style4
        {
            color: #FFFFFF;
        }
        .style5
        {
            color: #FFFFFF;
            background-color: #999999;
        }
        .style6
        {
            background-color: #999999;
            width: 544px;
        }
        .style7
        {
            width: 544px;
        }
        .style8
        {
            height: 96px;
            width: 544px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        
        <asp:Label ID="lblPageFunction" runat="server" Text="Add Product"></asp:Label>
        </h1>
    <br />
    <p>
        &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Product" />
       
    <p>
       
    <asp:Label ID="lblMsg" runat="server" ></asp:Label>
    </p>
       

    <table border="0" cellpadding="3" cellspacing="0" width="100%">
    <tr>
    <td colspan="4">
        <table width="100%" style="background-color: #99CCFF">
        
        <tr>
        <td>Company
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlCompany"
                    Display="None" ErrorMessage="Select a company." ValidationGroup="Product" 
                    CssClass="style4"></asp:RequiredFieldValidator>
            </td>
        <td>Category<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlCategory"
                    Display="None" ErrorMessage="Select a category." ValidationGroup="Product" 
                    CssClass="style4"></asp:RequiredFieldValidator>
            </td>
        <td>Sub Category<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlSubCategory"
                    Display="None" ErrorMessage="Select a sub category." 
                    ValidationGroup="Product" CssClass="style4"></asp:RequiredFieldValidator>
            </td>
        <td>Product Group Code<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlProductGroup"
                    Display="None" ErrorMessage="Select a product group." 
                    ValidationGroup="Product" CssClass="style4"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
        <td>
                <asp:DropDownList ID="ddlCompany" runat="server" Width="298px" 
            onselectedindexchanged="ddlCompany_SelectedIndexChanged" 
            AutoPostBack="True" Height="38px" CssClass="style4"></asp:DropDownList>
                </td>
        <td>
                <asp:DropDownList ID="ddlCategory" runat="server" Width="202px" 
                    AutoPostBack="True" CssClass="style4" 
                    onselectedindexchanged="ddlCategory_SelectedIndexChanged">
                </asp:DropDownList>
                </td>
        <td>
                <asp:DropDownList ID="ddlSubCategory" runat="server" Width="202px" 
                    onselectedindexchanged="ddlSubCategory_SelectedIndexChanged" 
                    AutoPostBack="True" CssClass="style4">
                </asp:DropDownList>
                </td>
        <td>
                <asp:DropDownList ID="ddlProductGroup" runat="server" Width="202px" 
                    CssClass="style4">
                </asp:DropDownList>
                </td>
        </tr>
        </table>

    </td>
    </tr>
        <tr>
            <td style="width: 150px">
                Product Title:</td>
            <td class="style7">
                <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                    Display="None" ErrorMessage="Product Title Required." ValidationGroup="Product"></asp:RequiredFieldValidator></td>
            <td>
                Main Image:</td>
            <td>
                <asp:Image ID="Image1" runat="server" />
                <br />
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="FileUpload1"
                    Display="None" ErrorMessage="Invalid Picture Upload Image Format" ValidationExpression="(.*?)\.(jpg|Jpg|JPG|Jpeg|JPEG|jpeg|PNG|Png|png|Gif|GIF|gif)$"
                    ValidationGroup="Product" Width="151px" Height="16px"></asp:RegularExpressionValidator>
                <asp:Label ID="lblLargeImage" runat="server" Visible="False"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="width: 150px">
                Short Description:</td>
            <td class="style7">
                <asp:TextBox ID="txtDescription" runat="server" Height="41px" TextMode="MultiLine"
                    Width="476px"></asp:TextBox></td>
            <td>
                Technical Specs:
                </td>
            <td>
                <br />
                <asp:TextBox ID="txtTechnicalSpecs" runat="server" Height="26px" 
                    TextMode="MultiLine" Width="370px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 150px">
                Model Number::</td>
            <td class="style7">
                <asp:TextBox ID="txtModel" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtModel"
                    Display="None" ErrorMessage="Model Number Required." ValidationGroup="Product"></asp:RequiredFieldValidator>&nbsp;</td>
            <td>
                Warranty</td>
            <td>
                <asp:DropDownList ID="ddlBas_Warranties" runat="server" Width="202px" 
                    CssClass="style4">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlBas_Warranties"
                    Display="None" ErrorMessage="Select warranty code." 
                    ValidationGroup="Product"></asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td style="width: 150px">
                Part Number :-</td>
            <td class="style7">
                <asp:TextBox ID="txtPartNumber" runat="server" Width="300px"></asp:TextBox>
                </td>
            <td>
                Brand</td>
            <td>
                <asp:DropDownList ID="ddlBas_Brands" runat="server" Width="202px" 
                    CssClass="style4">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlBas_Warranties"
                    Display="None" ErrorMessage="Select Product Brand Code." 
                    ValidationGroup="Product"></asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td style="width: 150px">
                Sort:</td>
            <td class="style7">
                <asp:TextBox ID="txtSortOrder" runat="server" Width="300px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSortOrder"
                    Display="None" ErrorMessage="Sort Order Format is Incorrect" ValidationExpression="^\d+(?:\.\d{0,2})?$"
                    ValidationGroup="Product"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSortOrder"
                    Display="None" ErrorMessage="Sort Required" ValidationGroup="Product"></asp:RequiredFieldValidator></td>
            <td>
                ThumbNail Image (90 X 90)</td>
            <td>
                <asp:Image ID="ImageTN" runat="server" />
                <br />
                <asp:FileUpload ID="FileUploadTN" runat="server" />
                <asp:Label ID="lblLargeImageTN" runat="server" Visible="False"></asp:Label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="FileUploadTN"
                    Display="None" ErrorMessage="Invalid Picture Upload Image Format" ValidationExpression="(.*?)\.(jpg|Jpg|JPG|Jpeg|JPEG|jpeg|PNG|Png|png|Gif|GIF|gif)$"
                    ValidationGroup="Product" Width="240px"></asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                &nbsp;</td>
            <td style="background-color: #f3f3f3" class="style7">
                Video Link:</td>
            <td style="background-color: #f3f3f3">
                &nbsp;</td>
            <td style="background-color: #f3f3f3">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 150px;">
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" ValidationGroup="Product" /></td>
            <td style="background-color: #f3f3f3" class="style7">
                <asp:TextBox ID="txtVideoLink" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td style="background-color: #f3f3f3">
                Video Image:</td>
            <td style="background-color: #f3f3f3">
                <asp:Image ID="VideoImage" runat="server" />
                <br />
                <asp:FileUpload ID="FileUpload4" runat="server" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="FileUpload4"
                    Display="None" ErrorMessage="Video image format is incorrect" ValidationExpression="(.*?)\.(jpg|Jpg|JPG|jpeg|Jpeg|JPEG|gif|Gif|GIF|png|Png|PNG)$"
                    ValidationGroup="Product"></asp:RegularExpressionValidator>
                <br />
                <asp:Label ID="lblVideoImage" runat="server" Visible="False"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="width: 150px">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                </td>
            <td class="style8">
                <FTB:FreeTextBox ID="txtDownloadInformation" runat="server" Height="5px" 
                    Width="400px" Visible="False"></FTB:FreeTextBox>
            </td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 150px">
            </td>
            <td class="style7">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

