<%@ Page Title="Company Introduction" Language="C#" MasterPageFile="~/MasterAboutCompany.master" AutoEventWireup="true" CodeFile="companyIntroduction.aspx.cs" Inherits="companyIntroduction" %>
<%@ Register assembly="Artem.GoogleMap" namespace="Artem.Web.UI.Controls" tagprefix="artem" %>

 
<asp:Content ID="Content1" ContentPlaceHolderID="RightBar" Runat="Server">

<div class="aboutmaindivh" id="dividaboutthecompany">
      <a name="aboutthecompany"></a><asp:Label ID="lblaboutthecompany" runat="server" Text="About the Company"></asp:Label>
</div>

<div class="companyprofilemaindivd" id="aboutthecompany" style="text-align:justify" >    
   
    <div style="float: left; width: 60%" >
        
        <asp:Label ID="lblAboutCompany" runat="server" Text="Label"></asp:Label>

    </div>

    <div style="margin: 2px; float: right; width: 200px">
     
    <a href="http://mbcommunication.com.pk/" title="Go to Website" target="_blank">
    <asp:Image ID="Image3" runat="server"  />     
    </a>
    
     </div>
    <div style="clear: both" ></div>
  
 </div>

<div class="aboutmaindivh" id="dividcompanyprofile">
      <a name="companyprofile"></a><asp:Label ID="lblCompanyProfile" runat="server" Text="Company Profile"></asp:Label>
</div>

<div class="companyprofilemaindivd" id="companyprofile" style="text-align:justify" >    
     <table style="text-align: justify; table-layout: fixed; word-break: normal;" class="profile"
        cellspacing="0" cellpadding="0">
        <tbody>
            <tr>
                <th scope="row" class="style1">
                    Brand
                </th>
                <td>
                    <asp:Label ID="lblBrand" runat="server" Text="."></asp:Label>
                </td>
            </tr>
            <tr>
                <th scope="row" class="style1">
                    Owner
                </th>
                <td>
                    <asp:Label ID="lblOwner" runat="server" Text="."></asp:Label>
                </td>
            </tr>
            <tr>
                <th scope="row" class="style1">
                    Year Established
                </th>
                <td>
                    <asp:Label ID="lblYearEstablished" runat="server" Text="."></asp:Label>
                </td>
            </tr>
            <tr>
                <th scope="row" class="style1">
                    Contact
                </th>
                <td>
                    <asp:Label ID="lblContact" runat="server" Text="."></asp:Label>
                </td>
            </tr>
            <tr>
                <th scope="row" class="style1">
                    Email
                </th>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Text="."></asp:Label>
                </td>
            </tr>
            <tr>
                <th scope="row" class="style1">
                    Tel (1)
                </th>
                <td>
                    <asp:Label ID="lblTel1" runat="server" Text="."></asp:Label>
                </td>
            </tr>
            <tr>
                <th scope="row" class="style1">
                    Fax (1)
                </th>
                <td>
                    <asp:Label ID="lblFax1" runat="server" Text="."></asp:Label>
                </td>
            </tr>
            <tr>
                <th scope="row" class="style1">
                    URL
                </th>
                <td>
                    <asp:Label ID="lblURL" runat="server" Text="."></asp:Label>
                </td>
            </tr>
            <tr>
                <th scope="row" class="style1">
                    Zip Code
                </th>
                <td>
                    <asp:Label ID="lblZipCode" runat="server" Text="."></asp:Label>
                </td>
            </tr>
            <tr>
                <th scope="row" class="style1">
                    Address
                </th>
                <td>
                    <asp:Label ID="lblAddress" runat="server" Text="."></asp:Label>
                </td>
            </tr>
            <tr>
                <th scope="row" class="style1">
                    Business Type
                </th>
                <td>
                    <asp:Label ID="lblBusinessType" runat="server" Text="."></asp:Label>
                </td>
            </tr>
            <tr>
                <th scope="row" class="style1">
                    Main Product
                </th>
                <td>
                    <asp:Label ID="lblMainProduct" runat="server" Text="."></asp:Label>
                </td>
            </tr>
            <tr>
                <th scope="row" class="style1">
                    Main Market
                </th>
                <td>
                    &nbsp;<asp:Label ID="lblMainMarket" runat="server" Text="."></asp:Label>
                </td>
            </tr>
            <tr>
                <th scope="row" class="style1">
                    Approval / Certification
                </th>
                <td>
                    <asp:Label ID="lblApprovalCertificate" runat="server" Text="."></asp:Label>
                </td>
            </tr>
            <tr>
                <th scope="row" class="style1">
                    Membership
                </th>
                <td>
                    <asp:Label ID="lblMembership" runat="server" Text="."></asp:Label>
                </td>
            </tr>
        </tbody>
    </table>
