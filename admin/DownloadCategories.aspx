<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="DownloadCategories.aspx.cs" Inherits="admin_DownloadCategories" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        Categories</h1>
    <p>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CategoryId"
        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting"
        OnRowEditing="GridView1_RowEditing">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Category Name" SortExpression="Title" />
            <asp:BoundField DataField="DateAdded" HeaderText="DateAdded" SortExpression="DateAdded" />
            <asp:TemplateField HeaderText="Manage">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnEdit" runat="server" CommandArgument='<%# Eval("CategoryId") %>'
                        CommandName="Edit">Edit</asp:LinkButton>
                    |
                    <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%# Eval("CategoryId") %>'
                        CommandName="Delete">Delete</asp:LinkButton>
                    |
                    <asp:LinkButton ID="lbtnViewSubCategories" runat="server" CommandArgument='<%# Eval("CategoryId") %>'
                        CommandName="View">View Subcategories</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

