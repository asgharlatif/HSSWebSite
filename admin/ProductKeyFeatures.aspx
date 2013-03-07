<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="ProductKeyFeatures.aspx.cs" Inherits="admin_ProductKeyFeatures" Title="" Theme="Admin"%>
<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
    <h1>
        Manage Key Features  
        <asp:Label ID="lblProductTitle" runat="server"></asp:Label></h1>
    <p>
        <asp:Button ID="btnAddFeatures" runat="server" OnClick="btnAddFeatures_Click" Text="Add Features" /><asp:Label
            ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand"
        OnItemDataBound="DataList1_ItemDataBound" RepeatColumns="3" Width="100%">
        <ItemTemplate>
            <br />
            <table width="100%">
                <tbody>
                    <tr>
                        <td style="width: 150px;">
                        </td>
                        <td style="width: 150px;text-align: center">
                            <asp:HyperLink ID="hplImage" runat="server" ImageUrl='<%# "~/thumbnail.aspx?image=Images/ProductKeyFeatures/" + Eval("Image") + "&size=100" %>'>HyperLink</asp:HyperLink><br />
                            <%# Eval("Sort") %>
                        </td>
                        <td style="width: 150px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px">
                        </td>
                        <td style="text-align: center">
                            <asp:TextBox ID="txtSortOrder" runat="server" Text='<%# Eval("Sort") %>' Width="50px"></asp:TextBox></td>
                        <td style="width: 150px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: center;">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSortOrder"
                                Display="Dynamic" ErrorMessage="Sort Order is invalid" ValidationExpression="^\d+(?:\.\d{0,2})?$"></asp:RegularExpressionValidator>
                            <asp:Label ID="lblImageId" runat="server" Text='<%# Eval("KeyFeatureId") %>' Visible="False"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSortOrder"
                                ErrorMessage="Sort Order Required"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: center">
                            <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("KeyFeatureId") %>'
                                CommandName="Edit">Edit</asp:LinkButton>
                            &nbsp; |&nbsp;
                            <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%# Eval("KeyFeatureId") %>'
                                CommandName="Del">Delete</asp:LinkButton>
                            </td>
                    </tr>
                </tbody>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <p>
        <asp:Button ID="btnUpdateSortOrder" runat="server" OnClick="btnUpdateSortOrder_Click"
            Text="Update Sort Order" /></p>
    </asp:Content>

