<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="FeedBack.aspx.cs" Inherits="admin_FeedBack" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        Feedback</h1>
    <p>
        <asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label>
    </p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging"
        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting"
        OnSorting="GridView1_Sorting">
        <Columns>
            <asp:TemplateField HeaderText="Submitter Name">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date Submitted">
                <ItemTemplate>
                    <asp:Label ID="lblDateSubmitted" runat="server" Text='<%# Eval("DateAdded") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Manage">
                <ItemTemplate>
                    <asp:LinkButton ID="btnView" runat="server" CommandArgument='<%# Eval("FeedBackId") %>'
                        CommandName="View">View</asp:LinkButton>
                    |
                    <asp:LinkButton ID="delbutton" runat="server" CommandArgument='<%# Eval("FeedBackId") %>'
                        CommandName="Delete">Delete</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

