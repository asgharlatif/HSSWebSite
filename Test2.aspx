<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test2.aspx.cs" Inherits="Test2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="Artem.GoogleMap" namespace="Artem.Web.UI.Controls" tagprefix="artem" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>JQuery Photo Slider with Semi Transparent Caption</title>

    <style type="text/css">  
       .accordion {   
           width: 400px;   
       }   
           
        .accordionHeader {   
            border: 1px solid #2F4F4F;   
            color: white;   
            background-color: #2E4d7B;   
            font-family: Arial, Sans-Serif;   
            font-size: 12px;   
            font-weight: bold;   
            padding: 5px;   
           margin-top: 5px;   
            cursor: pointer;   
        }   
           
        .accordionHeaderSelected {   
            border: 1px solid #2F4F4F;   
            color: white;   
            background-color: #5078B3;   
           font-family: Arial, Sans-Serif;   
           font-size: 12px;   
            font-weight: bold;   
            padding: 5px;   
            margin-top: 5px;   
            cursor: pointer;   
        }   
           
        .accordionContent {   
            background-color: #D3DEEF;   
            border: 1px dashed #2F4F4F;   
            border-top: none;   
           padding: 5px;   
           padding-top: 10px;   
        }   
    </style>
   

</head>
<body>
    <form id="form1" runat="server">
 
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    </asp:UpdatePanel>
  
  

    </form>
    </body>
</html>
