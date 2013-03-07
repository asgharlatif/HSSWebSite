<%@ Page Title="Shopping Cart" Language="C#" MasterPageFile="~/MasterLeftRightCenterPages.master" AutoEventWireup="true" CodeFile="cart.aspx.cs" Inherits="cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMasterPageWithRightLatestProductsCenterBar" Runat="Server">

<link href="App_Themes/Admin/CheckoutProductStyleSheet.css" rel="stylesheet" type="text/css" />
<link href="Styles/cart.css" rel="stylesheet" type="text/css" />

    <script src="FLFiles/highslide-with-gallery.js" type="text/javascript"></script>
    <link href="FLFiles/highslide.css" rel="stylesheet" type="text/css" />
    <script src="FLFiles/jquery.js" type="text/javascript"></script>
    <script src="FLFiles/main.js" type="text/javascript"></script>
    <link href="FLFiles/main.css" rel="stylesheet" type="text/css" />
    <link href="FLFiles/page-print-email-real-estate-brochures.css" rel="stylesheet"        type="text/css" />

<script language="javascript" type='text/javascript'>
    //-------------------------------------- slide show style

    $(document).ready(function () {

        slideShow();

        $("#error-msg").html("");

        var defaultMsg = "<div class=\"alret-title\">The Business E-mail or Password you entered is incorrect:</div>" +
			"<ul><li>Please check your Caps Lock</li>" +
			   "<li>Forgot your password?<a href=\"/gmportal/portal/signin/signin/forgetPw.gm\" class=\"forgotpw\" >Click here</a></li>" +
			"</ul>";

        $("#error-msg").append(defaultMsg);

        $("#error-msg").show();

    });



    //-------------------------------------- end slide slow style


    //$('#display').text(list);
    // is this correct?    
    // $('#contact_form').html("&lt;div id='message'&gt;&lt;/div&gt;");
    // $('#message').html("&lt;h2&gt;Contact Form Submitted!&lt;/h2&gt;")
    // //  .append("&lt;p&gt;We will be in touch soon.&lt;/p&gt;")
    //   .hide()
    //   .fadeIn(1500, function () 
    //   {
    //       $('#message').append("&lt;img id='checkmark' src='images/check.png' /&gt;");                          
    //   });
    //$(this).parents(".pane").css('background-color', 'red');
    //window.location = $(this).parents(".pane").find("a").attr("href");
    //str = $(this).parents(".pane").find("a").attr("href");
    //str = $(this).parents(".pane").find("input").attr("id");
    //alert(str);
    //str = $(this).parents(".pane").find("input").val();
 </script>  

<script type="text/javascript">
    $(document).ready(function () {
        $(".pane .delete").click(function () {




            $(this).parents(".pane").animate({ opacity: 'hide' }, "slow");

            var ProductId;
            ProductId = $(this).parents(".pane").find("h3").attr("id");
            //----------------------------------- db insertion
            var dataString = 'ProductId=' + ProductId + '&RequestingForm=CartDel';
            $.ajax({
                type: "POST",
                url: "cartprocess.aspx",
                data: dataString,
                success: function (msg) {
                    var list = $(msg).find('input:last').val();

                    $('.lbl').text("Your Shopping Cart contains (" + list + ") items")

                    //$(this).parents(".pane").animate({ opacity: 'hide' }, "slow");
                    if (list == "0") {

                        //alert("empty shopping cart");
                        $('Div .CartHeaderDiv').animate({ opacity: 'hide' }, "slow");
                        $('Div #emptycartSpan').css('display', 'block');
                        $('Div #FLDiv').css('display', 'block');
                       
                    }




                }
            });
            return false;
            //----------------------------------- end db insertion
        })
        ;
    });
</script>