</div>

<div class="aboutmaindivh" id="dividhotsale">
      <a name="hotsale"></a><asp:Label ID="lblHotSale" runat="server" Text="Hot Sale"></asp:Label>
</div>

<div class="companyprofilemaindivd"  id="hotsale">    
  
    <asp:DataList ID="DataList1" runat="server" 
            onselectedindexchanged="DataList1_SelectedIndexChanged" RepeatColumns="3" 
            RepeatDirection="Horizontal" BorderColor="#000066" BorderStyle="Solid" 
        BorderWidth="0px" Width="16px">
        <ItemTemplate>
            <table id="TblPrdHotSaleMainDiv">
                <tr>
                    <td valign="top">
                       <table cellpadding="0" cellspacing="0">
                            
                            <tr>
                                <td  align="left" height="10" valign="top" width="150">
                                    <asp:CheckBox ID="CheckBox1"  runat="server" />
                                   
                                </td>
                                </tr>
                                <tr>
                                <td align="left" height="50" valign="middle" >
                                    
                                   <img  alt="" src='<%# "thumbnail.aspx?Image=Images/ProductThumbNail/" + Eval("thumbnail")  %>'  />           
                                    
                                </td>
                            </tr>
                            <tr>
                                <td     height="27"           align="center">
                                        <a href="productinquiry.aspx" ><%# Eval("producttitle") %></a></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
  
    <div class="divclearboth"></div>

</div>

<div class="aboutmaindivh" id="dividfeaturedproducts">
     <a name="featuredproducts"></a><asp:Label ID="lblFeaturedProducts" runat="server" Text="Featured Products"></asp:Label>
</div>

<div class="companyprofilemaindivd" id="featuredproducts">    
    
     <asp:DataList ID="DataList2" runat="server" 
            onselectedindexchanged="DataList2_SelectedIndexChanged" RepeatColumns="4" 
            RepeatDirection="Horizontal" BorderColor="#000066" BorderStyle="Solid" 
        BorderWidth="0px" Width="16px">
        <ItemTemplate>
            <table id="TblPrdFeaturedProducts">
                <tr>
                    <td valign="top">
                       <table cellpadding="0" cellspacing="0">
                            
                            <tr>
                                <td  align="left" height="10" valign="top" width="150">
                                    <asp:CheckBox ID="CheckBox1"  runat="server" />
                                   
                                </td>
                                </tr>
                                <tr>
                                <td align="left" height="50" valign="middle" >
                                    
                                   <img  alt="" src='<%# "thumbnail.aspx?Image=Images/ProductThumbNail/" + Eval("thumbnail")  %>'  />           
                                    
                                </td>
                            </tr>
                            <tr>
                                <td     height="27"           align="center">
                                        <a href="productinquiry.aspx" ><%# Eval("producttitle") %></a></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
       

    <div class="divclearboth"></div>

</div>

<div class="aboutmaindivh" id="dividinquiretocompany">
      <a name="inquiretocompany"></a><asp:Label ID="lblInquiretocompany" runat="server" Text="Inquire to company"></asp:Label>
</div>


