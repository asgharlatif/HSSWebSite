<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuotationEmailConfirmation.aspx.cs" Inherits="EmailTemplates_QuotationEmailConfirmation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Reference Page="~/cart.aspx" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title></title>

<link href="../App_Themes/Admin/CheckoutProductStyleSheet.css" rel="stylesheet" type="text/css" />
<link href="../Styles/cart.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <h1>
            Dear User. <br />
             
        </h1>
        Thank you for submitting your interest about our product. We'll send you our best quoated prices as soon as possible.<br /><br />
        
        <asp:Panel ID="emailme" runat="server">
    <asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
   
    </HeaderTemplate>
    <ItemTemplate>
        <div class="Emailpane">
            <h3>
                <%# Eval("ProductTitle") %></h3>
                  <p>
            <table >
                    <tr>
                        
                        <td >
                            <img height="50" width="50" alt="" src="images/ProductThumbNail/<%# Eval("ThumbNail") %>" /></td>
                            <td>

                           </td>
                        <td   > 
                        <b>
                        [<%# Eval("productid") %>]:-Product Detail</b><br><br>
                        <%# Eval("description") %>
                           </td>

                           <td> Quantity<br><br>
                               1
                           </td>

                    </tr>
                </table>

            
          </p>
           
         
            

        </div>
    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
    </asp:Repeater>
    </asp:Panel>
    <b>
    <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label>
    </b>
    </form>
</body>
</html>
