<%@ Page Title="Sign up form" Language="C#" MasterPageFile="~/MasterLeftRightCenterPages.master" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMasterPageWithRightLatestProductsCenterBar" Runat="Server">

<script type="text/javascript">

    $(document).ready(function () {


        $(".button").click(function () {



            //------------------------------
            var Email = $('input[id$=txtEmail]').val();
            var Password = $('input[id$=txtPassword]').val();
            var Name = $('input[id$=txtName]').val();
            var City = $('select[id$=CmbCity]').val();
            var URL = $('input[id$=txtURL]').val();
            var Address = $('textarea[id$=txtAddress]').val();



            if (Email == "" || Password == "" || Name == "") {
                //if ($('input[id$=txtEmail]').is(':empty')) {
                return false;
            }
            else if (Password != $('input[id$=txtPassword1]').val()) {
                return false;
            }




            var Subscribed = $('input:checkbox[id$=ChkSubscribed]').attr('checked');

            if (Subscribed != true)
                Subscribed = false;



            var ParemString = 'ReqForm=SignUp&Email=' + Email + "&Password=" + Password + "&Name=" + Name + "&City=" + City + "&Address=" + Address + "&Subscribed=" + Subscribed + "&URL=" + URL;
            $.ajax
            (
            {
                type: "POST",
                url: "UserRegProcess.aspx",
                data: ParemString,
                success:
            function (msg) {
                //--------------------------2

                var list = $(msg).find('input:last').val();


                if (list == "P") {
                    $(alert("Email address is already present. Please try some other."));

                }
                else if (list == "Success") {
                    $(alert("Registration completed successfully.."));
                    window.location.href = "login.aspx"; 
                }


                //--------------------------2
            }
            }
            );

            return false;

            //------------------------------

        }
        );

    }
  );

               

</script>


<link href="Styles/signup.css" rel="stylesheet" type="text/css" />



  <div class="comments-form">	
   
<h3 id="respond">Create an Account</h3>

<p> 
    <asp:TextBox ID="txtEmail" runat="server" CssClass="formid" 
        ValidationGroup="Reg"></asp:TextBox><label for="comment-name">Email
    <strong class="required">
    <asp:RequiredFieldValidator 
        ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="Email is a required field" ControlToValidate="txtEmail" 
        ValidationGroup="Reg">Email is a required field</asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
        runat="server" ControlToValidate="txtEmail" 
        ErrorMessage="Invalid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                     ValidationGroup="Reg"></asp:RegularExpressionValidator>
    </strong></label></p>
<p> 
<asp:TextBox ID="txtPassword" runat="server" CssClass="formid" 
        ValidationGroup="Reg" TextMode="Password" /><label for="comment-name">Password 
    <strong class="required">
    <asp:RequiredFieldValidator 
        ID="RequiredFieldValidator2" runat="server" 
        ErrorMessage="Password is a required field" ControlToValidate="txtPassword" 
        ValidationGroup="Reg">Password is a required field</asp:RequiredFieldValidator>
    </strong></label></p>
<p><asp:TextBox ID="txtPassword1" runat="server" CssClass="formid" 
        ValidationGroup="Reg" TextMode="Password" /> <label for="comment-name">Re-Type Password 
    <strong class="required">
    <asp:RequiredFieldValidator 
        ID="RequiredFieldValidator3" runat="server" 
        ErrorMessage="Re-Password is a required field" ControlToValidate="txtPassword1" 
        ValidationGroup="Reg">Password is a required field</asp:RequiredFieldValidator>
    </strong></label>
      </p>
      <p>
          <label for="comment-name"><strong class="required">
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToCompare="txtPassword" ControlToValidate="txtPassword1" 
        ErrorMessage="CompareValidator">Password must match</asp:CompareValidator>
    </strong></label></p>

<p><asp:TextBox ID="txtName" runat="server" CssClass="formid" 
        ValidationGroup="Reg" /><label for="comment-name">Your Name 
    <strong class="required">
    <asp:RequiredFieldValidator 
        ID="RequiredFieldValidator4" runat="server" 
        ErrorMessage="Name is a required field" ControlToValidate="txtName" 
        ValidationGroup="Reg">Name is a required field</asp:RequiredFieldValidator>
    </strong></label></p>


<p><asp:TextBox ID="txtURL" runat="server" CssClass="formid" /> <label for="comment-name">Your URL (e.g http://yahoo.com) </label></p>
<asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
        runat="server" ControlToValidate="txtURL" 
        ErrorMessage="Invalid URL" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"
                     ValidationGroup="Reg"></asp:RegularExpressionValidator>
<p>

    <asp:DropDownList CssClass="loc" ID="CmbCity" runat="server" ValidationGroup="Reg">
        
        <asp:ListItem Value="99" Selected="True">Pakistan (پاکستان)</asp:ListItem>
        <asp:ListItem Value="01">Afghanistan (افغانستان)</asp:ListItem>
        <asp:ListItem Value="02">Aland Islands</asp:ListItem>
        <asp:ListItem Value="03">Algeria (الجزائر)</asp:ListItem>
    </asp:DropDownList>

<label for="lblCmbCity">Your Location&nbsp; <label for="comment-name"> <strong class="required">
    <asp:RequiredFieldValidator 
        ID="RequiredFieldValidator6" runat="server" 
        ErrorMessage="Country Name is  a required field" ControlToValidate="CmbCity" 
        ValidationGroup="Reg">Country Name is  a required field</asp:RequiredFieldValidator>
    </strong></label>
</label></p>

<p> <asp:TextBox ID="txtAddress" runat="server" CssClass="formid" 
        TextMode="MultiLine" /><label for="comment-name">Your Address </label></p>


<p>
<span>

By clicking on 'I accept' below you are agreeing to the <a href="termscondition.aspx">Terms of Service</a> below and the <a href="privacy.aspx" >Privacy Policy.</a></span>							
<textarea name="comment" cols="50" rows="2">All contents are Copyright © 2011 HS&S Company All rights reserved.
No portion of this service may be reproduced in any form, or by any means, without prior written permission from HS&S Company
Rules and Regulations.
The following rules and regulations apply to all visitors to or users of this Web Site. By accessing this Web Site, user acknowledges acceptance of these terms and conditions. HS&S Company reserves the right to change these rules and regulations from time to time at its sole discretion. In the case of any violation of these rules and regulations, HS&S Company reserves the right to seek all remedies available by law and in equity for such violations. These rules and regulations apply to all visits to the HS&S Company Web Site, both now and in the future. 
</textarea></p>
     
      <table border="0">
          <tr>
              <td>
                  Notify me for all upcoming products via e-mail
              </td>
              <td>
                  <asp:CheckBox ID="ChkSubscribed" runat="server" Checked="true" Width="10px" />
              </td>
          </tr>
      </table>
   
     <p style="clear: both;" class="subscribe-to-comments"></p>
	
    <p>
                     <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Reg"
                     ShowMessageBox="true" ShowSummary="false" />

      <p>

    <asp:Button ID="CmdSubmit"   runat="server" Text="Create Account" 
        CssClass="button" ValidationGroup="Reg" UseSubmitBehavior="true"   />

    

    </div>



</asp:Content>

