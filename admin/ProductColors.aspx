<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="ProductColors.aspx.cs" Inherits="admin_ProductColors" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        Product Color Images 
        <asp:Label ID="lblProductTitle" runat="server"></asp:Label></h1>
    <p>
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add Product Colors" />&nbsp;<br />
        <asp:Label
            ID="lblMsg" runat="server" ForeColor="red"></asp:Label></p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging"
        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting"
        OnSorting="GridView1_Sorting">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Image ID="imgProductColor" runat="server" ImageUrl='<%# "~/thumbnail.aspx?image=Images/ProductColorImages/" + Eval("Image") + "&size=100" %>'></asp:Image>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product">
                <ItemTemplate>
                    <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("ProductId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Color">
                <ItemTemplate>
                    <asp:Label ID="lblColorId" runat="server" Text='<%# Eval("ColorId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Manage">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("ProductColorId") %>'
                        CommandName="EditItem">Edit</asp:LinkButton>
                    |
                    <asp:LinkButton ID="delbutton" runat="server" CommandArgument='<%# Eval("ProductColorId") %>'
                        CommandName="Delete">Delete</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

