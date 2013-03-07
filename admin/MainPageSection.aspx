<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="MainPageSection.aspx.cs" Inherits="admin_MainPageSection"  Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
<link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
<h1>Main Page Section Management</h1>
    <p>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        <table class="style1">
            <tr>
                <td>
                    Company Id:-</td>
            </tr>
            <tr>
                <td>
                <asp:DropDownList ID="ddlCompany" runat="server" Width="202px"  onselectedindexchanged="ddlCompany_SelectedIndexChanged" 
            AutoPostBack="True"></asp:DropDownList>
                </td>
            </tr>
        </table>
    </p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="SectionCode"
        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting"
        OnRowEditing="GridView1_RowEditing">
        <Columns>
            <asp:BoundField DataField="SectionName" HeaderText="SectionName" 
                SortExpression="SectionName" />

            <asp:BoundField DataField="PagePartName" HeaderText="Page Part Name" 
                SortExpression="PagePartName" />

            <asp:BoundField DataField="DateAdded" HeaderText="DateAdded" SortExpression="DateAdded" />
            <asp:TemplateField HeaderText="Manage">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnEdit" runat="server" CommandArgument='<%# Eval("SectionCode") %>'
                        CommandName="Edit">Edit</asp:LinkButton>
                    |
                    <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%# Eval("SectionCode") %>'
                        CommandName="Delete">Delete</asp:LinkButton>
                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

