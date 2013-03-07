<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerDetail.aspx.cs" Inherits="admin_CustomerDetail" Title="" Theme="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        Customers</h1>
    <p>
        <asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label>
    </p>
    <p>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="CustomerId"
            Height="50px" Width="125px">
            <Fields>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:CheckBoxField DataField="Subscribed" HeaderText="Subscribed" SortExpression="Subscribed" />
                <asp:BoundField DataField="DateAdded" HeaderText="Date Registered" SortExpression="DateAdded" />
            </Fields>
        </asp:DetailsView>
        <input id="Button2" onclick="history.back()" type="button" value="Cancel" />
    </p>
</asp:Content>

