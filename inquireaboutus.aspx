<%@ Page Title="Feedback" Language="C#" MasterPageFile="~/MasterAboutUs.master" AutoEventWireup="true" CodeFile="inquireaboutus.aspx.cs" Inherits="inquireaboutus" %>




<asp:Content ID="Content1" ContentPlaceHolderID="RightBar"  Runat="Server">
<link href="App_Themes/Admin/StyleSheet.css" rel="stylesheet" type="text/css" />

    <div class="aboutmaindivh">
      Contact Us
 </div>
    
    <div class="companyprofilemaindivd" style="text-align:justify" >    

    <div id="FAQDiv"><p>Whether you're a customer or not, if you have a sales or any other related question, have a suggestion on how we can serve you better, or have a media request, 
we'll help you as quickly as we can,
or you may refer to our <a href="faqsection.aspx"> FAQ Question </a> for some of the common observations and questions.<br>
    
</p></div>
<h1>Please fill form below</h1><br />


         <div id="inner-body">
             <div id="inner-body-left">
                 <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="FeedBack"
                     ShowMessageBox="true" ShowSummary="false" />
                 <asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label>&nbsp;
                 <br />
                 <label>
                     Full Name</label>
                 <asp:TextBox ID="txtName" runat="server" CssClass="FormFields" Width="250px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                     Display="None" ErrorMessage="Name Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator><br />
                
                 <label>
                     Mobile / Any other Phone number</label>
                 <asp:TextBox ID="txtPhone" runat="server" CssClass="FormFields" Width="250px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPhone"
                     Display="None" ErrorMessage="Phone Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator><br />
                 <label>
                     City of resident</label>
                 <asp:TextBox ID="txtCity" runat="server" CssClass="FormFields" Width="250px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCity"
                     Display="None" ErrorMessage="City Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator><br />
                  <label>
                     Email address</label>
                 <asp:TextBox ID="txtEmail1" runat="server" CssClass="FormFields" Width="250px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail1"
                     Display="None" ErrorMessage="Email Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail1"
                     Display="None" ErrorMessage="Invalid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                     ValidationGroup="FeedBack"></asp:RegularExpressionValidator><br />
                 <label>
                     Occupation (Nature of job) </label>
                 <asp:TextBox ID="txtOccupation" runat="server" CssClass="FormFields" Width="250px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtOccupation"
                     Display="None" ErrorMessage="Occupation Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator><br />
                 <label>
                     Company / Employer</label>
                 <asp:TextBox ID="txtCompany" runat="server" CssClass="FormFields" Width="250px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCompany"
                     Display="None" ErrorMessage="Company Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator><br />
                 <label>
                     Age </label>
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
                     Display="None" ErrorMessage="Age Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator><br />
                 <label>
                     Comments:</label>
                 <asp:TextBox ID="txtComments1" runat="server" Height="150" TextMode="MultiLine" CssClass="FormFields"
                     Width="350px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtComments1"
                     Display="None" ErrorMessage="Comments Required" ValidationGroup="FeedBack"></asp:RequiredFieldValidator><br />
                 <label>
                     &nbsp;</label>
                 <asp:Button ID="btnAdd" runat="server" Text="Submit" ValidationGroup="FeedBack" 
                     CssClass="FormButtons" onclick="btnAdd_Click" />
             
             </div>
         </div>
    </div>

</asp:Content>

