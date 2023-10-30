<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Loader.aspx.cs" Inherits="MADA.DatePercent.WL.Flex.Loader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DatePercent </title>
    <meta property="fb:app_id" content="224260514289069" />

    <script type="text/javascript">var _gaq = _gaq || [];_gaq.push(['_setAccount', 'UA-2915423-3']);_gaq.push(['_trackPageview']);(function() {var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);})();</script>

    <script type="text/javascript" src="../Script/swfobject.js"></script>

    <script type="text/javascript">
        function DoOnLoad()
        {
            DoLoadDummyApp();
        }    
        function DoLoadDummyApp()
        {
            var flashvars = {};
            var params = {};
            params.scale = "noscale";
            params.salign = "tl";
            var attributes = {};
            swfobject.embedSWF("<%= m_strRootFlexUrl %>DummyApp.swf", "divDummy", "0", "0", "10.0.0", false, flashvars, params, attributes, swfobjectDummyAppCallBack);
        }
        function swfobjectDummyAppCallBack(e)
        {
			DoLoadFrameworkApp();7
		}
        function DoLoadFrameworkApp()
        {
            var flashvars = {};
            flashvars.SID = "<%= m_strSID %>";
            var params = {};
            params.scale = "noscale";
            params.salign = "tl";
            var attributes = {};
            swfobject.embedSWF("<%= m_strRootFlexUrl %>FrameworkApp.swf" + document.location.search, "divFramework", "752", "600", "10.0.0", false, flashvars, params, attributes);
        }
    </script>

</head>
<body onload="DoOnLoad()">
    <form id="Form1" runat="server">
        <center>
            <div id="divFramework" style="width: 760px; height: 600px; padding-left: 0px; padding-right: 0px;
                padding-top: 0px; padding-bottom: 0px;">
                <div style="padding-left: 20px; font-size: x-large; font-weight: bold; color: #3b5998;
                    text-align: center;">
                    Loading... Please wait</div>
                <img style="width: 200px; height: 18px;" src="../Res/loading_progress.gif" alt="Loading... Please wait" />
            </div>
            <div id="divDummy" style="width: 0px; height: 0px; visibility: hidden;" />
            <br />
            <br />
            <div style="font-size: x-small;">
                <a href="http://www.datepercent.com">Home</a> &nbsp; |&nbsp; <a href="mailto:support@datepercent.com">
                    Contact Us</a> &nbsp; |&nbsp; <a href="http://www.datepercent.com/web/PrivacyPolicy.htm">
                        Privacy Policy</a> &nbsp; |&nbsp; <a href="http://www.datepercent.com/web/TermsOfUse.htm">
                            Terms of Use</a>
            </div>
        </center>
    </form>
</body>
</html>