<div id="emptycartSpan" >Your shopping cart is empty 
    </div>
    <div id="FLDiv">
        
        <div style="text-align: right;" class="hidden-container">
            <a id="anchor1_id" class="highslide" onclick="return hs.expand(this)" href="centralscreenimages/largeview/badishop1.jpg">a</a>
            <a id="anchor2_id" class="highslide" onclick="return hs.expand(this)" href="centralscreenimages/largeview/badishop2.jpg">a</a>

            <a id="anchor3_id" class="highslide" onclick="return hs.expand(this)" href="centralscreenimages/largeview/badishop3.jpg">a</a>
            <a id="anchor4_id" class="highslide" onclick="return hs.expand(this)" href="centralscreenimages/largeview/bikenbike1.jpg">a</a>
            <a id="anchor5_id" class="highslide" onclick="return hs.expand(this)" href="centralscreenimages/largeview/bikenbike2.jpg">a</a>
            <a id="anchor6_id" class="highslide" onclick="return hs.expand(this)" href="centralscreenimages/largeview/bikenbike3.jpg">a</a>
            <a id="anchor7_id" class="highslide" onclick="return hs.expand(this)" href="centralscreenimages/largeview/bikenbike4.jpg">a</a>
            <a id="anchor8_id" class="highslide" onclick="return hs.expand(this)" href="centralscreenimages/largeview/bikenbike5.jpg">a</a>
            <a id="anchor9_id" class="highslide" onclick="return hs.expand(this)" href="centralscreenimages/largeview/blackcopper1.jpg">a</a>
            <a id="anchor10_id" class="highslide" onclick="return hs.expand(this)" href="centralscreenimages/largeview/blackcopper2.jpg">a</a>
            <a id="anchor11_id" class="highslide" onclick="return hs.expand(this)" href="centralscreenimages/largeview/mb1.jpg">a</a>
            <a id="anchor12_id" class="highslide" onclick="return hs.expand(this)" href="centralscreenimages/largeview/mb2.jpg">a</a>

        </div>
        <object style="visibility: visible;" id="carousel1" data="Carousel.swf"
            width="570" type="application/x-shockwave-flash" height="300">
            <param name="movie" value="Carousel.swf">
            <param name="wmode" value="transparent">
            <param name="flashvars" value="xmlfile=FLXMLFile.xml">
        </object>
    </div>

    <div class="CartHeaderDiv">
    <div id="LeftSpan"><asp:Label CssClass="lbl"  ID="lblTotalItems" runat="server" Text="Your Shopping Cart contains (0) items"></asp:Label></div>
    <div id="RightSpan">
        <asp:Button ID="btnAdd" runat="server" Text="Checkout Now" Width="150px" CssClass="FormButtons"
            OnClick="btnAdd_Click" />
    </div>
    </div>



    <asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
   
    </HeaderTemplate>
    <ItemTemplate>
        
        <div class="pane">
            <h3 id="<%# Eval("productid") %>">
                <%# Eval("ProductTitle") %></h3>
                  <p>
            <table class="TblCartData">
                    <tr>
                        
                        <td id="ImgTd">
                            <a href="productinquiry.aspx?productid=<%# Eval("productid") %>">
                            <img  height="50" width="50" alt="" src="images/ProductThumbNail/<%# Eval("ThumbNail") %>" />
                            </a>     
                            </td>
                                   
            
            
                            <td>

                           </td>
                        <td  id="DescTd" > 
                        <b>

                      
                        <asp:Label ID="lblItemCode" runat="server" >[<%# Eval("productid") %>]</asp:Label>:-Product Detail</b><br><br>
                        <%# Eval("description") %>
                           </td>

                           <td> Quantity<br><br>
                               <asp:TextBox ID="TextBox1" Text="1"   Width="50px" runat="server"></asp:TextBox>
                           </td>

                    </tr>
                </table>

            
          </p>
           
            <asp:Image ID="Image1"   runat="server" src="images/btn-delete.gif" alt="delete" CssClass="delete" />
            

        </div>
    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
    </asp:Repeater>

     <div class="CartHeaderDiv">
    <div id="LeftSpan1"><asp:Label  CssClass="lbl" ID="lblTotalItems1" runat="server" Text="Your Shopping Cart contains (0) items"></asp:Label></div>
    <div id="RightSpan1">
        <asp:Button ID="Button1" runat="server" Text="Checkout Now" Width="150px" CssClass="FormButtons"
            OnClick="btnAdd_Click" />
    </div>
    </div>

</asp:Content>

