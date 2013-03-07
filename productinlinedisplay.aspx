<%@ Page Title="Product Display Center" Language="C#" MasterPageFile="~/MasterProductDisplay.master" AutoEventWireup="true" CodeFile="productinlinedisplay.aspx.cs" Inherits="productinlinedisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RightBar" Runat="Server">
<script type="text/javascript">
    $(document).ready(function () {

        $(".TblPrdGalMainDivHeader .addToBasket").click(function () {
            var ProductId;
            ProductId = $(this).parents(".TblPrdGalMainDivHeader").find("span").attr("id");
            var dataString = 'ProductId=' + ProductId + '&RequestingForm=ShoppingCart';
            $.ajax
               (
               {
                   type: "POST",
                   url: "cartprocess.aspx",
                   data: dataString,
                   success: function (msg) {
                       //var list = $(msg).find('input:last').val();
                      // $('span[id$=lblTotalItems]').text("Your Shopping Cart contains (" + list + ") items");         
                       // alert("Item has been selected for your Quotation list.");
                       var list = $(msg).find('input:last').val();
                       if (list != "0") {
                           $('span[id$=lblTotalItems]').text("Your Shopping Cart contains (" + list + ") items");
                           //$(this).parents('table .TblPrdGalMainDivHeader').animate({ opacity: 'hide' }, "slow");
                           $('#Tbl_' + ProductId).animate({ opacity: 0 }, "slow");
                       }
                       else {
                           //$('Div .CartHeaderDiv').animate({ opacity: 'hide' }, "slow");
                           //alert("asdsa");
                           var Selector = "Tbl" + ProductId;
                           //$('#Tbl_' + ProductId).css('visibility', 'hidden')
                           $('#Tbl_' + ProductId).animate({ opacity: 0 }, "slow");
                       }
                   }
               }
               );
            return false;
        });
    });
   </script>
 <div class="PrdInlineMainDiv">
    <asp:DataList ID="DataList1" runat="server" 
            onselectedindexchanged="DataList1_SelectedIndexChanged" RepeatColumns="1" 
            RepeatDirection="Horizontal" BorderColor="#000066" BorderStyle="Solid" 
        BorderWidth="0px" Width="600px" OnItemDataBound="DataList1_ItemDataBound">
        <ItemTemplate>
            <div class="PrdInLinePrdDiv">
            <table class="TblPrdInlineMainDiv" >
                <tr>
                    <td valign="top">
                        <table cellpadding="0" cellspacing="0">
                            
                            <tr>
                                <td align="left" height="50" valign="top" width="10">
                                    <a href="#">
                                   <img alt=""  src="frontimages/logo/icon-fb.gif" />
                                   </a>
                                   
                                    
                                </td>
                                <td id="PrdInlineMainDivImgTd" >
                                    <a href="productinquiry.aspx?ProductId=<%# Eval("ProductId") %>" >
                                     <img alt="" src='<%# "thumbnail.aspx?Image=Images/ProductThumbNail/" + Eval("thumbnail")  %>'  />
                                    </a>

                                     <asp:Panel ID="GalPanel1" runat="server">
                                    <table class="TblPrdGalMainDivHeader" id="Tbl_<%# Eval("ProductId") %>">
                                        <tr>
                                            <td align="left">  
                                            <asp:Image ID="Image1"   runat="server" src="frontimages/logo/addtobaket.gif" alt="addToBasket" CssClass="addToBasket" />
                                            <span id="<%# Eval("ProductId") %>">a</span>  
                                             
                                            </td>
                                            
                                        </tr>
                                    </table>
                                    </asp:Panel>
                                    
                                </td>
                                <td align="left"  width="520" id="PrdInlineMainDivImg2Td">
                                            

                                            <h1>
                                            
                                            <%# Eval("producttitle")%>
                                            </a>
                                            </h1>

                                            
                                            <h3><%# Eval("Description")%></h3>
                                            <h4>Technical Specification<br/><%# Eval("TechnicalSpecs")%></h4>
                                    
                                </td>
                            </tr>
                            
                        </table>
                    </td>
                </tr>
            </table>
            </div>
        </ItemTemplate>
    </asp:DataList>

   

</div>

</asp:Content>

