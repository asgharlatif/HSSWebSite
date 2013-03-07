<%@ Page Title="News-Detail" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="News-Detail.aspx.cs" Inherits="News_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

<div id="upper-body">
<img src="centralscreenimages/banner_news_events.jpg" alt="Brand of the Year" />
</div>

<div id="inner-body">


        <div id="inner-body-left-full">
            <h1>
                <asp:Label ID="lblNewsTitle" runat="server"></asp:Label></h1>
            <div style="text-align: center; margin: 0 0 10px 0;">
                <asp:Image ID="imgNews" runat="server" alt="" Style="border: solid 2px #ccc;" />
            </div>
            <asp:Label ID="lblNewsDescription" runat="server"></asp:Label>
            <div style="padding: 15px; text-align: left; color: #F63;">
                &laquo; <a href="javascript:history.back();">Back</a></div>
        </div>
    </div>
</asp:Content>

