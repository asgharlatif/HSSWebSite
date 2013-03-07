<%@ Page AutoEventWireup="true" CodeFile="Subscribers.aspx.cs" Inherits="admin_Subscribers"
    Language="C#" MasterPageFile="~/admin/MasterPage.master" Theme="Admin" Title="" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="CPAdminHead">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" runat="Server" ContentPlaceHolderID="CPAdminBody">
    <h1>
        Subscriber Listing
    </h1>
    <p>
    Filter By: <asp:DropDownList ID="ddlGroup" runat="server" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <asp:GridView ID="GridView1" runat="server" AllowSorting="true" AutoGenerateColumns="False"
        DataKeyNames="SubscriberId" OnRowCommand="GridView1_RowCommand"
        OnRowDataBound="GridView1_RowDataBound" OnRowDeleted="GridView1_RowDeleted" OnRowDeleting="GridView1_RowDeleting"
        OnRowEditing="GridView1_RowEditing" Width="600px">
        <Columns>
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:TemplateField HeaderText="Group">
                <ItemTemplate>
                    <asp:Label ID="lblGroupId" runat="server" Text='<%# Eval("GroupId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DateAdded" HeaderText="DateAdded" SortExpression="DateAdded" />
            <asp:TemplateField HeaderText="Manage">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("SubscriberId") %>'
                        CommandName="Edit">Edit</asp:LinkButton>
                    |
                    <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%# Eval("SubscriberId") %>'
                        CommandName="Delete">Delete</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
