<%@ Page  Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="Brands.aspx.cs" Inherits="admin_Brands" Title="" Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>Brands</h1>
    <p>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Br_Code"
        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting"
        OnRowEditing="GridView1_RowEditing">
        <Columns>
        <asp:BoundField DataField="Br_Code" HeaderText="Br_Code" 
                SortExpression="Br_Code" />
            <asp:BoundField DataField="Br_Name" HeaderText="Br_Name" 
                SortExpression="Br_Name" />
            <asp:BoundField DataField="inactive" HeaderText="inactive" SortExpression="inactive" />

            <asp:TemplateField HeaderText="Manage">
                <ItemTemplate>

                    <asp:LinkButton ID="lbtnEdit" runat="server" CommandArgument='<%# Eval("Br_Code") %>'
                        CommandName="Edit">Edit</asp:LinkButton>
                    |
                    <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%# Eval("Br_Code") %>'
                        CommandName="Delete">Delete</asp:LinkButton>
                   
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

