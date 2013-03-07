<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MMainPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="CentralContent" Runat="Server">
    

    <div class="CentralContentCss">
        

        <div class="main_view">
            <div class="window">	
                <div class="image_reel">
                    <a href="#"><img src="reel_1.gif" alt="" /></a>                    
                    <a href="#"><img src="businesshub.jpg" alt="" /></a>
                    <a href="#"><img src="Rbusinesshub.jpg" alt="" /></a>
                    <a href="#"><img src="small8by5PicView.jpg" alt="" /></a>
                    <a href="#"><img src="small6by4PicView.jpg" alt="" /></a>
                    <a href="#"><img src="RiceVegFruitsGreenish.jpg" alt="" /></a>  
                    <a href="#"><img src="small8by5PicViewParts.jpg" alt="" /></a>                   
                    <a href="#"><img src="PlainRightPartsView.jpg" alt="" /></a>
                    <a href="#"><img src="SmallBike4by6.jpg" alt="" /></a>
                    <a href="#"><img src="PlainRightMotorcycleView.jpg" alt="" /></a>  
                </div>
            </div>
           
          </div>

    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SomeTextContent" Runat="Server">

    <div class="SomeTextContentCss">
         <div class="paging">                
                <a href="#" rel="1">1</a>
                <a href="#" rel="2">2</a>
                <a href="#" rel="3">3</a>       
                <a href="#" rel="4">4</a>    
                <a href="#" rel="5">5</a>   
                <a href="#" rel="6">6</a>                  
                <a href="#" rel="7">7</a> 
                <a href="#" rel="8">8</a> 
                <a href="#" rel="9">9</a> 
                <a href="#" rel="10">10</a> 
               
                
            </div>
       
    </div>    
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CompaniesContent" Runat="Server">

    
    
    <div class="CompaniesContentCss">
    <table cellpadding="0" cellspacing="0" style=" width: 100%;">
        <tr>
            <td>
                <a href="companyIntroduction.aspx?qv=bs&companyid=13" ><img border="0" alt="" class="style14" src="frontimages/SmallPics/BadiShop_Logo.gif" /></a></td>
            <td>
                <a href="companyIntroduction.aspx?qv=bc&companyid=15"><img border="0" alt="" class="style15" src="frontimages/SmallPics/BlackCopper_Logo.gif" /></a></td>
            <td>
                <a href="companyIntroduction.aspx?qv=wa&companyid=12"><img  border="0" alt="" class="style15" src="frontimages/SmallPics/WebArt_Logo.gif" /></a></td>
            <td>
                <a href="companyIntroduction.aspx?qv=mb&companyid=11"><img border="0" alt="" class="style15" src="frontimages/SmallPics/MBCom_Logo.gif" /></a></td>
            <td>
               <a href="companyIntroduction.aspx?qv=bb&companyid=9"><img border="0" alt="" class="style15" src="frontimages/SmallPics/BikenBike_Logo.gif" /></a></td>
        </tr>
    </table>
    </div>    

</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="CompaniesIntroductionContent" Runat="Server">
   

    <div class="CompaniesIntroductionContentCss">
    
    <table cellpadding="0" cellspacing="0" class="style13" 
        style=" width: 100%;">
        <tr>
            <td>
                <a href="companyIntroduction.aspx?qv=bs&companyid=13" ><img border="0" alt="" class="style16" src="frontimages/SmallPics/BadiShop_Heading.gif" /></a></td>
            <td>
                <a href="companyIntroduction.aspx?qv=bc&companyid=15"><img border="0" alt="" class="style16" src="frontimages/SmallPics/BlackCopper_Heading.gif" /></a></td>
            <td>
                <a href="companyIntroduction.aspx?qv=bc&companyid=15"><img border="0" alt="" class="style16" src="frontimages/SmallPics/WebArt_Header.gif" /></a></td>
            <td>
                <a href="companyIntroduction.aspx?qv=mb&companyid=11"><img border="0" alt="" class="style16" src="frontimages/SmallPics/MBCom_Header.gif" /></a></td>
            <td>
                <a href="companyIntroduction.aspx?qv=bb&companyid=9"><img border="0" alt="" class="style16" src="frontimages/SmallPics/BikenBike_Header.gif" /></a></td>
        </tr>
    </table>
   
    </div>    
     
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="BusinessPartnerContent" Runat="Server">
    
    <div class="EmptyDivInHeaderPageCss">
    
        <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                
                </HeaderTemplate>
                <ItemTemplate>
                <div style="width:650px; float:left;">                
                    
                    </a><a href='<%# "News-Detail.aspx?NewsId=" + Eval("NewsId") %>'>
                    <img  alt="<%# Eval("Title") %>" src='<%# "thumbnail.aspx?Image=Images/NewsImages/" + Eval("MainImage") + "&size=50" %>'
                            style="border: solid 0px #ccc; float:left; margin:2px 10px 10px 0;"/></a><%# Eval("ShortDescription").ToString() %>
                            <a href='<%# "News-Detail.aspx?NewsId=" + Eval("NewsId") %>'>Read More</a>
                        
                        
                        </div>
                </ItemTemplate>
                
            </asp:Repeater>

    </div>
    
   
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="BusinessPartnerLogoContent" Runat="Server">
    <div class="BusinessPartnerLogoContentCss">

    
    <marquee scrollamount="9" behavior="scroll" direction="left" width="100%" >
    <img alt="" src="frontimages/SmallPics/Samsung_Logo.gif" />
    <img alt="" src="frontimages/SmallPics/CiscoSystem_Logo.gif" />
    <img alt="" src="frontimages/SmallPics/Hp_Logo.gif" />
    <img alt="" src="frontimages/SmallPics/Intel_Logo.gif" />
    <img alt="" src="frontimages/SmallPics/Epson_Logo.gif" />
    <img alt="" src="frontimages/SmallPics/Linksys_Logo.gif" />
   </marquee>
        

    </div>    

</asp:Content>


