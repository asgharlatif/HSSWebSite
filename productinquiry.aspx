<%@ Page Title="Product Inquiry" Language="C#" MasterPageFile="~/MasterProductInquiry.master" AutoEventWireup="true" CodeFile="productinquiry.aspx.cs" Inherits="productinquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainProductDisplaySection" Runat="Server">
    
<div class="ProductInquiryHeaderSectionLeftDiv">    
    
    
    <br />
    <br />
    <br />
    <br />
    
    
    <asp:Image ID="ProductImage" runat="server" alt=""   />

    
</div>



<div class="ProductInquiryHeaderSectionRightDiv">
    <table class="productinquiry">
            <tr>
                <td colspan="2">
                   <h1>
                   <asp:Label ID="lblProductName" runat="server" Text="15-32'' HD PC / HD TV Flat Touch Pc"></asp:Label>
                   </h1>
                   </td>
            </tr>
            <tr>
                <td colspan="2">
                    <h2>
                    <asp:Label ID="lblCompName" runat="server" Text="MB Communication "></asp:Label>
                    </h2>
                    </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPM" runat="server" Text="Part Number"></asp:Label></td>
                <td><h3>
                    <asp:Label ID="lblPartNumber" runat="server" Text="12345678"></asp:Label></h3></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Model"></asp:Label></td>
                <td><h3>
                    <asp:Label ID="lblModel" runat="server" Text="321HM"></asp:Label></h3></td>
            </tr>
            
            <tr>
                <td colspan="2">Product Description                    
                    <asp:TextBox Width="500px" ID="txtProductDescription" runat="server" 
                        Text="Flat touch pc:ambilight,provides enhanced viewing experience and reduces eye strain" 
                        Height="58px" TextMode="MultiLine"></asp:TextBox>
                    </td>
            </tr>
        </table>
</div>
<div class="divclearboth"></div>    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SimilarProductDisplaySection" Runat="Server">

    
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
             
               <div class="SimilarProduct">
                    <table class="similarproductinquiry">
                    <tr>
                        <td colspan="2" align="left" width="163px" 	height="160px" >
                            <a href="productinquiry.aspx?ProductId=<%# Eval("productid") %>">
                            <img alt="" src="images/ProductMainImages/<%# Eval("MainImage") %>" />
                            </a>
                        </td>
                    </tr>
                 
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ProductTitle") %>'></asp:Label>
                        </td>
                    </tr>
                   
                    <tr>
                        <td>
                            <b>
                            <asp:Label ID="Label4" runat="server" Text="Part Number"></asp:Label>
                            </b>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("ProductId") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                            <asp:Label ID="Label6" runat="server" Text="Model"></asp:Label>
                            </b>
                        </td>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("Model") %>'></asp:Label>
                        </td>
                    </tr>
                    
                </table>
               </div>
               
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
    
      

</asp:Content>

