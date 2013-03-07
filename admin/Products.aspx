<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="admin_Products" Title="" Theme="Admin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <style type="text/css">

        .style4
        {
            color: #FFFFFF;
        }
        .style5
        {
            width: 100%;
        }
    </style>
    
    <link href="../Styles/ModelPopUp.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        Product Listing
    </h1>

     <p>
    Filter By: 
         <asp:ScriptManager ID="ScriptManager1" runat="server">
         </asp:ScriptManager>
                </p>
    <table class="style5">
        <tr>
            <td>
                Company</td>
            <td>
                Category</td>
            <td>
                Sub Sub Category</td>
            <td>
                Product Group</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlCompany" runat="server" Width="202px"  onselectedindexchanged="ddlCompany_SelectedIndexChanged" 
            AutoPostBack="True"></asp:DropDownList>
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
                <asp:DropDownList ID="ddlProductGroupCode" runat="server" Width="202px" 
                    onselectedindexchanged="ddlProductGroupCode_SelectedIndexChanged" 
                    AutoPostBack="True" CssClass="style4">
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlCompany"
                    Display="None" ErrorMessage="Select a company." ValidationGroup="Product" 
                    CssClass="style4"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlCategory"
                    Display="None" ErrorMessage="Select a category." ValidationGroup="Product" 
                    CssClass="style4"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlSubCategory"
                    Display="None" ErrorMessage="Select a sub category." 
                    ValidationGroup="Product" CssClass="style4"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlProductGroupCode"
                    Display="None" ErrorMessage="Select a product group code." 
                    ValidationGroup="Product" CssClass="style4"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <p>
        &nbsp;</p>

    <p>
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductId"
                    DataSourceID="ObjectDataSource1" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
                    OnRowDeleted="GridView1_RowDeleted" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
                    Width="600px" AllowSorting="true">
                    <Columns>
                        <asp:BoundField DataField="ProductId" HeaderText="ProductId" InsertVisible="False"
                            ReadOnly="True" SortExpression="ProductId"  />
                        
                        

                        <asp:BoundField DataField="ProductTitle" HeaderText="ProductTitle" SortExpression="ProductTitle" />
                        
                        
                        <asp:BoundField DataField="Sort" HeaderText="Sort" SortExpression="Sort" Visible="False" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description"
                            Visible="False" />
                        <asp:BoundField DataField="Model" HeaderText="Model" SortExpression="Model" Visible="False" />
                        <asp:BoundField DataField="MainImage" HeaderText="MainImage" SortExpression="MainImage"
                            Visible="False" />
                        <asp:BoundField DataField="TechnicalSpecs" HeaderText="TechnicalSpecs" SortExpression="TechnicalSpecs"
                            Visible="False" />
                        <asp:BoundField DataField="DateAdded" HeaderText="DateAdded" SortExpression="DateAdded" />
                       
                       
                       
                        <asp:TemplateField HeaderText="Manage">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("ProductId") %>'
                                    CommandName="Edit">Edit</asp:LinkButton>
                                |
                                <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%# Eval("ProductId") %>'
                                    CommandName="Delete">Delete</asp:LinkButton>
                                |
                                <asp:LinkButton ID="lbtnImage" runat="server" CommandArgument='<%# Eval("ProductId") %>'
                                    CommandName="Image">Image Gallery</asp:LinkButton>
                                |
                                <asp:LinkButton ID="lbtnFeatures" runat="server" CommandArgument='<%# Eval("ProductId") %>'
                                    CommandName="Features">Key Features</asp:LinkButton>
                                |
                                <asp:LinkButton ID="lbtnColor" runat="server" CommandArgument='<%# Eval("ProductId") %>'
                                    CommandName="Color">Color</asp:LinkButton>
                                |
                                <asp:LinkButton ID="lbtnTechnicalSpecs" runat="server" CommandArgument='<%# Eval("ProductId") %>'
                                    CommandName="TechnicalSpecs">Edit Technical Specs</asp:LinkButton>
                                &nbsp;|
                                <asp:LinkButton ID="lbtnFreeShipment" runat="server" CommandArgument='<%# Eval("ProductId") +";"+Eval("FreeShipment") %>'
                                    CommandName="FreeShipment" Text='<%# Eval("FreeShipment") %>' 
                                    ForeColor="#9933FF"></asp:LinkButton>

                                &nbsp; |

                                <asp:LinkButton ID="lbtnInStock" runat="server" CommandArgument='<%# Eval("ProductId") +";"+Eval("InStock") %>' 
                                CommandName="InStock" Text='<%# Eval("InStock") %>' ForeColor="Red"></asp:LinkButton>
                                &nbsp;|
                                <asp:LinkButton ID="lbtDocumentation" runat="server" CommandArgument='<%# Eval("ProductId") %>'
                                    CommandName="Documents">Add Documents</asp:LinkButton>
                                &nbsp;|
                                <asp:LinkButton ID="lbtDrivers" runat="server" CommandArgument='<%# Eval("ProductId") %>'
                                    CommandName="Drivers">Add Drivers</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ShowHeader="false" HeaderText="Prices"> 
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbtndetails" runat="server" ImageUrl="images/edit.jpg" Height="30px"
                                Width="30px" OnClick="imgbtn_Click" />
                        </ItemTemplate>
                </asp:TemplateField>

                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete"
                    InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData"
                    TypeName="dsProductTableAdapters.ProductTableAdapter" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_ProductId" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="CategoryId" Type="Int32" />
                        <asp:Parameter Name="ProductTitle" Type="String" />
                        <asp:Parameter Name="Sort" Type="Decimal" />
                        <asp:Parameter Name="Description" Type="String" />
                        <asp:Parameter Name="Model" Type="String" />
                        <asp:Parameter Name="MainImage" Type="String" />
                        <asp:Parameter Name="TechnicalSpecs" Type="String" />
                        <asp:Parameter Name="DateAdded" Type="DateTime" />
                        <asp:Parameter Name="Original_ProductId" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="CategoryId" Type="Int32" />
                        <asp:Parameter Name="ProductTitle" Type="String" />
                        <asp:Parameter Name="Sort" Type="Decimal" />
                        <asp:Parameter Name="Description" Type="String" />
                        <asp:Parameter Name="Model" Type="String" />
                        <asp:Parameter Name="MainImage" Type="String" />
                        <asp:Parameter Name="TechnicalSpecs" Type="String" />
                        <asp:Parameter Name="DateAdded" Type="DateTime" />
                    </InsertParameters>
                </asp:ObjectDataSource>

    <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup"
        PopupControlID="pnlpopup" CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>

        <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="400px" 
        Width="430px" ScrollBars="Auto">
            <table width="100%" style="border: Solid 3px #D55500; width: 100%; height: 100%"
                cellpadding="0" cellspacing="0" class="PricePanel" >
                <tr>
                    <td>
                        <table class="style5">
                            <tr>
                                <td>
                                    Product Id (<asp:Label ID="lblProductId" runat="server" ></asp:Label>)
                                    <asp:Label ID="lblItemName" runat="server" Font-Size="Larger" Text="Item Name" 
                                        Width="300px"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button ID="btnCancel" runat="server" Text="Close" Width="61px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GrdPrices" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="ProductId" HeaderText="ProductId" 
                                    InsertVisible="False" ReadOnly="True" SortExpression="ProductId" />
                                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                                <asp:BoundField DataField="Date" HeaderText="Date Added" 
                                    SortExpression="Date" />
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="lblPriceNotDefined" runat="server" Font-Size="Large" 
                            ForeColor="Maroon" style="text-align: center" Text="Price Not Defined." 
                            Width="300px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="style5">
                            <tr>
                                <td>
                                    New Price</td>
                                <td>
                                    <asp:TextBox ID="txtPrice" runat="server" Width="149px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                        ControlToValidate="txtPrice" ErrorMessage="Price is required field." 
                                        ValidationGroup="PriceUpdate"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="btnUpdate" runat="server" CommandName="Update" 
                                        OnClick="btnUpdate_Click" Text="Update" ValidationGroup="PriceUpdate" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                     
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>



</asp:Content>

