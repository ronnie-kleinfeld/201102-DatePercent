<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FBLoginPost.aspx.cs" Inherits="MADA.DatePercent.WL.Flex.FBLoginPost" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DatePercent </title>
    <meta property="fb:app_id" content="224260514289069" />

    <script type="text/javascript">var _gaq = _gaq || [];_gaq.push(['_setAccount', 'UA-2915423-3']);_gaq.push(['_trackPageview']);(function() {var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);})();</script>

    <script type="text/javascript">
        if (window.location.hash == "")
        {
            location.href = "<%= m_strCanvasPageUrl %>";
        }
        else
        {
            //#access_token= to &access_token=
            //http://localhost:2631/Registration/AppLogin.aspx?p=v#access_token=244125612293062%7C2.AQABTdkCexQH3Kn8.3600.1314284400.1-689887907%7CbAIoJgWgRnmvVvak7OVKzI4prLM&expires_in=5675

            var strAccessToken = window.location.hash;
            var strAccessToken = strAccessToken.split("&expires_in=");
            var strAccessToken = strAccessToken[0];
            var strAccessToken = strAccessToken.split("#access_token=");
            var strAccessToken = strAccessToken[1];

            var strSearch = location.search;
            if (strSearch == "")
            {
                strSearch = "?";
            }
            else
            {
                strSearch = strSearch + "&";
            }

            location.href = "<%= m_strCanvasPageUrl %>" + strSearch + "<%= m_strFBAccessTokenKey %>=" + strAccessToken;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    </form>
</body>
</html>