<div class="companyprofilemaindivd" id="inquiretocompany" style="text-align: justify">
   
   <table style="text-align: justify; table-layout: fixed; word-break: normal;" class="MakeCompInq"
            cellspacing="0" cellpadding="0">
            <tbody>
                <tr>
                    <th scope="row">
                        Full Name
                    </th>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" CssClass="FormFields" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                            Display="None" ErrorMessage="Name Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        <label>
                            Mobile / Any other Phone number</label>
                    </th>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="FormFields" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPhone"
                            Display="None" ErrorMessage="Phone Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        <label>
                            City of resident</label>
                    </th>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server" CssClass="FormFields" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCity"
                            Display="None" ErrorMessage="City Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        <label>
                            Email address</label>
                    </th>
                    <td>
                        <asp:TextBox ID="txtEmail1" runat="server" CssClass="FormFields" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail1"
                            Display="None" ErrorMessage="Email Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail1"
                            Display="None" ErrorMessage="Invalid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ValidationGroup="FeedBack"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        <label>
                            Occupation (Nature of job)</label>
                    </th>
                    <td>
                        <asp:TextBox ID="txtOccupation" runat="server" CssClass="FormFields" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtOccupation"
                            Display="None" ErrorMessage="Occupation Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        <label>
                            Company / Employer</label>
                    </th>
                    <td>
                        <asp:TextBox ID="txtCompany" runat="server" CssClass="FormFields" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCompany"
                            Display="None" ErrorMessage="Company Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        <label>
                            Age</label>
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlAge" runat="server" CssClass="DDLFields" Width="265px">
                            <asp:ListItem Value="">please select one</asp:ListItem>
                            <asp:ListItem Value="< 18">< 18</asp:ListItem>
                            <asp:ListItem Value="18-25">18-25</asp:ListItem>
                            <asp:ListItem Value="26-30">26-30</asp:ListItem>
                            <asp:ListItem Value="31-40">31-40</asp:ListItem>
                            <asp:ListItem Value="41-50">41-50</asp:ListItem>
                            <asp:ListItem Value=">50">>50</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlAge"
                            Display="None" ErrorMessage="Age Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        <label>
                            Comments:</label>
                    </th>
                    <td>
                        <asp:TextBox ID="txtComments1" runat="server" Height="108px" TextMode="MultiLine"
                            CssClass="FormFields" Width="425px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtComments1"
                            Display="None" ErrorMessage="Comments Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="FeedBack"
                            ShowMessageBox="true" ShowSummary="false" />
                        &nbsp;
                    </th>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="Submit" ValidationGroup="FeedBack" 
                            CssClass="FormButtons" onclick="btnAdd_Click"/>
                        <asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
</div>

<div class="aboutmaindivh" id="dividmaplocation">
      <a name="maplocation"></a><asp:Label ID="lblMapLocation" runat="server" Text="Map Location"></asp:Label>
</div>

<div class="companyprofilemaindivd" id="maplocation" style="text-align:justify" >   
     
        <div style="width:100%;">

      <artem:GoogleMap ID="GoogleMap1" runat="server" Width="100%" Height="300px" Key="ABQIAAAAEWrLUPnJkZJNwu1KuCe_sxTDd9iI5W1N-LSWGQSauds59ei0cRQ3ZzuaHGtxfx3mLWYrinGgohdhOw" 
            Latitude="24.89338" Longitude="67.02806"  Zoom="15"  
            ShowScaleControl="True" StreetViewMode="Panorama" ZoomPanType="Large3D" Font-Names="Verdana" Font-Size="12px">

            <Markers>
            <artem:GoogleMarker Latitude="24.89338" Longitude="67.02806" 
            Text="MB Communication<br/>
            FA-11/12,First Floor, Technocity
Hasrat Mohani Road,<br>Karachi-74200,<br />
                 Pakistan
                 <br />
                 Tel: +92-21-021-2270926-67
                 <br />
                 Tel: +92-21-021-2216808 <br />"/>
        
            </Markers>
            </artem:GoogleMap>
        </div>


</div>

</asp:Content>

