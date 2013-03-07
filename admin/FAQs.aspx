<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="FAQs.aspx.cs" Inherits="admin_FAQs" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
       FAQs
    </h1>
    <p>
        Filter By Sections:
        <asp:DropDownList ID="ddlSection" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <asp:GridView ID="GridView1" runat="server" AllowSorting="true" AutoGenerateColumns="False"
        DataKeyNames="QuestionId" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
        OnRowDeleted="GridView1_RowDeleted" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
        Width="600px">
        <Columns>
            <asp:BoundField DataField="Question" HeaderText="Question" SortExpression="Question" />
            <asp:TemplateField HeaderText="Category">
                <ItemTemplate>
                    <asp:Label ID="lblSectionId" runat="server" Text='<%# Eval("SectionId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DateAdded" HeaderText="DateAdded" SortExpression="DateAdded" />
            <asp:TemplateField HeaderText="Manage">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("QuestionId") %>'
                        CommandName="Edit">Edit</asp:LinkButton>
                    |
                    <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%# Eval("QuestionId") %>'
                        CommandName="Delete">Delete</asp:LinkButton>
                    |
                    <asp:LinkButton ID="lbtnEnable" runat="server" CommandArgument='<%# Eval("QuestionId") %>'
                        CommandName="ChangeStatus" Text='<%# Eval("IsEnabled") %>'>Delete</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

