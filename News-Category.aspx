<%@ Page Title="News-Category" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="News-Category.aspx.cs" Inherits="News_Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

 <div id="upper-body">
<img src="centralscreenimages/banner_news_events.jpg" alt="Brand of the Year" />
</div>

 <div id="inner-body">
        <div id="inner-body-left-full">
            <h1>
               <%-- <%= SiteMap.CurrentNode.Title %>--%>
               <asp:Label ID="lblCategoryName" runat="server" Visible="false"></asp:Label>News and Events
            </h1>
            
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                <div style="width:920px; float:left;">
                
                    <a href='<%# "News-Detail.aspx?NewsId=" + Eval("NewsId") %>'>
                        <h2 style="margin-bottom:5px;"><%# Eval("Title") %></h2>
                    </a><a href='<%# "News-Detail.aspx?NewsId=" + Eval("NewsId") %>'><img alt="<%# Eval("Title") %>" src='<%# "thumbnail.aspx?Image=Images/NewsImages/" + Eval("MainImage") + "&size=200" %>'
                            style="border: solid 2px #ccc; float:left; margin:2px 10px 10px 0;"/></a><%# Eval("ShortDescription") %>
                    <div style="padding: 15px; text-align: right; font-size: 11px; color: #F63;">
                        <a href='<%# "News-Detail.aspx?NewsId=" + Eval("NewsId") %>'>Read More</a> &raquo;</div>
                        
                        
                        </div>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div style="padding: 10px; margin: 20px 0 0 0; text-align: center; font-size:11px;">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Previous" CssClass="FormButtons" />
            &nbsp;<asp:Label ID="lblCurrentPage" runat="server"></asp:Label>&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Next" CssClass="FormButtons" />
        </div>
     
    </div>


</asp:Content>

