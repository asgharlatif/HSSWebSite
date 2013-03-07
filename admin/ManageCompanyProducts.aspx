<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="ManageCompanyProducts.aspx.cs" Inherits="admin_ManageCompanyProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        Manage Company Similar Products (<asp:Label ID="lblCompany" 
            runat="server" Text="."></asp:Label>
        )</h1>

 <p>
    Select Product: 
                <asp:DropDownList ID="ddlCompany" runat="server" Width="202px"  
            AutoPostBack="True"></asp:DropDownList>
 </p>

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductId"
                    DataSourceID="ObjectDataSource1" 
                    Width="600px" AllowSorting="true">
                    <Columns>
                        <asp:BoundField DataField="ProductId" HeaderText="ProductId" InsertVisible="False"
                            ReadOnly="True" SortExpression="ProductId" Visible="False" />
                        <asp:TemplateField HeaderText="Category">
                            <ItemTemplate>
                                <asp:Label ID="lblCategoryId" runat="server" Text='<%# Eval("CategoryId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
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
                                <asp:LinkButton ID="btnSimilarProduct" runat="server" CommandArgument='<%# Eval("ProductId") %>'
                                    CommandName="SimilarProduct">Mark Similar Product</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
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

