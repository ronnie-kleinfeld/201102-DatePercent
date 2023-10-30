<%@ Page Language="C#" AutoEventWireup="true" Codebehind="fbsample.aspx.cs" Inherits="FBOAuthHell.fbsample" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <script>
                alert("document.referrer:" + document.referrer + "\n" +
                    "window.location:" + window.location);
                var strFBReferrer = "http://apps.facebook.com/fboauthhell".toLowerCase();
                if (document.referrer.toLowerCase().substr(0, strFBReferrer.length) != strFBReferrer)
		        {
		            top.location = "http://apps.facebook.com/fboauthhell";
		        }
        
                function displayUser(user)
                {
                    var userName = document.getElementById('userName');
                    var greetingText = document.createTextNode('Greetings, ' + user.name + '.');
                    userName.appendChild(greetingText);
                }

                var appID = ;
                if (window.location.hash.length == 0)
                {
                    var path = 'https://www.facebook.com/dialog/oauth?';
                    var queryParams = ['client_id=252133654799277',
                        'redirect_uri=' + window.location,
                        'response_type=token'];
                    var query = queryParams.join('&');
                    var url = path + query;
                    top.window.location = url;
                }
                else
                {
                    var accessToken = window.location.hash.substring(1);
                    var path = "https://graph.facebook.com/me?";
                    var queryParams = [accessToken, 'callback=displayUser'];
                    var query = queryParams.join('&');
                    var url = path + query;

                    // use jsonp to call the graph
                    var script = document.createElement('script');
                    script.src = url;
                    document.body.appendChild(script);        
                }
            </script>

            <p id="userName">
            </p>
        </div>
    </form>
</body>
</html>
