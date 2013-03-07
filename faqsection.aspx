<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageWithRightLatestProducts.master" AutoEventWireup="true" CodeFile="faqsection.aspx.cs" Inherits="faqsection" %>
<%@ Register assembly="Artem.GoogleMap" namespace="Artem.Web.UI.Controls" tagprefix="artem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMasterPageWithRightLatestProductsRigthBar" Runat="Server">

 <div id="accordionbackground">

     <link href="Styles/accordion.css" rel="stylesheet" type="text/css" />

 </div>
 <div class="accordion">
	  <asp:Repeater ID="Repeater2" runat="server">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <h3><%# Eval("Question") %></h3>
                    <p><%# Eval("Answer") %> </p>
                    
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
</div>

</asp:Content>

