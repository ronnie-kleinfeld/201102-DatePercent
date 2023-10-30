<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Loader.aspx.cs" Inherits="MADA.DatePercent.WL.Flex.Loader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DatePercent </title>

    <script type="text/javascript" src="../Script/swfobject.js"></script>

    <style type="text/css" media="screen"> 
		html, body	{ height:100%; }
		body { margin:0; padding:0; overflow:auto; text-align:center; 
		       background-color: ${bgcolor}; }   
		object:focus { outline:none; }
    </style>
        
    <script type="text/javascript">
        function DoOnLoad()
        {
            var flashvars = {};
            var params = {};
            params.quality = "high";
            params.allowfullscreen = "true";
            var attributes = {};
            attributes.align = "middle";
            swfobject.embedSWF("http://localhost:64775/Flex/PlatformApp.swf?a=d" + document.location.search, "divFramework", "100%", "100%", "10.0.0", false, flashvars, params, attributes);
        }
    </script>

</head>
<body onload="DoOnLoad()">
    <form id="Form1" runat="server">
        <center>
            <div id="divFramework" style="width: 100%; height: 100%; padding-left: 0px; padding-right: 0px;
                padding-top: 0px; padding-bottom: 0px;">
                <div style="padding-left: 20px; font-size: x-large; font-weight: bold; color: #3b5998;
                    text-align: center;">
                    Loading... Please wait</div>
            </div>
        </center>
    </form>
</body>
</html>
