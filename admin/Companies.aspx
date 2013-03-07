<%@ Page  Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="Companies.aspx.cs" Inherits="admin_Companies" Title="" Theme="Admin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">

     <style type="text/css">

        .style5
        {
            width: 100%;
        }
    </style>

    
    <link href="../Styles/ModelPopUp.css" rel="stylesheet" type="text/css" />

    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

    <h1>Companies</h1>
    <p>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CompanyId"
        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting"
        OnRowEditing="GridView1_RowEditing">
        <Columns>

        <asp:BoundField DataField="CompanyId" HeaderText="CompanyId" 
                SortExpression="CompanyId" />

            <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" 
                SortExpression="CompanyName" />
            <asp:BoundField DataField="DateAdded" HeaderText="DateAdded" SortExpression="DateAdded" />
            <asp:TemplateField HeaderText="Manage">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnEdit" runat="server" CommandArgument='<%# Eval("CompanyId") %>'
                        CommandName="Edit">Edit</asp:LinkButton>
                    |
                    <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%# Eval("CompanyId") %>'
                        CommandName="Delete">Delete</asp:LinkButton>
                    &nbsp;|&nbsp;
                    <asp:LinkButton ID="lbtnManageProfile" runat="server" 
                        CommandArgument='<%# Eval("CompanyId") %>' CommandName="Profile">Manage Profile</asp:LinkButton>
                    &nbsp;|
                    <asp:LinkButton ID="lbtnManageProducts" runat="server" 
                        CommandArgument='<%# Eval("CompanyId") %>' CommandName="Products">Manage Products</asp:LinkButton>
                    &nbsp; |
                    <asp:LinkButton ID="lbtnSetAsGroup" runat="server" 
                        CommandArgument='<%# Eval("CompanyId") %>' CommandName="Group" Text='<%# Eval("MarkGroup") %>' ></asp:LinkButton>
                    &nbsp;|&nbsp;

                    <asp:LinkButton ID="lbtnSetGroupProfile" runat="server" 
                        CommandArgument='<%# Eval("CompanyId") %>' CommandName="GroupProfile">Group Profile</asp:LinkButton>
                        &nbsp;|&nbsp;

                       
                </ItemTemplate>
            </asp:TemplateField>

                                   <asp:TemplateField ShowHeader="false" HeaderText="Working Companies">
                                        <ItemTemplate>
                                                 <asp:ImageButton ID="imgbtndetails" runat="server" ImageUrl="images/editor.gif"  OnClick="imgbtn_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
        </Columns>
    </asp:GridView>

  

    <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup"
        PopupControlID="pnlpopup" CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>

     <asp:Panel ID="pnlpopup" runat="server" Height="340px" 
        Width="430px" ScrollBars="Auto" CssClass="pnlpopup">
        <table class="style5">
                        
                            <tr>
                            <td style="text-align:right">
                            <asp:Button ID="btnCancel" runat="server" Text="Close" Width="61px" />
                               <asp:Label runat="server" ID="lblCompanyId" Visible="false"  />
                             
                            </td>
                            
                           
                            </tr>

                            <tr>
                            <td style="padding-left:20px; padding-top:20px" >
                                Selected User Companies List
                                <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                                    Height="177px" ScrollBars="Vertical" >
                                    <asp:CheckBoxList ID="loclst" runat="server" >
                                    </asp:CheckBoxList>
                                </asp:Panel>
                            </td>
                            </tr>
                             <tr>
                                
                                <td >
                                    <asp:Button ID="CmdSetList" runat="server" Text="Update List." OnClick="btnUpdateList_Click" ValidationGroup="CompaniesList" />
                                   
                                </td>
                            </tr>
           </table>
                   

        </asp:Panel>

</asp:Content>

