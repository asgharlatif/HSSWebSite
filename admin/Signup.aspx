<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="Admin_Signup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <br />
        <span style="font-size: 10pt"><span style="font-family: Tahoma"><strong>
            <br />
            <br />
            <br />
            Admin Signup<br />
        </strong></span></span>
        <br />
        <table style="width: 336px; text-align: center">
            <tr>
                <td style="width: 90px; text-align: left">
                    <asp:Label ID="lblLogin" runat="server" Text="Login Id:" Font-Names="Tahoma" Font-Size="8pt"></asp:Label></td>
                <td style="width: 149px; text-align: left">
                    <asp:TextBox ID="txtLogin" runat="server" Width="183px"></asp:TextBox></td>
                <td style="width: 596px; text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLogin"
                        ErrorMessage="Missing" Font-Names="Tahoma" Font-Size="8pt"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 90px; text-align: left">
                    <asp:Label ID="lblPassword" runat="server" Text="Password:" Font-Names="Tahoma" Font-Size="8pt"></asp:Label></td>
                <td style="width: 149px; text-align: left">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="183px"></asp:TextBox></td>
                <td style="width: 596px; text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                        ErrorMessage="Missing" Font-Names="Tahoma" Font-Size="8pt"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 90px; text-align: left">
                    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:" Width="175px" Font-Names="Tahoma" Font-Size="8pt"></asp:Label></td>
                <td style="width: 149px; text-align: left">
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Width="183px"></asp:TextBox></td>
                <td style="width: 596px; text-align: left">
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                        ControlToValidate="txtConfirmPassword" ErrorMessage="Password doesn't match"
                        Width="162px" Font-Names="Tahoma" Font-Size="8pt"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td style="width: 90px; text-align: left">
                </td>
                <td style="width: 149px; text-align: left">
                </td>
                <td style="width: 596px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 90px; height: 15px;">
                </td>
                <td style="width: 149px; text-align: center; height: 15px;">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Font-Size="8pt" /></td>
                <td style="width: 596px; text-align: left; height: 15px;">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: left">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Visible="False" Font-Names="Tahoma" Font-Size="8pt"></asp:Label></td>
            </tr>
        </table>
        &nbsp;&nbsp;
    
    </div>
    </form>
</body>
</html>
