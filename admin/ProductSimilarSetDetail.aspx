<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="ProductSimilarSetDetail.aspx.cs" Inherits="admin_ProductSimilarSetDetail" Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
  <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        Manage Products of <asp:Label ID="lblCompNameName" runat="server" Text="Label"></asp:Label> which are similar to <asp:Label ID="lblSetName" runat="server" Text="Label"></asp:Label></h1>

     <p>
         &nbsp;</p>

    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <br />




                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductId"
                    DataSourceID="ObjectDataSource1" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
                    OnRowDeleted="GridView1_RowDeleted" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
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
                             

                                <asp:LinkButton ID="lbtnManageSetCode" runat="server" CommandArgument='<%# Eval("ProductId") %>' 
                                CommandName="IsSetCodePresent" Text='<%# Eval("SetCode") %>' ForeColor="Red"></asp:LinkButton>
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

