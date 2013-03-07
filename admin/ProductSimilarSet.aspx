<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="ProductSimilarSet.aspx.cs" Inherits="admin_ProductSimilarSet" Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
 <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
<h1>Manage Product Similar Set</h1>
 <p>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
     
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="SetCode"
        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting"
        OnRowEditing="GridView1_RowEditing">
        <Columns>
           
             <asp:TemplateField HeaderText="Similar Set of Company">
            <ItemTemplate>
                   
                    <asp:Label ID="lblCompanyId" runat="server" Text='<%# Eval("CompanyId") %>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>


            <asp:BoundField DataField="SetDescription" HeaderText="Set Name" 
                SortExpression="SetDescription" />
            
            

            <asp:TemplateField HeaderText="Manage">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnEdit" runat="server" CommandArgument='<%# Eval("SetCode") %>'
                        CommandName="Edit">Edit</asp:LinkButton>
                    |
                    <asp:LinkButton ID="lbtnDelete" runat="server" 
                    CommandArgument='<%# Eval("SetCode") %>'  CommandName="Delete">Delete</asp:LinkButton>
                    
                    &nbsp;|
                    <asp:LinkButton ID="lbtnManageProducts" runat="server" 
                        CommandArgument='<%# Eval("SetCode") %>' CommandName="ManageProducts">Manage Similar Products</asp:LinkButton>
                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>

