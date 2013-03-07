<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="SubCategories.aspx.cs" Inherits="admin_SubCategories" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>Sub Categories Management</h1>
    <p>
    Filter By: 
                <asp:DropDownList ID="ddlCompany" runat="server" Width="202px" 
            onselectedindexchanged="ddlCompany_SelectedIndexChanged" 
            AutoPostBack="True"></asp:DropDownList>
    &nbsp;Category : 
                <asp:DropDownList ID="ddlCategory" runat="server" Width="202px" 
            onselectedindexchanged="ddlCategory_SelectedIndexChanged" 
            AutoPostBack="True"></asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="SubCategoryId"
        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting"
        OnRowEditing="GridView1_RowEditing">
        <Columns>
            <asp:BoundField DataField="SubCategoryName" HeaderText="Sub Category Name" 
                SortExpression="SubCategoryName" />
            
            

            <asp:TemplateField HeaderText="Category Name">
            <ItemTemplate>                   
                    <asp:Label ID="lblCategoryId" runat="server" Text='<%# Eval("CategoryId") %>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
                

            

            <asp:BoundField DataField="DateAdded" HeaderText="DateAdded" SortExpression="DateAdded" />
            <asp:TemplateField HeaderText="Manage">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnEdit" runat="server" CommandArgument='<%# Eval("SubCategoryId") %>'
                        CommandName="Edit">Edit</asp:LinkButton>
                    |
                    <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%# Eval("SubCategoryId") %>'
                        CommandName="Delete">Delete</asp:LinkButton>
                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

