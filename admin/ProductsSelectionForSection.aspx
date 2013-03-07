<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="ProductsSelectionForSection.aspx.cs" Inherits="admin_ProductsSelectionForSection" Title="" Theme="Admin" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        Product Listing (<asp:Label ID="lblSectionName" runat="server" ></asp:Label>)
    </h1>

     <p>
    Filter By: <asp:Label ID="lblGroupLevel" runat="server"></asp:Label>
                </p>
    <table class="style5">
        <tr>
            <td>
                Company</td>
            <td>
                Category</td>
            <td>
                Sub Category</td>
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
                            ReadOnly="True" SortExpression="ProductId" Visible="False" />
                        
                        

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
                                        
                                <asp:LinkButton ID="btnAddRemoveSelection" runat="server" CommandArgument='<%# Eval("ProductId") %>'
                                    CommandName="AddRemove" Text='<%# Eval("ProductId") %>' />
                                
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
</asp:Content>

