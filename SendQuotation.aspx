<%@ Page Title="Send Quotation" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SendQuotation.aspx.cs" Inherits="SendQuotation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

<div class="QuotationMainDiv">
    <h1>Send Inquiries direct to Manufacturer(s)</h1>
    
    <div class="QuotationDetailDiv">
        
         <div class="QuotationDetailDivHeader">
            
        </div>
         <div class="QuotationDetailCentral">
             
            <table class="SendQuotation">
            <tr>
                <td class="SendQuotationtd">From</td>
                <td class="SendQuotationtdtd"><asp:TextBox ID="TextBox1" runat="server" Width="250px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="SendQuotationtd">To</td>
                <td class="SendQuotationtdtd">
                    <asp:TreeView ID="TreeView1" runat="server" ExpandDepth="0" Font-Size="14px">
                        <Nodes>
                            <asp:TreeNode Text="5 companies for 4 items" Value="5 companies for 4 items">
                                <asp:TreeNode Text="MB Communication" Value="MB Communication"></asp:TreeNode>
                                <asp:TreeNode Text="Black Copper" Value="Black Copper"></asp:TreeNode>
                                <asp:TreeNode Text="Balen Pvt Ltd" Value="Balen Pvt Ltd"></asp:TreeNode>
                                <asp:TreeNode Text="Najeeb Computers" Value="Najeeb Computers"></asp:TreeNode>
                                <asp:TreeNode Text="Muneeb Computers" Value="Muneeb Computers"></asp:TreeNode>
                            </asp:TreeNode>
                        </Nodes>
                    </asp:TreeView>
                </td>
            </tr>
            
            <tr>                
            <td class="SendQuotationtd">Subject</td>
            <td class="SendQuotationtdtd"><asp:TextBox ID="TextBox2" runat="server" MaxLength="500" Width="400px" ></asp:TextBox></td>
            </tr>

            <tr>
            <td valign="top" class="SendQuotationtd">Description</td>
            <td class="SendQuotationtdtd"><asp:TextBox ID="TextBox3" runat="server" MaxLength="500" Width="530px" 
                    Height="137px" ></asp:TextBox></td>
            </tr>

            <tr>                
            <td colspan="2">
            
            <table class="SendQuotationOption">
            <tr>
                <td class="SendQuotationOptiontd"></td>
                <td class="SendQuotationOptiontdtd">Deadline for response</td>
                <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Width="105px">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                </asp:DropDownList>&nbsp;days </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
            <td class="SendQuotationOptiontd"></td>
            <td class="SendQuotationOptiontdtd">Purchase Quantity</td>
            <td colspan="2"><asp:TextBox ID="TextBox4" runat="server" MaxLength="500" Width="100px" ></asp:TextBox>&nbsp;10000 pieces e.g</td>
            
            <td></td>
            </tr>
            <tr>
            <td class="SendQuotationOptiontd"></td>
                
            <td>Other request</td>
            <td class="SendQuotationOptiontdtd"><asp:CheckBox ID="CheckBox1" runat="server" Text="Product Catalog" /></td>
            <td class="SendQuotationOptiontdtd"><asp:CheckBox ID="CheckBox2" runat="server" Text="Payment Tersm" /></td>
            <td class="SendQuotationOptiontdtd"><asp:CheckBox ID="CheckBox3" runat="server" Text="Delivery Time" /></td>
            </tr>
            <tr>
            <td class="SendQuotationOptiontd"></td>                
            <td></td>
            <td class="SendQuotationOptiontdtd"><asp:CheckBox ID="CheckBox4" runat="server" Text="Price List" /></td>
            <td class="SendQuotationOptiontdtd"><asp:CheckBox ID="CheckBox5" runat="server" Text="Packing Details" /></td>
            <td class="SendQuotationOptiontdtd"><asp:CheckBox ID="CheckBox6" runat="server" Text="Request of Samples" /></td>
            </tr>
            </table>
            
            
            </td>
            </tr>

             <tr>                
            <td colspan="2" >
                <asp:Button ID="Button1" runat="server" Text="Send" Width="100px" Height="40px" />
            
            </td></tr>

            </table>
         </div>

         <div class="QuotationDetailDivFooter">
         
        </div>
    </div>
    
</div>



</asp:Content>

