<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="MADA.DatePercent.BB.NLB.WS.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>DatePercent</title>
    <meta property="fb:app_id" content="349821425034185" />

    <script type="text/javascript">
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-2915423-3']);
        _gaq.push(['_trackPageview']);

        (function() {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();
    </script>

    <script type="text/javascript">
    function OnLoad()
    {
        var d = document.getElementById("aImage"); 
        if (window.location.search == '')
        {
            d.setAttribute("href", "<%= m_strRedirectUrl %>?<%= m_strIIS_BL %>");
        }
        else
        {
            d.setAttribute("href", "<%= m_strRedirectUrl %>" + window.location.search + "&<%= m_strIIS_BL %>");
        }
        var strLanguage;
        if (navigator.language)
        {
            strLanguage = navigator.language;
        }
        else
        {
            strLanguage = navigator.userLanguage;
        }
        switch(strLanguage)
        {
            case "es":
                document.getElementById("image").src = "Res/LandingPage_es.png";
                break;
            default:
                document.getElementById("image").src = "Res/LandingPage_en.png";
                break;
        }
    }
    </script>

</head>
<body onload="OnLoad();">
    <form id="form1" runat="server">
        <center>
            <a id="aImage">
                <img id="image" style="border: none" alt="DatePercent" width="752px" />
            </a>
        </center>
    </form>
</body>
</html>
