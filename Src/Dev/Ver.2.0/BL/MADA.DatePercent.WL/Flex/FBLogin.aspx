<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FBLogin.aspx.cs" Inherits="MADA.DatePercent.WL.Flex.FBLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>DatePercent </title>
    <meta property="fb:app_id" content="224260514289069" />

    <script type="text/javascript">var _gaq = _gaq || [];_gaq.push(['_setAccount', 'UA-2915423-3']);_gaq.push(['_trackPageview']);(function() {var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);})();</script>

    <script type="text/javascript">
        function DoOnLoad()
        {
            var path = 'https://www.facebook.com/connect/uiserver.php?';
            var queryParams = [
                'app_id=<%= m_strFBAppID %>',
                'method=permissions.request',
                //'display=popup',
                'response_type=token',
                //'fbconnect=1',
                'perms=user_birthday%2Cuser_photos%2Cemail%2Crsvp_event',
                'next=' + escape('<%= m_strRootUrl %>Flex/FBLoginPost.aspx' + location.search)];
            var query = queryParams.join('&');
            var url = path + query;
            top.location.href = url;
        }
    </script>

</head>
<body onload="DoOnLoad()">
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr align="center" valign="top">
                    <td>
                        <div style="padding-left: 20px; font-size: x-large; font-weight: bold; color: #3b5998;
                            text-align: center;">
                            Loading... Please wait</div>
                        <img style="width: 200px; height: 18px;" src="../Res/loading_progress.gif" alt="Loading... Please wait" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
