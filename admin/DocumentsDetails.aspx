<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="DocumentsDetails.aspx.cs" Inherits="admin_DocumentsDetails" Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css" />    
    <link href="../Styles/brochure.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">
  <h1>
         <asp:Label ID="lblDocumentype" runat="server"></asp:Label>
         Detail of Product Id <asp:Label ID="lblProductId" runat="server" Text=""></asp:Label></h1>
    <p>
        <asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
     <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        DataKeyNames="DocumentId" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand"
        Width="600px" CellPadding="4" ForeColor="#333333" GridLines="None">
         <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="DocumentName" HeaderText="Page Type"  />
            
            
            <asp:BoundField DataField="osdescription" HeaderText="Operating System"  />


            <asp:BoundField DataField="LanguageName" HeaderText="Language Name"  />

            <asp:TemplateField HeaderText="Thumb Nail">
                <ItemTemplate>

                    
                    <asp:Image ID="Image1" runat="server" CssClass="ThumbBrochures" />

                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Manage">
                <ItemTemplate>
                <asp:Label ID="lblLanguageId" Visible="false" runat="server" Text='<%# Eval("LanguageId") %>'></asp:Label>
                <asp:Label ID="lblDocumentId" Visible="false" runat="server" Text='<%# Eval("DocumentId") %>'></asp:Label>
                <asp:Label ID="lblOSId" Visible="false" runat="server" Text='<%# Eval("OSId") %>'></asp:Label>
                

                <asp:LinkButton ID="btnAdd" runat="server" CommandArgument='<%# Eval("DocumentId") + "?" + Eval("LanguageId") + "?" + Eval("OSId") %>'
                        CommandName="Add">Add</asp:LinkButton>
                      
                   
                    <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%# Eval("DocumentId") + "?" + Eval("LanguageId") + "?" + Eval("OSId") %>'
                        CommandName="Delete">Delete</asp:LinkButton>
                   
                </ItemTemplate>
            </asp:TemplateField>

          
          <asp:TemplateField HeaderText="Download">
                <ItemTemplate>
                        <asp:LinkButton ID="btnDownload" runat="server"  CommandArgument='<%# Eval("DocumentId") + "?" + Eval("LanguageId") + "?" + Eval("OSId") %>'
                        CommandName="Download" ></asp:LinkButton>
                </ItemTemplate>
              
          </asp:TemplateField>




        </Columns>
         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>


        <input id="Button2" onclick="history.back()" type="button" value="Cancel" />
    </p>
</asp:Content>

