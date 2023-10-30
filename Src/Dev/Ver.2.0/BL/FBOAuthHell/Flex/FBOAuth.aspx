<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FBOAuth.aspx.cs" Inherits="FBOAuthHell.Flex.FBOAuth" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DatePercent </title>

    <script language="javascript">
        document.writeln(document.referrer);
        document.writeln(window.location);
        document.writeln(unescape(window.location));
//        alert("1:\n" +
//            "window.location:" + window.location.href + "\n\n" +
//            "document.referrer:" + document.referrer + "\n\n" +
//            "window.location.hash:" + window.location.hash + "\n\n" +
//            "window.location.hash.length:" + window.location.hash.length);

        if (window.location.hash.length == 0 & GetQueryString("token") == "")
        {
            var path = 'https://www.facebook.com/dialog/oauth?';
            var queryParams = ['client_id=252133654799277',
                'response_type=token',
                'redirect_uri=' + escape(window.location)];
            var query = queryParams.join('&');
            var url = path + query;
//            alert("2:\n" +
//                "window.location:" + window.location + "\n\n" +
//                "document.referrer:" + document.referrer + "\n\n" +
//                "url:" + url);
            top.window.location = url;
        }
        else
        {
            var strFBReferrer = "http://apps.facebook.com/fboauthhell".toLowerCase();
//            alert("3:\n" +
//                "window.location:" + window.location + "\n\n" +
//                "document.referrer:" + document.referrer);
            if (document.referrer.toLowerCase().substr(0, strFBReferrer.length) != strFBReferrer)
            {
                var path = 'http://apps.facebook.com/fboauthhell';
                var strToken;
                if (GetQueryString("token") == "")
                {
                    strToken = location.hash.split('&')[0].split('=')[1];
                }
                else
                {
                    strToken = GetQueryString("token");
                }
                var queryParams = [location.search,
                    'token=' + strToken];
                var query = queryParams.join('&');
                var url = path + query;
//                alert("4:\n" +
//                    "window.location:" + window.location + "\n\n" +
//                    "document.referrer:" + document.referrer + "\n\n" +
//                    "url:" + url);
                top.location = url;
            }
            else
            {
//                alert("5:\n" +
//                    "window.location:" + window.location + "\n\n" +
//                    "document.referrer:" + document.referrer);
                location = "App.aspx" + location.search;
            }
        }
        
        function GetQueryString(key, default_)
        {
            if (default_ == null) default_=""; 
            key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
            var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
            var qs = regex.exec(window.location.href);
            if (qs == null) return default_; else return qs[1];
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
