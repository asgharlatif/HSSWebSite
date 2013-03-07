<%@ Page Title="login form" Language="C#" MasterPageFile="~/MasterLeftRightCenterPages.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMasterPageWithRightLatestProductsCenterBar" Runat="Server">


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

   </script>

<script language="javascript" type='text/javascript'>

    $(document).ready(function () {

        $(".button").click(function () {


            var Email = $('input[id$=txtEmail]').val();
            var Password = $('input[id$=txtPassword]').val();

            if (Email == "" || Password == "") {
                return false;
            }

            //--------------------- ajex page

            var ParemString = 'ReqForm=LogIn&Email=' + Email + "&Password=" + Password;
            $.ajax
            (
            {
                type: "POST",
                url: "UserRegProcess.aspx",
                data: ParemString,
                success:
            function (msg) {
                var list = $(msg).find('input:last').val();
                
                if (list == "Success") {
                    window.location.href = "default.aspx"; 
                    $('span[id$=lblEmailExists]').html("Login Successfull. Redirecting to home page.");

                }
                else if (list == "InvalidEmail") {
                    $('span[id$=lblEmailExists]').html("[Email address does not exists]");
                    

                }
                else if (list == "InvalidPwd") {
                    $('span[id$=lblEmailExists]').html("[Invalid Password.]");
                    

                }

            }
            }
            );

            return false;

            //--------------------- end ajex page




        });


    }
  );
  

</script>
  
    <link href="Styles/signup.css" rel="stylesheet" type="text/css" />

    <div class="comments-form">
        <h3 id="respond">
            Not yet registered ?</h3>
        <div id="divNotYetRegistered">
            <p>
                As a verified buyer member of HS&S Company’s, you can
                <ul>
                    <li>Send us inquiries about required products</li>
                    <li>Post unlimited buying leads</li>
                    <li>*Send Inquiries directly without filling out numerous lengthy questionaires</li>
                    <li>*Enjoy FREE sourcing solutions, from seeking to matching in order to meet manufacturers</li>
                </ul>
            </p>
            <p>
                <a href="signup.aspx">
                    <img src="frontimages/buttons/registernow.gif" />
                </a>
            </p>
        </div>
        <div id="divloginformarea">
            <h4>
                Sign in</h4>
            <p>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="formid" ValidationGroup="Reg"></asp:TextBox>
                <label    for="comment-name" >Email  </label>
                    <br /> <br />
                    <asp:Label ID="lblEmailExists" runat="server" Text="." ForeColor="Maroon" Font-Size="14px"></asp:Label>
               
            </p>
            <p>
                <label for="comment-name">
                    <strong class="required">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email is a required field"
                            ControlToValidate="txtEmail" ValidationGroup="Reg">Email is a required field</asp:RequiredFieldValidator>
                    </strong>
                </label>
                <label for="comment-name">
                    <strong class="required">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Invalid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ValidationGroup="Reg"></asp:RegularExpressionValidator>
                    </strong>
                </label>
            </p>
            <p>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="formid" ValidationGroup="Reg"
                    TextMode="Password" /><label for="comment-name">Password <strong class="required">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password is a required field"
                            ControlToValidate="txtPassword" ValidationGroup="Reg">Password is a required field</asp:RequiredFieldValidator>
                    </strong>
                    </label>
                </p>
            <p>
                <asp:Button ID="CmdSubmit" runat="server" Text="Sign in" CssClass="button" ValidationGroup="Reg"
                    UseSubmitBehavior="true" Width="150px" />
                <br />
                <br />
                <input type="checkbox" name="subscribe" id="subscribe" value="subscribe" checked="checked"
                    style="width: auto;" />
                <label for="subscribe">
                    Stay Signed in</label>
            </p>

            <a href="#" >Forget Password</a>
        </div>
    </div>

</asp:Content>

