<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Admin Login</title>
    <style>
	body {
		font-family:Verdana, Geneva, sans-serif;
		font-size:11px;
		color:#666;
	}
	
	</style>
</head>
<body>
<form id="form1" runat="server">

<%--<ajaxToolkit:ToolkitScriptManager runat="Server" ID="ScriptManager1" />

        <ajaxToolkit:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server"
            BehaviorID="RoundedCornersBehavior1"
            TargetControlID="Panel1"
            Radius="20"
            Corners="All" BorderColor="black" />
            --%>
            


    <div align="center" style="margin-top:10%;">

    
    <asp:Panel ID="Panel1" runat="server" Width="400px" CssClass="roundedPanel">
    

    <table width="99%" bgcolor="white" align="center">
  <tr>
    <td align="center" colspan="2" style="padding:10px; text-align: left;"><img src="../frontimages/mainpageimages/SmallLogo.gif" id="IMG_logo" runat="server" border="0" /></td>
  </tr>
      <tr>
        <td colspan="2"> <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="True" Font-Names="Verdana" Font-Size="11px" Font-Bold="true"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />        </td>
      </tr>
      <tr>
        <td align="right" class="signin_black" style="width: 159px">Login:</td>
        <td width="292" style="text-align: left">
          <asp:TextBox ID="txtLogin" runat="server" Width="159px"></asp:TextBox>        </td>
      </tr>
      <tr>
        <td align="right" class="signin_black" style="width: 159px"> Password:</td>
        <td style="text-align: left">
          <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="159px"></asp:TextBox>        </td>
      </tr>
      <tr>
        <td style="width: 159px"><img src="images/spacer_white.gif" width="100" height="7" /></td>
        <td style="text-align: left">
          <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Font-Size="8pt" />       </td>
      </tr>
      
      <tr>
        <td style="width: 159px">&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
    </table>
    
    </asp:Panel>
    </div>
    
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLogin"
                        ErrorMessage="Login is required" Font-Names="Verdana" Font-Size="8pt" Display="None"></asp:RequiredFieldValidator>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                        ErrorMessage="Password is required" Font-Names="Verdana" Font-Size="8pt" Display="None"></asp:RequiredFieldValidator>

</form>
</body>
</html>
