<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="ProductGroups.aspx.cs" Inherits="admin_ProductGroups" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>Product Group Management</h1>
    <p>
    Filter By: 
                <asp:DropDownList ID="ddlCompany" runat="server" Width="202px" 
            onselectedindexchanged="ddlCompany_SelectedIndexChanged" 
            AutoPostBack="True"></asp:DropDownList>
    &nbsp;Category : 
                <asp:DropDownList ID="ddlCategory" runat="server" Width="202px" 
            onselectedindexchanged="ddlCategory_SelectedIndexChanged" 
            AutoPostBack="True"></asp:DropDownList>
            &nbsp;Sub Category : 
                <asp:DropDownList ID="ddlSubCategory" runat="server" Width="202px" 
            onselectedindexchanged="ddlSubCategory_SelectedIndexChanged" 
            AutoPostBack="True"></asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductGroupCode"
        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting"
        OnRowEditing="GridView1_RowEditing">
        <Columns>
            <asp:BoundField DataField="ProductGroupDescription" HeaderText="Product Group Name" 
                SortExpression="ProductGroupDescription" />
            
            

            <asp:TemplateField HeaderText="Sub Category Name">
            <ItemTemplate>                   
                    <asp:Label ID="lblSubCategoryId" runat="server" Text='<%# Eval("SubCategoryId") %>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
                

            

            <asp:BoundField DataField="DateAdded" HeaderText="DateAdded" SortExpression="DateAdded" />
            <asp:TemplateField HeaderText="Manage">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnEdit" runat="server" CommandArgument='<%# Eval("ProductGroupCode") %>'
                        CommandName="Edit">Edit</asp:LinkButton>
                    |
                    <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%# Eval("ProductGroupCode") %>'
                        CommandName="Delete">Delete</asp:LinkButton>
                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

