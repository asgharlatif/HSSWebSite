<%@ Page  Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="Warranty.aspx.cs" Inherits="admin_Warranty" Title="" Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>Warranties</h1>
    <p>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="WarCode"
        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting"
        OnRowEditing="GridView1_RowEditing">
        <Columns>
        <asp:BoundField DataField="WarCode" HeaderText="WarCode" 
                SortExpression="WarCode" />
            <asp:BoundField DataField="WatName" HeaderText="WatName" 
                SortExpression="WatName" />
            <asp:BoundField DataField="inactive" HeaderText="inactive" SortExpression="inactive" />

            <asp:TemplateField HeaderText="Manage">
                <ItemTemplate>

                    <asp:LinkButton ID="lbtnEdit" runat="server" CommandArgument='<%# Eval("WarCode") %>'
                        CommandName="Edit">Edit</asp:LinkButton>
                    |
                    <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%# Eval("WarCode") %>'
                        CommandName="Delete">Delete</asp:LinkButton>
                   
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

