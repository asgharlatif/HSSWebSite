<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FeedbackEmailConfirmation.aspx.cs" Inherits="EmailTemplates_FeedbackEmailConfirmation" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Reference Page="~/inquireaboutus.aspx" %>
<%@ Reference Page="~/companyIntroduction.aspx" %>
    
<html>
<head>
    <title></title>
    <style type="text/css">
	
	</style>
	
</head>

<body>


    <form id="form1" runat="server">
    <asp:Panel ID="emailme" runat="server">
        <table align="center" bgcolor="#83A9A1" border="0" cellpadding="3" cellspacing="0"
            width="600">
            <tr>
                <td>
                    <table bgcolor="#FFFFFF" border="0" cellpadding="3" cellspacing="0" style="font-family: Arial, Helvetica, sans-serif;
                        font-size: 12px;" width="100%">
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <span style="font-size: 7.5pt; font-family: Verdana">You are receiving this email because
                                    you subscribed to HSS Company</span><br />
                                <br />
                                <asp:Image ID="ImgCompLogo" runat="server"  style="float: right" 
                                    ImageUrl="../frontimages/logo/11.gif" />
                                
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2" bgcolor="#98A45C" style="text-align: left; color: #FFFFFF;">
                                <strong style="font-size: 18px; text-align: left;">Your Submitted Valuable Query to
                                    us.</strong>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <p>
                                    Dear
                                    <asp:Label ID="lblName2" runat="server"></asp:Label>,</p>
                                <p style="text-align: justify">
                                    Thanks for verifying your subscription to our email newsletters and information
                                    series.</p>
                                <p style="text-align: justify">
                                    Your <a href="../privacy.aspx">privacy </a>is important to us.
                                    Our Privacy Policy is simple, we will never give your contact to any other company
                                    without your permission. We will never bombard your inbox with frequent emails you
                                    don't want.
                                </p>
                                <p style="text-align: justify">
                                    Your business and your bottom line is our passion. We would like to see what opportunities
                                    your are missing in the online marketplace and where we can help with solutions.
                                </p>
                                <p>
                                    Please visit some of the common qurries and questions which we are trying to manage
                                    for your help at our <a href="../faqsection.aspx?SectionId=1">FAQ
                                        section</a>.
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="153" bgcolor="#98A45C" style="color: #FFFFFF">
                                &nbsp;
                            </td>
                            <td width="335">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" bgcolor="#98A45C" style="color: #FFFFFF">
                                <strong>Full Name:</strong>
                            </td>
                            <td>
                                <asp:Label ID="lblName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" bgcolor="#98A45C" style="color: #FFFFFF">
                                <strong>Your provided phone number:</strong>
                            </td>
                            <td>
                                <asp:Label ID="lblPhone" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" bgcolor="#98A45C" style="color: #FFFFFF">
                                <strong>Your current City of residance:</strong>
                            </td>
                            <td>
                                <asp:Label ID="lblCity" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" bgcolor="#98A45C" style="color: #FFFFFF">
                                <strong>Email:</strong>
                            </td>
                            <td>
                                <asp:Label ID="lblEmail" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" bgcolor="#98A45C" style="color: #FFFFFF">
                                <strong>Occupation:</strong>
                            </td>
                            <td>
                                <asp:Label ID="lblOccupation" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" bgcolor="#98A45C" style="color: #FFFFFF">
                                <strong>Business /&nbsp; Employer :</strong>
                            </td>
                            <td>
                                <asp:Label ID="lblCompany" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" bgcolor="#98A45C" style="color: #FFFFFF">
                                <strong>Age:</strong>
                            </td>
                            <td>
                                <asp:Label ID="lblAge" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" bgcolor="#98A45C" style="color: #FFFFFF">
                                <strong>Your Comments:</strong>
                            </td>
                            <td>
                                <asp:Label ID="lblComments" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" bgcolor="#98A45C" style="color: #FFFFFF">
                                <strong>You System IP Address:</strong>
                            </td>
                            <td>
                                <asp:Label ID="lblIPAddress" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#98A45C" style="color: #FFFFFF">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="font-size: 11px;">
                                <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </form>

</body>

</html>

               
   
