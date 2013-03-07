<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="MainPageSectionDetail.aspx.cs" Inherits="admin_MainPageSectionDetail"  Theme="Admin"  %>
<%@ Register Assembly="DatePickerControl" Namespace="DatePickerControl" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="CPAdminHead" Runat="Server">
    
    <link href="../App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css" />
     <style type="text/css">

        .style4
        {
            color: #FFFFFF;
        }
        .style5
        {
            width: 100%;
        }
    </style>

    
    <link href="../Styles/ModelPopUp.css" rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPAdminBody" Runat="Server">

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

 <h1>
        Add Main Page Section Detail according to change of Company, Product Category, Sub Category and Product Group
    </h1>

     <p>
    
    Filter Level : 
         <asp:Label ID="lblGroupLevel" runat="server"></asp:Label>
    </p>
    <table class="style5">
        <tr>
            <td>
                Company</td>
            <td>
                Category</td>
            <td>
                Sub Sub Category</td>
            <td>
                Product Group</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlCompany" runat="server" Width="202px"  onselectedindexchanged="ddlCompany_SelectedIndexChanged" 
            AutoPostBack="True"></asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="ddlCategory" runat="server" Width="202px" 
                    AutoPostBack="True" CssClass="style4" 
                    onselectedindexchanged="ddlCategory_SelectedIndexChanged">
                </asp:DropDownList>
                </td>
            <td>
                <asp:DropDownList ID="ddlSubCategory" runat="server" Width="202px" 
                    onselectedindexchanged="ddlSubCategory_SelectedIndexChanged" 
                    AutoPostBack="True" CssClass="style4">
                </asp:DropDownList>
                </td>
            <td>
                <asp:DropDownList ID="ddlProductGroupCode" runat="server" Width="202px" 
                    onselectedindexchanged="ddlProductGroupCode_SelectedIndexChanged" 
                    AutoPostBack="True" CssClass="style4">
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlCompany"
                    Display="None" ErrorMessage="Select a company." ValidationGroup="Product" 
                    CssClass="style4"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlCategory"
                    Display="None" ErrorMessage="Select a category." ValidationGroup="Product" 
                    CssClass="style4"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlSubCategory"
                    Display="None" ErrorMessage="Select a sub category." 
                    ValidationGroup="Product" CssClass="style4"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlProductGroupCode"
                    Display="None" ErrorMessage="Select a product group code." 
                    ValidationGroup="Product" CssClass="style4"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <p>
        &nbsp;</p>

    <p>
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></p>
    
    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" >
 
    <ItemTemplate>
    
        <table class="style5"  ><tr><td>
        <asp:Label ID="lblPagePartName" runat="server" Text='<%# Eval("PagePartName")%>' CssClass="LargeFont"></asp:Label>              
                </td></tr></table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="SectionName" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand"  >
        
        <Columns>

            <asp:TemplateField HeaderText="Section Code" ItemStyle-Width="100px">
                <ItemTemplate>   
                <asp:Label ID="lblSectionCode" runat="server" Text='<%# Eval("SectionCode")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="SectionName" HeaderText="Section Name" 
                SortExpression="SectionName" ItemStyle-Width="150px" />

                <asp:TemplateField HeaderText="Product Count" ItemStyle-Width="100px">
                <ItemTemplate>                   
                    
                    <asp:Label ID="lblProductCount" runat="server" Text="0"></asp:Label>
                    |
                    <asp:LinkButton ID="lbtnAdd" runat="server" CommandArgument='<%# Eval("SectionCode") %>'
                        CommandName="Add">Add</asp:LinkButton>

                </ItemTemplate>
                </asp:TemplateField>




                <asp:TemplateField HeaderText="Set Products">
                <ItemTemplate>                   

                    <asp:GridView ID="GrdProductDetail" runat="server" AutoGenerateColumns="false" OnRowCommand="GrdProductDetail_RowCommand" OnRowDataBound="GrdProductDetail_RowDataBound" >

                                <Columns>
                                <asp:BoundField DataField="ProductId" HeaderText="Product Id"    SortExpression="ProductId"  />
                                 <asp:BoundField DataField="SectionCode" HeaderText="SectionCode"    SortExpression="SectionCode" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="ProductTitle" HeaderText="Product Name"    SortExpression="ProductTitle"  ItemStyle-Width="150px" />
                                <asp:BoundField DataField="ProductGroupDescription" HeaderText="Product Group"    SortExpression="ProductGroupDescription"  />
                                <asp:BoundField DataField="SubCategoryName" HeaderText="Sub Category"    SortExpression="SubCategoryName"  />
                                <asp:BoundField DataField="CategoryName" HeaderText="Category"    SortExpression="CategoryName" ItemStyle-Width="150px" />
                               
                                

                                    <asp:TemplateField HeaderText="Manage">
                                    <ItemTemplate>
                    
                                    <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%# Eval("ProductId") + ";" + Eval("SectionCode")  %>'
                                    CommandName="Delete">Delete</asp:LinkButton>
                    
                                    </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="ExpiryDate" HeaderText="ExpiryDate"    SortExpression="ExpiryDate" ItemStyle-Width="150px" />

                                    <asp:TemplateField ShowHeader="false" HeaderText="Set Expiry">
                                        <ItemTemplate>
                                                 <asp:ImageButton ID="imgbtndetails" runat="server" ImageUrl="images/editor.gif"  OnClick="imgbtn_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>

                    </asp:GridView>
                    

                </ItemTemplate>
                </asp:TemplateField>



         </Columns>

        </asp:GridView>
                       
    </ItemTemplate>
    

    </asp:Repeater>


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
                               <asp:Label runat="server" ID="lblProductId" Visible="false"  />
                                <asp:Label runat="server" ID="lblSectionId" Visible="false" />
                            </td>
                            
                           
                            </tr>


                            <tr>
                            <td style="padding-top:20px; padding-left:20px">Expiry Date:-
                                <asp:TextBox ID="txtStartDate" runat="server" ValidationGroup="ExpiryGroup"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtStartDate" runat="server" Format="MMMM d, yyyy"   />
                                
                               

                            </td>
                            </tr>
                            <tr>
                            <td style="padding-left:20px; padding-top:20px" >
                             <asp:RequiredFieldValidator runat="server" ErrorMessage="Date is required." ControlToValidate="txtStartDate" ValidationGroup="ExpiryGroup">
                                </asp:RequiredFieldValidator>
                            </td>
                            </tr>
                             <tr>
                                
                                <td style="padding-top:180px">
                                    <asp:Button ID="CmdSetExpiry" runat="server" Text="Set Expiry." OnClick="btnUpdateExpiry_Click" ValidationGroup="ExpiryGroup" />
                                    <asp:Button ID="CmdRemoveExpiry" runat="server" Text="Remove Expiry." onclick="btnRemoveExpiry_Click" ValidationGroup="ExpiryGroup" />
                                    

                                </td>
                            </tr>
           </table>
                   

        </asp:Panel>

    

</asp:Content>

