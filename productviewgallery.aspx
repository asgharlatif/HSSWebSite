<%@ Page Title="Product Display Center" Language="C#" MasterPageFile="~/MasterProductDisplay.master" AutoEventWireup="true" CodeFile="productviewgallery.aspx.cs" Inherits="productviewgallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RightBar" Runat="Server">
   
   <script type="text/javascript">

           //alert(ProductId);

           //var list = $(msg).find('input:last').val();
           // $('ctl00_ctl00_MainContent_lblTotalItems').css('background-color', 'red');
           //alert($('document').find('Label1').attr('ID'));
           //alert($('Label1').text);
           //MasterPage.FindControl("SearchTextBox")
           //alert($("label:text.Label1"));
           //document.getElementById('Label1').InnerHTML = "sdassadas";
           //$('label[name=Label1]').html('asdasd');

           //document.getElementById('Label1').attributes('Text') = 2131231;

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
    <div class="PrdGalMainDiv" runat="server">
        <asp:DataList ID="DataList1" runat="server" OnSelectedIndexChanged="DataList1_SelectedIndexChanged"
            RepeatColumns="4" RepeatDirection="Horizontal" BorderColor="#000066" BorderStyle="Solid"
            BorderWidth="0px" Width="570px" OnItemDataBound="DataList1_ItemDataBound" OnItemCreated="DataList1_ItemCreated">
            <ItemTemplate>
                <table id="TblPrdGalMainDiv">
                    <tr>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="110px" height="30px">

                                        <asp:Panel ID="GalPanel1" runat="server">
                                            <table class="TblPrdGalMainDivHeader" id="Tbl_<%# Eval("ProductId") %>">
                                                <tr>
                                                    <td align="left">
                                                        <asp:Image ID="Image1" runat="server" src="frontimages/logo/addtobaket.gif" alt="addToBasket"
                                                            CssClass="addToBasket" />
                                                        <span id="<%# Eval("ProductId") %>">a</span>
                                                    </td>
                                                    <td align="right">
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="110px" height="130px" id="imagetd" valign="middle">
                                        <a href="productinquiry.aspx?ProductId=<%# Eval("ProductId") %>">
                                            <img alt="" src='<%# "thumbnail.aspx?Image=Images/ProductThumbNail/" + Eval("thumbnail")  %>' />
                                        </a>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="45">
                                        <a href="productinquiry.aspx?ProductId=<%# Eval("ProductId") %>">[<%# Eval("ProductId") %>]:-<%# Eval("producttitle") %></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5px" align="left">
                                        <a href="#">
                                            <img alt="" src="frontimages/logo/icon-fb.gif" />
                                        </a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>
    


    
  
    


    
</asp:Content>

