<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="Categories.aspx.cs" Inherits="admin_Categories" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>Categories</h1>
    <p>
    Filter By: 
                <asp:DropDownList ID="ddlCompany" runat="server" Width="202px" 
            onselectedindexchanged="ddlCompany_SelectedIndexChanged" 
            AutoPostBack="True"></asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CategoryId"
        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting"
        OnRowEditing="GridView1_RowEditing">
        <Columns>
            <asp:BoundField DataField="CategoryName" HeaderText="Category Name" 
                SortExpression="CategoryName" />
            
            

            <asp:TemplateField HeaderText="Product of">
            <ItemTemplate>
                   
                    <asp:Label ID="lblCompanyId" runat="server" Text='<%# Eval("CompanyId") %>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
                

            

            <asp:BoundField DataField="DateAdded" HeaderText="DateAdded" SortExpression="DateAdded" />
            <asp:TemplateField HeaderText="Manage">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnEdit" runat="server" CommandArgument='<%# Eval("CategoryId") %>'
                        CommandName="Edit">Edit</asp:LinkButton>
                    |
                    <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%# Eval("CategoryId") %>'
                        CommandName="Delete">Delete</asp:LinkButton>
                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

